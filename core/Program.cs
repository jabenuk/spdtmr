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

using System;

using Avalonia;
using Avalonia.ReactiveUI;

using Spdtmr.UI;

namespace Spdtmr.Core {
    class Program {
        // Execute the spdtmr application
        //
        [STAThread]
        public static void Main(string[] args) {
            // Use the Avalonia start function
            BuildAvaloniaApplication().StartWithClassicDesktopLifetime(args);
        }

        // Return the Avalonia configuration for the SpdtmrApp class.
        //
        public static AppBuilder BuildAvaloniaApplication() {
            return AppBuilder.Configure<SpdtmrApp>().UsePlatformDetect().LogToTrace().UseReactiveUI();
        }
    }
}
