cmake_minimum_required(VERSION 3.10)

project(spdtmr)

# use standard C11 and C++11
set(CMAKE_C_STANDARD 11)
set(CMAKE_C_STANDARD_REQUIRED ON)
set(CMAKE_CXX_STANDARD 11)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# Qt applications normally use the MOC, RCC, and UIC compilers that come with Qt
set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTORCC ON)
set(CMAKE_AUTOUIC ON)

# find the Qt6 package and throw a fatal error if it is not installed
find_package(Qt6 REQUIRED COMPONENTS Widgets)

# src/ directory
set(SRC_DIR "${CMAKE_CURRENT_LIST_DIR}/src")

# set list of source files
set(SRCS
    # application: the frontend GUI application
    "${SRC_DIR}/application/program.cc"
    "${SRC_DIR}/application/engine/win_timer.cc"       "${SRC_DIR}/application/engine/win_timer.h"
    "${SRC_DIR}/application/engine/app_init.cc"        "${SRC_DIR}/application/engine/app_init.h"

    # lib: the backend (in C) which is called by the application
    "${SRC_DIR}/lib/libspdtmr.h"
)

# declare executable with the project name and the list of source files
add_executable(${PROJECT_NAME} ${SRCS})

# link to the Qt6 libraries
target_link_libraries(${PROJECT_NAME} PRIVATE Qt6::Widgets)

# declare include directories for the program
target_include_directories(${PROJECT_NAME}
    PRIVATE
        ${Qt6Widgets_INCLUDE_DIRS}  # Qt include directories
        "${SRC_DIR}/lib"            # backend source directory
)
