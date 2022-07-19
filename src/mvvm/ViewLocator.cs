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

using Avalonia.Controls;
using Avalonia.Controls.Templates;

using Spdtmr.ViewModels;

namespace Spdtmr {
    // Class to convert view models into views (https://docs.avaloniaui.net/tutorials/todo-list-app/locating-views).
    //
    public class ViewLocator : IDataTemplate {
        public IControl Build(object data) {
            // Replace the string "ViewModel" with "View" in the qualified name of data's type.
            var name = data.GetType().FullName!.Replace("ViewModel", "View");

            // Get a type that matches name.
            var type = Type.GetType(name);

            // If type is not NULL, then create an instance of that type and return it.
            // Otherwise, a "Not found" message is produced.
            if (type != null) {
                return (Control) Activator.CreateInstance(type)!;
            } else {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        public bool Match(object data) {
            // Return true if data inherits from ViewModelBase
            return data is ViewModelBase;
        }
    }
}
