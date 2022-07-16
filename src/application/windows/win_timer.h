/**********************************************************************************/
/*                                                                                */
/*               spdtmr: a lightweight, cross-platform speedrun timer             */
/*                        Copyright (c) 2022 jack bennett                         */
/*                                                                                */
/*   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR   */
/*    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,    */
/*  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE   */
/*     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER     */
/* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,  */
/* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE  */
/*                                   SOFTWARE.                                    */
/*                                                                                */
/**********************************************************************************/

#pragma once
#ifndef __SPDTMR_WIN_TIMER_H
#define __SPDTMR_WIN_TIMER_H

#include <QMainWindow>

namespace spdtmrapp {
    // The timer window.
    // This window will always be open as long as spdtmr is running, and so it inherits from QMainWindow
    // This means it will be treated as the main/root window of the application.
    //
    class TimerWindow : public QMainWindow {
        Q_OBJECT

    public:
        // Constructor for the timer window, where properties such as the window's size may be specified.
        //
        TimerWindow(
            const unsigned int &sizeX,
            const unsigned int &sizeY
        );
    };
}

#endif // __SPDTMR_WIN_TIMER_H
