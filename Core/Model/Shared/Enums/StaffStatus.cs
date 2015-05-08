using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Model.Shared.Enums
{
    /// <summary>
    /// Status d'un Staff
    /// </summary>
    public enum StaffStatus
    {
        /// <summary>
        /// Actif
        /// </summary>
        [Description("Actif")]
        Actif,

        /// <summary>
        /// Non Actif
        /// </summary>
        [Description("Non Actif")]
        NonActif,

        /// <summary>
        /// Licencier
        /// </summary>
        [Description("Licencier")]
        Licencier,

        /// <summary>
        /// Irregulier
        /// </summary>
        [Description("Irregulier")]
        Irregulier,

        /// <summary>
        /// Suspendue
        /// </summary>
        [Description("Suspendue")]
        Suspendue


    }
}
