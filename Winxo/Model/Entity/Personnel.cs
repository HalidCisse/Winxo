using System;
using System.ComponentModel.DataAnnotations;
using Winxo.Model.Enums;

namespace Winxo.Model.Entity
{
    internal class Personnel
    {
        [Key]
        public Guid PersonnelGuid { get; set; }


        /// <summary>
        /// Title
        /// </summary>
        public PersonTitles Title { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// PhotoIdentity
        /// </summary>
        public byte[] PhotoIdentity { get; set; }

        /// <summary>
        /// HealthState
        /// </summary>
        public HealthStates HealthState { get; set; }

        /// <summary>
        /// Nationality
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// IdentityNumber
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// BirthDate
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// BirthPlace
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// EmailAdress
        /// </summary>
        public string EmailAdress { get; set; }

        /// <summary>
        /// HomeAdress
        /// </summary>
        public string HomeAdress { get; set; }
       
        /// <summary>
        /// FullName
        /// </summary>
        public string FullName => FirstName.Substring(0, 1).ToUpper() + FirstName.Substring(1).ToLower() + " " + LastName.Substring(0, 1).ToUpper() + LastName.Substring(1).ToLower();

        /// <summary>
        /// StaffId
        /// </summary>
        public string Matricule { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        public string Fonction { get; set; }
       
        /// <summary>
        /// Qualification
        /// </summary>
        public string Qualification { get; set; }

        /// <summary>
        /// Qualification
        /// </summary>
        public string Diploma { get; set; }

        /// <summary>
        /// NiveauDiplome
        /// </summary>
        public string DiplomaLevel { get; set; }

        /// <summary>
        /// Experience du Staff
        /// </summary>
        public int Experiences { get; set; }

        /// <summary>
        /// Ancien job
        /// </summary>
        public string FormerJob { get; set; }

        /// <summary>
        /// Senior
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// HiredDate
        /// </summary>
        public DateTime? HiredDate { get; set; }

       


    }
}
