﻿using System.ComponentModel;

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
