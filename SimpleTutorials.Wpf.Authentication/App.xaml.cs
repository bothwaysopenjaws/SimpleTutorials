using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleTutorials.DbLib.Model;

namespace SimpleTutorials.Wpf.Authentication;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    #region Fields

    private bool _IsLoggedIn;


    #endregion


    #region Properties

    public bool IsLoggedIn { get => _IsLoggedIn; set => _IsLoggedIn = value; }

    #endregion

    #region Constructors


    /// <summary>
    /// Surcharge de l'instanciation de l'App.
    /// On s'en sert pour détruire et recréé la base de données.
    /// </summary>
    public App() : base() 
    {
        using (SimpleTutorialsDBContext context = new())
        {
            // On supprime la base de données
            context.Database.EnsureDeleted();

            // Puis on la recréé.
            context.Database.EnsureCreated();

            // Ajout des utilisateurs de tests.
            AddMockupUsers();
        }
    }


    #endregion

    #region Methods

    #region Mockups datas

    /// <summary>
    /// Génère des utilisateurs de test.
    /// </summary>
    private void AddMockupUsers()
    {

        // Outil de hashage
        PasswordHasher hasher = new PasswordHasher();

        User userTest = new User()
        {
            UserName = "Test",
            HashedPassword = hasher.HashPassword("test"),
        };

        using (SimpleTutorialsDBContext context = new())
        {
            // On supprime la base de données
            context.Users.Add(userTest);
            context.SaveChanges();
        }
    }

    #endregion

    #endregion

}
