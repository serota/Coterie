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

        int currentRole;

        public EditFaction(MainWindow parent, int whichFaction) {
            faction = new Faction();

            InitializeComponent();

            this.whichFaction = whichFaction;
            this.parent = parent;

            if (whichFaction < 0) {
                faction = new Faction();
            }
            else {
                faction = City.factions[whichFaction];
                factionWindow.Title = faction.Name;
            }

            nameField.Text = faction.Name;
            nameField.Focus();
            nameField.SelectAll();

            descriptionField.Text = faction.Description;

            roleList.ItemsSource = faction.Roles;
            currentRole = -1;
        }

        private void newRoleButton_Click(object sender, RoutedEventArgs e) {
            NewRole messageBox = new NewRole();

            if((bool)messageBox.ShowDialog()) {
                faction.Roles.Add(new Role(messageBox.RoleName));
            }

            refresh();
        }

        private void deleteRoleButton_Click(object sender, RoutedEventArgs e) {
            if (currentRole < 0) {
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete {faction.Roles[currentRole].Name}?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                faction.Roles.RemoveAt(currentRole);
                refresh();
            }
        }

        private void refresh() {
            if(currentRole >= 0 && currentRole < faction.Roles.Count) {
                                                            //1-MEMBERS
                nonmemberList.ItemsSource = City.characters.Except<Character>(faction.Roles[currentRole].Members);
                //this doesn't update dynamically; it needs to be recalculated every refresh
            }

            roleList.Items.Refresh();
            memberList.Items.Refresh();
            nonmemberList.Items.Refresh();
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

            parent.soil();
            parent.refresh();
            this.Close();
        }

        private void nameField_TextChanged(object sender, TextChangedEventArgs e) {
            faction.Name = nameField.Text;
        }

        private void descriptionField_TextChanged(object sender, TextChangedEventArgs e) {
            faction.Description = descriptionField.Text;
        }

        private void roleList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            currentRole = roleList.SelectedIndex;

            memberList.SelectedIndex = -1;
            nonmemberList.SelectedIndex = -1;
            transferButton.Content = "<>";

            if (currentRole >= 0 && currentRole < faction.Roles.Count) {
                memberList.ItemsSource = faction.Roles[currentRole].Members;
                                                            //1-MEMBERS
                nonmemberList.ItemsSource = City.characters.Except<Character>(faction.Roles[currentRole].Members);
            }
            else {
                memberList.ItemsSource = null;
                nonmemberList.ItemsSource = null;
            }
        }

        private void memberList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            transferButton.Content = ">";
        }

        private void nonmemberList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            transferButton.Content = "<";
        }

        private void transferButton_Click(object sender, RoutedEventArgs e) {
            if (currentRole >= 0 && currentRole < faction.Roles.Count) {
                if ((string)transferButton.Content == ">") {
                            //remove from the list of MEMBERS
                    faction.Roles[currentRole].Members.Remove
                            //an existing entry
                        (faction.Roles[currentRole].Members
                            //at the selected index
                        [memberList.SelectedIndex]);
                }
                else if ((string)transferButton.Content == "<") {
                            //add to the list of MEMBERS
                    faction.Roles[currentRole].Members.Add
                            //from the list of 1-MEMBERS
                        ((City.characters.Except<Character>(faction.Roles[currentRole].Members))
                            //at the selected index
                        .ElementAt<Character>(nonmemberList.SelectedIndex));
                }
            }

            refresh();
        }
    }
}
