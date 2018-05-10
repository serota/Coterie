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
    using static Backend.Attr;
    using static Backend.Skil;
    /// <summary>
    /// Interaction logic for NewVampire.xaml
    /// </summary>
    public partial class EditVampire : Window {
        Vampire vampire;
        int whichVampire;
        MainWindow parent;

        public EditVampire(MainWindow parent, int whichVampire) {
            vampire = new Vampire();

            InitializeComponent();

            clanBox.ItemsSource = Enum.GetValues(typeof(Clan));
            covenBox.ItemsSource = Enum.GetValues(typeof(Coven));

            this.whichVampire = whichVampire;
            this.parent = parent;

            if (whichVampire < 0) {
                vampire = new Vampire();
            }
            else {
                vampire = (Vampire)City.characters[whichVampire];
                vampireWindow.Title = vampire.Name;
            }

            nameField.Text = vampire.Name;
            nameField.Focus();
            nameField.SelectAll();

            maskField.Text = vampire.Mask;
            clanBox.SelectedIndex = (int)vampire.Clan;
            potencyDots.Value = vampire.Potency.Dots;

            playerField.Text = vampire.Player;
            dirgeField.Text = vampire.Dirge;
            covenBox.SelectedIndex = (int)vampire.Covenant;
            humanityDots.Value = vampire.Humanity.Dots;

            conceptField.Text = vampire.Concept;
            biographyField.Text = vampire.Biography;

            intelligenceDots.Value      = vampire.Attributes[(int)Intelligence].Dots;
            witsDots.Value              = vampire.Attributes[(int)Wits].Dots;
            resolveDots.Value           = vampire.Attributes[(int)Resolve].Dots;

            strengthDots.Value          = vampire.Attributes[(int)Strength].Dots;
            dexterityDots.Value         = vampire.Attributes[(int)Dexterity].Dots;
            staminaDots.Value           = vampire.Attributes[(int)Stamina].Dots;

            presenceDots.Value          = vampire.Attributes[(int)Presence].Dots;
            manipulationDots.Value      = vampire.Attributes[(int)Manipulation].Dots;
            composureDots.Value         = vampire.Attributes[(int)Composure].Dots;

            academicsDots.Value         = vampire.Skills[(int)Academics].Dots;
            computerDots.Value          = vampire.Skills[(int)Computer].Dots;
            craftsDots.Value            = vampire.Skills[(int)Crafts].Dots;
            investigationDots.Value     = vampire.Skills[(int)Investigation].Dots;
            medicineDots.Value          = vampire.Skills[(int)Medicine].Dots;
            occultDots.Value            = vampire.Skills[(int)Occult].Dots;
            politicsDots.Value          = vampire.Skills[(int)Politics].Dots;
            scienceDots.Value           = vampire.Skills[(int)Science].Dots;

            athleticsDots.Value         = vampire.Skills[(int)Athletics].Dots;
            brawlDots.Value             = vampire.Skills[(int)Brawl].Dots;
            driveDots.Value             = vampire.Skills[(int)Drive].Dots;
            firearmsDots.Value          = vampire.Skills[(int)Firearms].Dots;
            larcenyDots.Value           = vampire.Skills[(int)Larceny].Dots;
            stealthDots.Value           = vampire.Skills[(int)Stealth].Dots;
            survivalDots.Value          = vampire.Skills[(int)Survival].Dots;
            weaponryDots.Value          = vampire.Skills[(int)Weaponry].Dots;

            animalKenDots.Value         = vampire.Skills[(int)AnimalKen].Dots;
            empathyDots.Value           = vampire.Skills[(int)Empathy].Dots;
            expressionDots.Value        = vampire.Skills[(int)Expression].Dots;
            intimidationDots.Value      = vampire.Skills[(int)Intimidation].Dots;
            persuasionDots.Value        = vampire.Skills[(int)Persuasion].Dots;
            socializeDots.Value         = vampire.Skills[(int)Socialize].Dots;
            streetwiseDots.Value        = vampire.Skills[(int)Streetwise].Dots;
            subterfugeDots.Value        = vampire.Skills[(int)Subterfuge].Dots;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e) {
            if(vampire.Name == "") {
                vampire.Name = "Untitled";
            }

            if(whichVampire < 0) {
                City.characters.Add(vampire);
            }
            else {
                City.characters[whichVampire] = vampire;
            }

            parent.soil();
            parent.refresh();
            this.Close();
        }

        private void nameField_TextChanged(object sender, TextChangedEventArgs e) {
            vampire.Name = nameField.Text;
        }

        private void maskField_TextChanged(object sender, TextChangedEventArgs e) {
            vampire.Mask = maskField.Text;
        }

        private void clanBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            vampire.Clan = (Clan)clanBox.SelectedIndex;
        }

        private void potencyDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Potency.Dots = (int)potencyDots.Value;
        }

        private void playerField_TextChanged(object sender, TextChangedEventArgs e) {
            vampire.Player = playerField.Text;
        }

        private void dirgeField_TextChanged(object sender, TextChangedEventArgs e) {
            vampire.Dirge = dirgeField.Text;
        }

        private void covenBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            vampire.Covenant = (Coven)covenBox.SelectedIndex;
        }

        private void humanityDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Humanity.Dots = (int)humanityDots.Value;
        }

        private void conceptField_TextChanged(object sender, TextChangedEventArgs e) {
            vampire.Concept = conceptField.Text;
        }

        private void biographyField_TextChanged(object sender, TextChangedEventArgs e) {
            vampire.Biography = biographyField.Text;
        }

        private void intelligenceDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Attributes[(int)Intelligence].Dots = (int)intelligenceDots.Value;
        }

        private void witsDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Attributes[(int)Wits].Dots = (int)witsDots.Value;
        }

        private void resolveDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Attributes[(int)Resolve].Dots = (int)resolveDots.Value;
        }

        private void strengthDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Attributes[(int)Strength].Dots = (int)strengthDots.Value;
        }

        private void dexterityDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Attributes[(int)Dexterity].Dots = (int)dexterityDots.Value;
        }

        private void staminaDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Attributes[(int)Stamina].Dots = (int)staminaDots.Value;
        }

        private void presenceDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Attributes[(int)Presence].Dots = (int)presenceDots.Value;
        }

        private void manipulationDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Attributes[(int)Manipulation].Dots = (int)manipulationDots.Value;
        }

        private void composureDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Attributes[(int)Composure].Dots = (int)composureDots.Value;
        }

        private void academicsDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Academics].Dots = (int)academicsDots.Value;
        }

        private void computerDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Computer].Dots = (int)computerDots.Value;
        }

        private void craftsDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Crafts].Dots = (int)craftsDots.Value;
        }

        private void investigationDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Investigation].Dots = (int)investigationDots.Value;
        }

        private void medicineDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Medicine].Dots = (int)medicineDots.Value;
        }

        private void occultDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Occult].Dots = (int)occultDots.Value;
        }

        private void politicsDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Politics].Dots = (int)politicsDots.Value;
        }

        private void scienceDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Science].Dots = (int)scienceDots.Value;
        }

        private void athleticsDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Athletics].Dots = (int)athleticsDots.Value;
        }

        private void brawlDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Brawl].Dots = (int)brawlDots.Value;
        }

        private void driveDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Drive].Dots = (int)driveDots.Value;
        }

        private void firearmsDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Firearms].Dots = (int)firearmsDots.Value;
        }

        private void larcenyDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Larceny].Dots = (int)larcenyDots.Value;
        }

        private void stealthDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Stealth].Dots = (int)stealthDots.Value;
        }

        private void survivalDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Survival].Dots = (int)survivalDots.Value;
        }

        private void weaponryDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Weaponry].Dots = (int)weaponryDots.Value;
        }

        private void animalKenDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)AnimalKen].Dots = (int)animalKenDots.Value;
        }

        private void empathyDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Empathy].Dots = (int)empathyDots.Value;
        }

        private void expressionDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Expression].Dots = (int)expressionDots.Value;
        }

        private void intimidationDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Intimidation].Dots = (int)intimidationDots.Value;
        }

        private void persuasionDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Persuasion].Dots = (int)persuasionDots.Value;
        }

        private void socializeDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Socialize].Dots = (int)socializeDots.Value;
        }

        private void streetwiseDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Streetwise].Dots = (int)streetwiseDots.Value;
        }

        private void subterfugeDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            vampire.Skills[(int)Subterfuge].Dots = (int)subterfugeDots.Value;
        }
    }
}
