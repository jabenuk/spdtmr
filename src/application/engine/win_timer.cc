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

#include "win_timer.h"
#include "app_init.h"
#include "libspdtmr.h"

#include <QApplication>
#include <QMenu>
#include <QMouseEvent>

namespace spdtmrapp {
    void TimerWindow::m_slot_WindowContextMenu(const QPoint &pos) {
        // the pos parameter is normally in 'widget coordinates' so it must be mapped to global coordinates*
        // *global coordinates mean that 0, 0 is the top-left of the SCREEN (left-most screen if multi-monitor), not necessarily the WIDGET
        QPoint gpos = mapToGlobal(pos);

        QMenu contextMenu;

        // add actions to the context menu:

        // 'Exit' action
        contextMenu.addAction("Exit", Exit);

        // 'execute' the context menu (show it) at the gpos position
        contextMenu.exec(gpos);
    }

    void TimerWindow::mouseMoveEvent(QMouseEvent *event) {
        // if the event.buttons() bit mask includes the left mouse button (LMB is being held down whilst moving) then move the window
        if (event->buttons() & Qt::LeftButton) {
            move(event->globalPosition().toPoint() - m_mouseDragInitial);

            event->accept();
        }
    }

    void TimerWindow::mousePressEvent(QMouseEvent *event) {
        // if the user clicks the left mouse button...
        if (event->button() == Qt::LeftButton) {
            // get difference between top-left position of the window and the mouse position
            m_mouseDragInitial = event->globalPosition().toPoint() - frameGeometry().topLeft();

            event->accept();
        }
    }

    TimerWindow::TimerWindow(unsigned int sizeX, unsigned int sizeY) {
        setWindowTitle(QApplication::translate("toplevel", "spdtmr"));
        resize(sizeX, sizeY);

        // set window flags:
        //      custom window hints - defaults are not used (so no title bar, decorations, etc)
        setWindowFlags(Qt::CustomizeWindowHint);

        // set context menu policy: a custom context menu allows us to implement our own
        // we must then connect our context menu slot to the appropriate signal with connect()
        setContextMenuPolicy(Qt::CustomContextMenu);
        connect(this, SIGNAL(customContextMenuRequested(const QPoint &)), this, SLOT(m_slot_WindowContextMenu(const QPoint &)));
    }
}
