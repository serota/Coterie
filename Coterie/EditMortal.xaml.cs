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
    /// Interaction logic for NewMortal.xaml
    /// </summary>
    public partial class EditMortal : Window {
        Mortal mortal;
        int whichMortal;
        MainWindow parent;

        public EditMortal(MainWindow parent, int whichMortal) {
            mortal = new Mortal();

            InitializeComponent();

            this.whichMortal = whichMortal;
            this.parent = parent;

            if (whichMortal < 0) {
                mortal = new Mortal();
            }
            else {
                mortal = (Mortal)City.characters[whichMortal];
                mortalWindow.Title = mortal.Name;
            }

            nameField.Text = mortal.Name;
            nameField.Focus();
            nameField.SelectAll();

            maskField.Text = mortal.Mask;

            playerField.Text = mortal.Player;
            dirgeField.Text = mortal.Dirge;
            humanityDots.Value = mortal.Humanity.Dots;

            conceptField.Text = mortal.Concept;
            biographyField.Text = mortal.Biography;

            intelligenceDots.Value      = mortal.Attributes[(int)Intelligence].Dots;
            witsDots.Value              = mortal.Attributes[(int)Wits].Dots;
            resolveDots.Value           = mortal.Attributes[(int)Resolve].Dots;

            strengthDots.Value          = mortal.Attributes[(int)Strength].Dots;
            dexterityDots.Value         = mortal.Attributes[(int)Dexterity].Dots;
            staminaDots.Value           = mortal.Attributes[(int)Stamina].Dots;

            presenceDots.Value          = mortal.Attributes[(int)Presence].Dots;
            manipulationDots.Value      = mortal.Attributes[(int)Manipulation].Dots;
            composureDots.Value         = mortal.Attributes[(int)Composure].Dots;

            academicsDots.Value         = mortal.Skills[(int)Academics].Dots;
            computerDots.Value          = mortal.Skills[(int)Computer].Dots;
            craftsDots.Value            = mortal.Skills[(int)Crafts].Dots;
            investigationDots.Value     = mortal.Skills[(int)Investigation].Dots;
            medicineDots.Value          = mortal.Skills[(int)Medicine].Dots;
            occultDots.Value            = mortal.Skills[(int)Occult].Dots;
            politicsDots.Value          = mortal.Skills[(int)Politics].Dots;
            scienceDots.Value           = mortal.Skills[(int)Science].Dots;

            athleticsDots.Value         = mortal.Skills[(int)Athletics].Dots;
            brawlDots.Value             = mortal.Skills[(int)Brawl].Dots;
            driveDots.Value             = mortal.Skills[(int)Drive].Dots;
            firearmsDots.Value          = mortal.Skills[(int)Firearms].Dots;
            larcenyDots.Value           = mortal.Skills[(int)Larceny].Dots;
            stealthDots.Value           = mortal.Skills[(int)Stealth].Dots;
            survivalDots.Value          = mortal.Skills[(int)Survival].Dots;
            weaponryDots.Value          = mortal.Skills[(int)Weaponry].Dots;

            animalKenDots.Value         = mortal.Skills[(int)AnimalKen].Dots;
            empathyDots.Value           = mortal.Skills[(int)Empathy].Dots;
            expressionDots.Value        = mortal.Skills[(int)Expression].Dots;
            intimidationDots.Value      = mortal.Skills[(int)Intimidation].Dots;
            persuasionDots.Value        = mortal.Skills[(int)Persuasion].Dots;
            socializeDots.Value         = mortal.Skills[(int)Socialize].Dots;
            streetwiseDots.Value        = mortal.Skills[(int)Streetwise].Dots;
            subterfugeDots.Value        = mortal.Skills[(int)Subterfuge].Dots;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e) {
            if(mortal.Name == "") {
                mortal.Name = "Untitled";
            }

            if(whichMortal < 0) {
                City.characters.Add(mortal);
            }
            else {
                City.characters[whichMortal] = mortal;
            }

            parent.makeDirty();
            parent.refresh();
            this.Close();
        }

        private void nameField_TextChanged(object sender, TextChangedEventArgs e) {
            mortal.Name = nameField.Text;
        }

        private void maskField_TextChanged(object sender, TextChangedEventArgs e) {
            mortal.Mask = maskField.Text;
        }

        private void playerField_TextChanged(object sender, TextChangedEventArgs e) {
            mortal.Player = playerField.Text;
        }

        private void dirgeField_TextChanged(object sender, TextChangedEventArgs e) {
            mortal.Dirge = dirgeField.Text;
        }

        private void humanityDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Humanity.Dots = (int)humanityDots.Value;
        }

        private void conceptField_TextChanged(object sender, TextChangedEventArgs e) {
            mortal.Concept = conceptField.Text;
        }

        private void biographyField_TextChanged(object sender, TextChangedEventArgs e) {
            mortal.Biography = biographyField.Text;
        }

        private void intelligenceDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Attributes[(int)Intelligence].Dots = (int)intelligenceDots.Value;
        }

        private void witsDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Attributes[(int)Wits].Dots = (int)witsDots.Value;
        }

        private void resolveDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Attributes[(int)Resolve].Dots = (int)resolveDots.Value;
        }

        private void strengthDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Attributes[(int)Strength].Dots = (int)strengthDots.Value;
        }

        private void dexterityDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Attributes[(int)Dexterity].Dots = (int)dexterityDots.Value;
        }

        private void staminaDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Attributes[(int)Stamina].Dots = (int)staminaDots.Value;
        }

        private void presenceDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Attributes[(int)Presence].Dots = (int)presenceDots.Value;
        }

        private void manipulationDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Attributes[(int)Manipulation].Dots = (int)manipulationDots.Value;
        }

        private void composureDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Attributes[(int)Composure].Dots = (int)composureDots.Value;
        }

        private void academicsDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Academics].Dots = (int)academicsDots.Value;
        }

        private void computerDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Computer].Dots = (int)computerDots.Value;
        }

        private void craftsDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Crafts].Dots = (int)craftsDots.Value;
        }

        private void investigationDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Investigation].Dots = (int)investigationDots.Value;
        }

        private void medicineDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Medicine].Dots = (int)medicineDots.Value;
        }

        private void occultDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Occult].Dots = (int)occultDots.Value;
        }

        private void politicsDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Politics].Dots = (int)politicsDots.Value;
        }

        private void scienceDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Science].Dots = (int)scienceDots.Value;
        }

        private void athleticsDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Athletics].Dots = (int)athleticsDots.Value;
        }

        private void brawlDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Brawl].Dots = (int)brawlDots.Value;
        }

        private void driveDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Drive].Dots = (int)driveDots.Value;
        }

        private void firearmsDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Firearms].Dots = (int)firearmsDots.Value;
        }

        private void larcenyDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Larceny].Dots = (int)larcenyDots.Value;
        }

        private void stealthDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Stealth].Dots = (int)stealthDots.Value;
        }

        private void survivalDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Survival].Dots = (int)survivalDots.Value;
        }

        private void weaponryDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Weaponry].Dots = (int)weaponryDots.Value;
        }

        private void animalKenDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)AnimalKen].Dots = (int)animalKenDots.Value;
        }

        private void empathyDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Empathy].Dots = (int)empathyDots.Value;
        }

        private void expressionDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Expression].Dots = (int)expressionDots.Value;
        }

        private void intimidationDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Intimidation].Dots = (int)intimidationDots.Value;
        }

        private void persuasionDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Persuasion].Dots = (int)persuasionDots.Value;
        }

        private void socializeDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Socialize].Dots = (int)socializeDots.Value;
        }

        private void streetwiseDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Streetwise].Dots = (int)streetwiseDots.Value;
        }

        private void subterfugeDots_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            mortal.Skills[(int)Subterfuge].Dots = (int)subterfugeDots.Value;
        }
    }
}
