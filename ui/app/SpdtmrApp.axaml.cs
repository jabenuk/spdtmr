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
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using Spdtmr.UI.Views;
using Spdtmr.UI.ViewModels;

namespace Spdtmr.UI {
    // C# loader class for the spdtmr Avalonia application, defined in SpdtmrApp.axaml.
    //
    public class SpdtmrApp : Application {
        public override void Initialize() {
            // Load SpdtmrApp.axaml.
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted() {
            // Set the main window of the application to be the timer window
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                desktop.MainWindow = new TimerWindow { DataContext = new TimerWindowViewModel() };
            }

            // Run parent (Application) OnFrameworkInitializationCompleted func
            base.OnFrameworkInitializationCompleted();
        }
    }
}
