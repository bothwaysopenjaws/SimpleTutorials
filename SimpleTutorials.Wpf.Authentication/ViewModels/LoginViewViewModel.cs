using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SimpleTutorials.Core;
using SimpleTutorials.DbLib.Model;

namespace SimpleTutorials.Wpf.Authentication.ViewModels
{
    /// <summary>
    /// VM de <see cref="SimpleTutorials.Wpf.Authentication.Views.LoginView"/>
    /// </summary>
    internal class LoginViewViewModel : ObservableObject
    {
        #region Fields

        /// <summary>
        /// Utilisateur
        /// </summary>
        private string? _UserName;

        /// <summary>
        /// Mot de passe
        /// </summary>
        private string? _Password;

        /// <summary>
        /// Message
        /// </summary>
        private string? _Message;

        /// <summary>
        /// Indique si l'utilisateur est connecté ou non.
        /// </summary>
        private bool? _IsLoggedIn;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou défini <see cref="_UserName"/>
        /// </summary>
        public string? UserName { get => _UserName; set => _UserName = value; }

        /// <summary>
        /// Obtient ou défini <see cref="_Password"/>
        /// </summary>
        public string? Password { get => _Password; set => _Password = value; }

        /// <summary>
        /// Obtient ou défini <see cref="_Message"/>
        /// Vu qu'on veut actualisé la vue lors du changement, on utilise <see cref="ObservableObject.SetProperty{T}(string, ref T, T, bool)"/>
        /// </summary>
        public string? Message { get => _Message; set => SetProperty(nameof(Message), ref _Message, value); }
        
        /// <summary>
        /// Obtient ou défini <see cref="_IsLoggedIn"/>
        /// </summary>
        public bool? IsLoggedIn { get => _IsLoggedIn; private set => SetProperty(nameof(IsLoggedIn), ref _IsLoggedIn, value); }

        #endregion


        #region Constructors

        /// <summary>
        ///  Constructeur
        /// </summary>
        public LoginViewViewModel()
        {
            IsLoggedIn = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Méthode de d'authentification d'un utilisateur
        /// </summary>
        internal void Authenticate()
        {
            // Outil de hashage
            PasswordHasher hasher = new PasswordHasher();

            PasswordVerificationResult result = PasswordVerificationResult.Failed;

            // L'utilisateur récupéré
            User? user = null;
            // On recherche l'utilisateur par son identifiant
            using (SimpleTutorialsDBContext context = new())
                user = context.Users.FirstOrDefault(userTemp => userTemp.UserName.Equals(UserName));

            // Si il n'existe pas, on renvoie une erreur
            if (user == null)
                Message = "Impossible de trouver l'utilisateur";
            else
                result = hasher.VerifyHashedPassword(user.HashedPassword, Password);

            switch (result)
            {
                case PasswordVerificationResult.Failed:
                    Message = "Mot de passe incorrect";
                    break;
                case PasswordVerificationResult.Success:
                    // On défini le logging à true. La vue observe cette propriété et va se cacher si IsLogging = true.
                    IsLoggedIn = true;
                    break;
                default:
                    break;
            }
        }

        #endregion


    }
}
