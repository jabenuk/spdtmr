/*************************************************************************/
/*                                                                       */
/*          spdtmr: a lightweight, cross-platform speedrun timer         */
/*                    Copyright (C) 2022 Jack Bennett                    */
/*                                                                       */
/*  This program is free software: you can redistribute it and/or modify */
/*  it under the terms of the GNU General Public License as published by */
/*    the Free Software Foundation, either version 3 of the License,     */
/*                  (at your option) any later version.                  */
/*                                                                       */
/*    This program is distributed in the hope that it will be useful,    */
/*     but WITHOUT ANY WARRANTY; without even the implied warranty of    */
/*     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the     */
/*              GNU General Public License for more details.             */
/*                                                                       */
/*   You should have received a copy of the GNU General Public License   */
/* along with this program. If not, see <https://www.gnu.org/licenses/>. */
/*                                                                       */
/*************************************************************************/

#include "libspdtmr.h"

static PyMethodDef MODULE_FUNCTIONS[] = {
    { "Version", (PyCFunction) Version, METH_NOARGS, "Get the current version of spdtmr." },
    { NULL, NULL, 0, NULL }
};

static struct PyModuleDef MODULE_DEFINITION = {
    PyModuleDef_HEAD_INIT,
    "spdtmrapi",
    "A lightweight, cross-platform speedrun timer",
    -1,
    MODULE_FUNCTIONS
};

PyMODINIT_FUNC PyInit_libspdtmr() {
    return PyModule_Create(&MODULE_DEFINITION);
}
