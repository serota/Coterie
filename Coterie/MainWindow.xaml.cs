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
    using static Backend.City;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        string fileName;
        bool dirty;

        public MainWindow() {
            InitializeComponent();

            fileName = "New Coterie";
            dirty = false;

            characterList.ItemsSource = characters;
            factionList.ItemsSource = factions;

            factions.Add(new Faction("City"));

            for (var i = 0; i < 5; i++) {
                factions.Add(new Faction(((Clan)i).ToString()));
            }

            for (var i = 0; i < 5; i++) {
                factions.Add(new Faction(((Coven)i).ToString()));
            }

            refresh();
        }

        public void refresh() {
            characterList.Items.Refresh();
            factionList.Items.Refresh();

            if(dirty) {
                coterieWindow.Title = $"Coterie - {fileName} *";
            }
            else {
                coterieWindow.Title = $"Coterie - {fileName}";
            }
        }

        public void makeDirty() {
            dirty = true;
        }

        private void newVampireButton_Click(object sender, RoutedEventArgs e) {
            new EditVampire(this, -1).ShowDialog();
        }

        private void newMortalButton_Click(object sender, RoutedEventArgs e) {
            //new EditMortal(this, -1).ShowDialog();
        }

        private void deleteCharacterButton_Click(object sender, RoutedEventArgs e) {
            int i = characterList.SelectedIndex;

            if (i < 0) {
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete {characters[i].Name}?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                characters.RemoveAt(i);
                makeDirty();
                refresh();
            }
        }

        private void newFactionButton_Click(object sender, RoutedEventArgs e) {
            new EditFaction(this, -1).ShowDialog();
        }

        private void deleteFactionButton_Click(object sender, RoutedEventArgs e) {
            int i = factionList.SelectedIndex;

            if (i < 0) {
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete {factions[i].Name}?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                factions.RemoveAt(i);
                makeDirty();
                refresh();
            }
        }

        private void characterList_DoubleClick(object sender, MouseButtonEventArgs e) {
            int i = characterList.SelectedIndex;

            if (i < 0) {
                return;
            }

            switch(characters[i].Splat) {
                case "vampire":
                    new EditVampire(this, i).ShowDialog();
                    break;
                case "mortal":
                    //new EditMortal(this, i).ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void factionList_DoubleClick(object sender, MouseButtonEventArgs e) {
            int i = factionList.SelectedIndex;

            if (i < 0) {
                return;
            }

            new EditFaction(this, i).ShowDialog();
        }

        private void characterSort_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            switch(characterSort.SelectedIndex) {
                case 0:
                    characters.Sort(Sortable.byID);
                    break;
                case 1:
                    characters.Sort(Sortable.byName);
                    break;
                default:
                    break;
            }

            refresh();
        }

        private void factionSort_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            switch (factionSort.SelectedIndex) {
                case 0:
                    factions.Sort(Sortable.byID);
                    break;
                case 1:
                    factions.Sort(Sortable.byName);
                    break;
                default:
                    break;
            }

            refresh();
        }

        private void openMenu_Click(object sender, RoutedEventArgs e) {
            //TODO: Save system
        }

        private void saveMenu_Click(object sender, RoutedEventArgs e) {
            //TODO: Save system
        }

        private void saveAsMenu_Click(object sender, RoutedEventArgs e) {
            //TODO: Save system
        }

        private void exitMenu_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if(dirty) {
                switch(MessageBox.Show($"Save changes before closing?", "Exit", MessageBoxButton.YesNoCancel)) {
                    case MessageBoxResult.Yes:
                        //TODO: Save system
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
