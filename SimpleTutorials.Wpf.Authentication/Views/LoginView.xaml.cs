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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SimpleTutorials.Wpf.Authentication.ViewModels;

namespace SimpleTutorials.Wpf.Authentication.Views
{
    /// <summary>
    /// Logique d'interaction pour LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {

        #region Constructors

        /// <summary>
        /// Constructeur
        /// Initialise le dataContext
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
            this.DataContext = new LoginViewViewModel();
        }
        #endregion

        #region Methods


        /// <summary>
        /// Met à jour le mot de passe du VM associé
        /// </summary>
        /// <param name="sender">le contrôle qui envoie l'event, ici une passwordbox</param>
        /// <param name="e">les éventuels arguments</param>
        private void PasswordBoxLogin_PasswordChanged(object sender, RoutedEventArgs e)
            => ((LoginViewViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;

        /// <summary>
        /// Gère la tentative de login
        /// </summary>
        /// <param name="sender">Bouton qui envoie la demande</param>
        /// <param name="e">Les éventuels arguments</param>
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
            => ((LoginViewViewModel)this.DataContext).Authenticate();

        #endregion


    }
}
