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
using Microsoft.Win32;

namespace Coterie {
    using Backend;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private City city;
        string sessionName;
        bool dirty;
        string file;

        public City City {
            get {
                return city;
            }
        }

        public MainWindow() {
            city = new City();

            InitializeComponent();

            sessionName = "New Coterie";
            dirty = false;
            file = "";

            characterList.ItemsSource = city.Characters;
            factionList.ItemsSource = city.Factions;

            city.Factions.Add(new Faction("City"));

            for (var i = 1; i < (int)Clan.Length; i++) {
                city.Factions.Add(new Faction(((Clan)i).ToString()));
            }

            for (var i = 1; i < (int)Coven.Length; i++) {
                city.Factions.Add(new Faction(((Coven)i).ToString()));
            }

            refresh();
        }

        private void writeToFile() {
           //TODO: implement save

            dirty = false;
            refresh();
        }

        private void readFromFile() {
            //TODO: implement load

            dirty = false;
            refresh();
        }

        public void refresh() {
            characterList.Items.Refresh();
            factionList.Items.Refresh();

            if(dirty) {
                coterieWindow.Title = $"Coterie - {sessionName} *";
            }
            else {
                coterieWindow.Title = $"Coterie - {sessionName}";
            }
        }

        public void soil() {
            //TODO: re-enable soil when saving works
            //dirty = true;
        }

        private void newVampireButton_Click(object sender, RoutedEventArgs e) {
            new EditVampire(this, -1).ShowDialog();
        }

        private void newMortalButton_Click(object sender, RoutedEventArgs e) {
            new EditMortal(this, -1).ShowDialog();
        }

        private void deleteCharacterButton_Click(object sender, RoutedEventArgs e) {
            int i = characterList.SelectedIndex;

            if (i < 0) {
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete {city.Characters[i].Name}?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                city.Characters.RemoveAt(i);
                soil();
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

            if (MessageBox.Show($"Are you sure you want to delete {city.Factions[i].Name}?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                city.Factions.RemoveAt(i);
                soil();
                refresh();
            }
        }

        private void characterList_DoubleClick(object sender, MouseButtonEventArgs e) {
            int i = characterList.SelectedIndex;

            if (i < 0) {
                return;
            }

            switch(city.Characters[i].Splat) {
                case "vampire":
                    new EditVampire(this, i).ShowDialog();
                    break;
                case "mortal":
                    new EditMortal(this, i).ShowDialog();
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
                    city.Characters.Sort(Sortable.byID);
                    break;
                case 1:
                    city.Characters.Sort(Sortable.byName);
                    break;
                default:
                    break;
            }

            refresh();
        }

        private void factionSort_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            switch (factionSort.SelectedIndex) {
                case 0:
                    city.Factions.Sort(Sortable.byID);
                    break;
                case 1:
                    city.Factions.Sort(Sortable.byName);
                    break;
                default:
                    break;
            }

            refresh();
        }

        private void openMenu_Click(object sender, RoutedEventArgs e) {
            if (dirty) {
                switch (MessageBox.Show($"Save changes before opening a new file?", "Open", MessageBoxButton.YesNoCancel)) {
                    case MessageBoxResult.Yes:
                        if (!save()) {
                            return;
                        }
                        break;
                    case MessageBoxResult.Cancel:
                        return;
                    default:
                        break;
                }
            }

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Coterie city files (*.vcity)|*.vcity";

            if (open.ShowDialog() == true) {
                file = open.FileName;
                sessionName = file;
                readFromFile();
            }
        }

        private void saveMenu_Click(object sender, RoutedEventArgs e) {
            save();
        }

        private void saveAsMenu_Click(object sender, RoutedEventArgs e) {
            saveAs();
        }

        private bool save() {
            if (file == "") {
                return saveAs();
            }
            else {
                writeToFile();
                return true;
            }
        }

        private bool saveAs() {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Coterie city files (*.vcity)|*.vcity";

            if (save.ShowDialog() == true) {
                file = save.FileName;
                sessionName = file;
                writeToFile();

                return true;
            }

            return false;
        }

        private void exitMenu_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if(dirty) {
                switch(MessageBox.Show($"Save changes before closing?", "Exit", MessageBoxButton.YesNoCancel)) {
                    case MessageBoxResult.Yes:
                        if(!save()) {
                            e.Cancel = true;
                        }
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
