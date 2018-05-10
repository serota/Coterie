using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Coterie {
    using Backend;
    /// <summary>
    /// Interaction logic for EditFaction.xaml
    /// </summary>
    public partial class EditFaction : Window {
        Faction faction;
        int whichFaction;
        MainWindow parent;

        public EditFaction(MainWindow parent, int whichFaction) {
            InitializeComponent();

            this.whichFaction = whichFaction;
            this.parent = parent;

            if (whichFaction < 0) {
                faction = new Faction();
            }
            else {
                faction = City.factions[whichFaction];
            }

            nameField.Focus();

            nameField.Text = faction.Name;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e) {
            if (faction.Name == "") {
                faction.Name = "Untitled";
            }

            if (whichFaction < 0) {
                City.factions.Add(faction);
            }
            else {
                City.factions[whichFaction] = faction;
            }

            parent.makeDirty();
            parent.refresh();
            this.Close();
        }

        private void nameField_TextChanged(object sender, TextChangedEventArgs e) {
            faction.Name = nameField.Text;
        }
    }
}
