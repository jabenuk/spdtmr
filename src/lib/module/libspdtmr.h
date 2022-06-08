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

#pragma once
#ifndef __SPDTMR_H
#define __SPDTMR_H

#ifdef __cplusplus
    extern "C" {
#endif

#define PY_SSIZE_T_CLEAN
#include <python3.10/Python.h>

#define PYAPI PyObject *
#define PYARGS PyObject *self, PyObject *args
#define PYNOARGS PyObject *self

#define SPDTMR_VERSION "dev_v0.1"

/**
 * @brief Get the current version of spdtmr.
 *
 */
PYAPI Version(PYNOARGS);
    // defined in core.c

#ifdef __cplusplus
    }
#endif

#endif // __SPDTMR_H
