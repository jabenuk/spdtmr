cmake_minimum_required(VERSION 3.10)

project(spdtmr)
set(SPDTMR_API_NAME "lib${PROJECT_NAME}")
set(SPDTMR_EXEC_NAME "${PROJECT_NAME}exec")

#
# find python interpreter and python libs

find_package(Python3 REQUIRED)

#
# option to also build the Python application to an executable with pyinstaller
# this takes quite a while and is not necessary in development, so it is off by default

option(SPDTMR_PYTHON_AOT "Build the resulting Python application as a standalone executable (requires pyinstaller)" OFF)

#
# build C extension module for use in Python

set(LIB_SRC_DIRECTORY "${CMAKE_CURRENT_LIST_DIR}/src/lib")
set(LIB_SRCS
    "${LIB_SRC_DIRECTORY}/module/decls.c"
    "${LIB_SRC_DIRECTORY}/module/libspdtmr.h"

    "${LIB_SRC_DIRECTORY}/core.c"
)

add_library(${SPDTMR_API_NAME} SHARED "${LIB_SRCS}")

# the name is already prefixed with 'lib'
# automatic prefixing would mean this is not done on non-Linux systems, so it's easier to just specify
# a single name ('libspdtmr.X' - X being .so, .dll, etc.)
set_target_properties(${SPDTMR_API_NAME}
    PROPERTIES
        PREFIX ""
)

#
# generate all Python application files so the build directory can be accessed from within them

# I have about 1000 problems with doing this (jesus, copying source files to the build directory is just on so many levels of dumbassery)
# but until the people who make Python start thinking properly, we have to make do with the astoundingly appalling module/package/whatever-the-fuck-theyre-called
# system. The only reason - the ONE reason - I am even doing this godawful step is because we need to access the location of the libspdtmr library
# output, which is CMAKE_CURRENT_BINARY_DIR, from within the shitty Python source files. i'm guessing there is a better way of doing this that is less idiotic
# but this... works... for now ¯\_(ツ)_/¯

file(GLOB PYTHON_FILES "${CMAKE_CURRENT_LIST_DIR}/src/application/*")
foreach(file ${PYTHON_FILES})
    # get filename from path (/absolute/path/to/main.py -> main.py)
    get_filename_component(filename "${file}" NAME)

    configure_file("${CMAKE_CURRENT_LIST_DIR}/src/application/${filename}" "${CMAKE_CURRENT_BINARY_DIR}/src/application/${filename}" @ONLY)
endforeach()

#
# if the Python application is not being compiled then we are done

if (NOT SPDTMR_PYTHON_AOT)
    return()
else()
    message(STATUS "Also packaging spdtmr application!")
endif()

# otherwise, we move on...

#
# verify the installation of pyinstaller

execute_process(
    COMMAND ${Python3_EXECUTABLE} -m pip show pyinstaller
    RESULT_VARIABLE found_pyinstaller
    OUTPUT_QUIET
)

if (NOT ${found_pyinstaller} EQUAL 0)
    message(FATAL_ERROR "The pyinstaller Python3 package is not installed. Please install it with the `python3 -m pip install pyinstaller` command and add it to your PATH.")
else()
    message(STATUS "Found pyinstaller -- now assuming it is in your PATH")
endif()

# we are assuming that pyinstaller is in PATH
set(pyinstaller_EXECUTABLE "pyinstaller")

#
# package application (can take a while)

set(APPLICATION_SRC "${CMAKE_CURRENT_BINARY_DIR}/src/application/main.py")

add_custom_target(
    ${SPDTMR_EXEC_NAME} ALL
    COMMAND ${pyinstaller_EXECUTABLE} -n "spdtmrexec" --distpath "${CMAKE_CURRENT_BINARY_DIR}/exec" --workpath "${CMAKE_CURRENT_BINARY_DIR}/exec/temp" --onedir ${APPLICATION_SRC}
    COMMENT "Building Python application"
    VERBATIM
)
