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
    /// <summary>
    /// Interaction logic for Prompt.xaml
    /// </summary>
    public partial class NewRole : Window {
        private string roleName;

        public string RoleName {
            get {
                if(roleName == "")
                {
                    return "Untitled";
                }
                return roleName;
            }
        }

        public NewRole() {
            InitializeComponent();

            roleName = "";

            nameField.Focus();
        }

        private void okButton_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
            this.Close();
        }

        private void nameField_TextChanged(object sender, TextChangedEventArgs e) {
            roleName = nameField.Text;
        }
    }
}
