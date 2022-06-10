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
#ifndef __WIN_TIMER_H
#define __WIN_TIMER_H

#include <QWidget>

namespace spdtmrapp {
    // The main Timer window widget
    class TimerWindow : public QWidget {
        // this class is a custom Qt object, inheriting from the QWidget class.
        Q_OBJECT

    private slots:
        // a window context menu slot function:
        // this slot will be called by Qt when the 'customContextmenuRequested' signal is sent, i.e. the user
        // clicks the right mouse button on the window
        void m_slot_WindowContextMenu(const QPoint &pos);

    public:
        TimerWindow(unsigned int sizeX, unsigned int sizeY);
    };
}

#endif // __WIN_TIMER_H
