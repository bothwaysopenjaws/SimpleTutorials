using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SimpleTutorials.DbLib.Model;

/// <summary>
/// Contexte de la solution. Hérite du <see cref="DbContext"/>  d'EF core
/// </summary>
public class SimpleTutorialsDBContext : DbContext
{
    #region Properties

    /// <summary>
    /// Obtient ou défini la liste des utilisateurs
    /// </summary>
    public DbSet<User> Users { get; set; }

    #endregion

    #region Methods

    /// <summary>
    /// Surcharge de la méthode OnConfiguring
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        // On récupère le fichier la chaîne de connexion présente dans le fichier App.config du projet WPF
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString);


    }
    #endregion

}
