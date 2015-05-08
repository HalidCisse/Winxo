using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.Security.Enums
{

    /// <summary>
    /// Represent L'Espace UI de L'Utilisateur
    /// </summary>
    public enum UserSpace
    {
        /// <summary>
        /// Espace Administrateur
        /// </summary>
        [Description("Espace Administrateur")]
        AdminSpace,


        /// <summary>
        /// Espace Staff ou Enseignant
        /// </summary>
        [Description("Espace Secretaire")]
        SecretaireSpace,


        /// <summary>
        /// Espace Economat
        /// </summary>
        [Description("Espace Pompiste")]
        PompisteSpace,

       
    }
}
