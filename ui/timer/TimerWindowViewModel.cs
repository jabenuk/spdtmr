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

namespace Spdtmr.UI.ViewModels {
    // The view model for the timer window.
    // In an MVVM setup, a view-model is what connects the view (frontend) to the model (backend).
    //
    public class TimerWindowViewModel : ViewModelBase {
        public string WindowWidth => "300";
        public string WindowHeight => "300";

        public string Greeting => "Hello spdtmr!";
    }
}
