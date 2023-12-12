using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTutorials.DbLib.Model
{

    /// <summary>
    /// Classe d'un utilisateur
    /// </summary>
    public class User
    {
        #region Fields

        /// <summary>
        /// Identifiant
        /// </summary>
        private int _Identifier;

        /// <summary>
        /// Identifiant de connexion
        /// </summary>
        private string _UserName;

        /// <summary>
        /// Mot de passe
        /// </summary>
        private string _HashedPassword;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou défini <see cref="_Identifier"/>
        /// </summary>
        [Key]
        public int Identifier { get => _Identifier; set => _Identifier = value; }

        /// <summary>
        /// Obtient ou défini <see cref="_UserName"/>
        /// </summary>
        [Required]
        public string UserName { get => _UserName; set => _UserName = value; }

        /// <summary>
        /// Obtient ou défini <see cref="_Password"/>
        /// </summary>
        [Required]
        public string HashedPassword { get => _HashedPassword; set => _HashedPassword = value; }

        #endregion

    }


}
