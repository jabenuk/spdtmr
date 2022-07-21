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

using Avalonia;
using Avalonia.Input;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Spdtmr.Views {
    // C# loader class for the TimerWindow view, defined in TimerWindow.axaml.
    //
    public partial class TimerWindow : Window {
        // The distance from window edges where the cursor can be to resize the window.
        //
        public double ResizeMargin => 8.0;

        // Constructor
        //
        public TimerWindow() {
            InitializeComponent();

            // attach development tools if the build configuration is set to debug.
#           if DEBUG
                this.AttachDevTools();
#           endif

            // mouse handlers for window movement and resize events
            this.AddHandler(PointerPressedEvent, MouseDownHandler);
            this.AddHandler(PointerMovedEvent, MouseMoveHandler);
        }

        // Load XAML at runtime.
        //
        private void InitializeComponent() {
            // Load the Avalonia xaml file.
            AvaloniaXamlLoader.Load(this);
        }

        // This handler is necessary is the timer window is borderless.
        // This means we lose access to window-manager-given features like built-in resizing and moving, so we must implement them ourselves.
        //
        private void MouseDownHandler(object? sender, PointerPressedEventArgs e) {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed) {
                WindowEdge? resizeEdge = GetNearestEdgeToPointer(e);

                // if resizeEdge is not NULL, then start resizing the window on that edge.
                if (resizeEdge is WindowEdge edge) {
                    BeginResizeDrag(edge, e);
                } else {
                    // if resizeEdge is NULL, start moving the window
                    BeginMoveDrag(e);
                }
            }
        }

        // Will check if the pointer is within the resize margins, and change the pointer style accordingly if so.
        //
        private void MouseMoveHandler(object? sender, PointerEventArgs e) {
            // get nearest edge to pointer
            WindowEdge? resizeEdge = GetNearestEdgeToPointer(e);

            // cursor type which the cursor will be set to at the end of the function
            // this will be set to NULL if not near any edges!
            StandardCursorType? cursorType = resizeEdge switch {
                WindowEdge.NorthWest => StandardCursorType.TopLeftCorner,
                WindowEdge.North => StandardCursorType.TopSide,
                WindowEdge.NorthEast => StandardCursorType.TopRightCorner,
                WindowEdge.East => StandardCursorType.RightSide,
                WindowEdge.SouthEast => StandardCursorType.BottomRightCorner,
                WindowEdge.South => StandardCursorType.BottomSide,
                WindowEdge.SouthWest => StandardCursorType.BottomLeftCorner,
                WindowEdge.West => StandardCursorType.LeftSide,
                _ => null
            };

            // update cursor style if not NULL
            if (cursorType is StandardCursorType type) {
                this.Cursor = new Cursor(type);
            } else {
                // if NULL then set cursor to default
                this.Cursor = Cursor.Default;
            }
        }

        // Return the window edge that the pointer is nearest to.
        // Will return NULL if the pointer is not within ResizeMargin pixels of any window edge.
        //
        private WindowEdge? GetNearestEdgeToPointer(PointerEventArgs e) {
            // get pointer position
            Point cursorPos = e.GetCurrentPoint(this).Position;

            // top
            if (cursorPos.Y < ResizeMargin) {
                // top left
                if (cursorPos.X < ResizeMargin) {
                    return WindowEdge.NorthWest;
                }
                // top right
                if (cursorPos.X > Width - ResizeMargin) {
                    return WindowEdge.NorthEast;
                }
                // top middle
                return WindowEdge.North;
            }

            // bottom
            if (cursorPos.Y > Height - ResizeMargin) {
                // bottom left
                if (cursorPos.X < ResizeMargin) {
                    return WindowEdge.SouthWest;
                }
                // bottom right
                if (cursorPos.X > Width - ResizeMargin) {
                    return WindowEdge.SouthEast;
                }
                // bottom middle
                return WindowEdge.South;
            }

            // left (corners have already been handled)
            if (cursorPos.X < ResizeMargin) {
                return WindowEdge.West;
            }

            // right (corners have already been handled)
            if (cursorPos.X > Width - ResizeMargin) {
                return WindowEdge.East;
            }

            // not within ResizeMargin of any edges; return NULL.
            return null;
        }
    }
}
