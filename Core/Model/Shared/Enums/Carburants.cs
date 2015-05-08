using System.ComponentModel;

namespace Core.Model.Shared.Enums
{
    internal enum Carburants
    {
        /// <summary>
        /// Essence
        /// </summary>
        [Description("Essence")]
        Essence,
        
        /// <summary>
        /// GasOil50
        /// </summary>
        [Description("GasOil50")]
        GasOil50,

        /// <summary>
        /// GasOilNormal
        /// </summary>
        [Description("GasOilNormal")]
        GasOilNormal,

        /// <summary>
        /// Super
        /// </summary>
        [Description("Super")]
        Super,

        /// <summary>
        /// SansPlomb
        /// </summary>
        [Description("SansPlomb")]
        SansPlomb

    }
}
