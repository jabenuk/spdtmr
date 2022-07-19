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
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Spdtmr.Views {
    // C# loader class for the TimerWindow view, defined in TimerWindow.axaml.
    //
    public partial class TimerWindow : Window {
        public TimerWindow() {
            InitializeComponent();

            // attach development tools if the build configuration is set to debug.
#           if DEBUG
                this.AttachDevTools();
#           endif
        }

        private void InitializeComponent() {
            // Load the Avalonia xaml file.
            AvaloniaXamlLoader.Load(this);
        }
    }
}
