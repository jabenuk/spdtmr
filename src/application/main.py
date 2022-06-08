# *********************************************************************** #
#                                                                         #
#           spdtmr: a lightweight, cross-platform speedrun timer          #
#                     Copyright (C) 2022 Jack Bennett                     #
#                                                                         #
#   This program is free software: you can redistribute it and/or modify  #
#   it under the terms of the GNU General Public License as published by  #
#     the Free Software Foundation, either version 3 of the License,      #
#                   (at your option) any later version.                   #
#                                                                         #
#     This program is distributed in the hope that it will be useful,     #
#      but WITHOUT ANY WARRANTY; without even the implied warranty of     #
#      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the      #
#               GNU General Public License for more details.              #
#                                                                         #
#    You should have received a copy of the GNU General Public License    #
#  along with this program. If not, see <https://www.gnu.org/licenses/>.  #
#                                                                         #
# *********************************************************************** #

from cProfile import label
import gi

gi.require_version("Gtk", "3.0")

from gi.repository import Gtk
from gi.repository import Gdk

import libspdtmr as spdtmr

class Timer(Gtk.Window):
    def __init__(self):
        # set basic attributes of the timer widget
        Gtk.Window.__init__(self, title="spdtmr")
        Gtk.Window.set_default_size(self, 400, 325)
        Gtk.Window.set_position(self, Gtk.WindowPosition.CENTER)

        # timer widget does not have decorations
        Gtk.Window.set_decorated(self, False)
        Gtk.Window.set_resizable(self, True)

        # GTK deletion event
        self.connect("delete-event", self._delete)

        # create right-click context menu
        self._build_context_menu()
        self._assign_context_menu_actions()
        # entire window has a button press event (for the right-click context menu)
        self.connect("button-press-event", self._button_press)

    def _build_context_menu(self):
        # right click context menu
        self.cmenu = Gtk.Menu.new()

        # exit the application
        self.cm_item = Gtk.MenuItem.new_with_label("Quit")
        self.cmenu.append(self.cm_item)

        # show context menu items
        self.cmenu.show_all()

    def _assign_context_menu_actions(self):
        # assign quit action
        self.cm_item.connect("button-press-event", self._delete)

    def _button_press(self, widget, event):
        if event.type == Gdk.EventType.BUTTON_PRESS and event.button == 3:
            self.cmenu.popup_at_pointer()

        return True

    def _delete(self, a, b):
        print("quitting...")
        Gtk.main_quit()


timer = Timer()
timer.connect("delete-event", Gtk.main_quit)
timer.show_all()

Gtk.main()
