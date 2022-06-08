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

import libspdtmr as spdtmr

class Window(Gtk.Window):
    def __init__(self):
        Gtk.Window.__init__(self, title="spdtmr")
        Gtk.Window.set_default_size(self, 400, 325)
        Gtk.Window.set_position(self, Gtk.WindowPosition.CENTER)

        button = Gtk.Button(label="Test")
        button.connect("clicked", self.ButtonActive)

        self.add(button)

    def ButtonActive(self, btn):
        print(f"current version of spdtmr: {spdtmr.Version()}")

window = Window()
window.connect("delete-event", Gtk.main_quit)
window.show_all()

Gtk.main()
