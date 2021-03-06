﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Web.Security;
using Bytes2you.Validation;
using CLib;
using Core.Model;
using Core.Model.Customer.Entity;
using Core.Model.Hr.Entity;
using Core.Model.Security.Entity;
using Core.Model.Shared.Entity;
using Core.Model.Shared.Views;

namespace Core.Managers
{
    public sealed class CustomersManager
    {

        #region CRUD

        /// <summary>
        /// Represente un enseignant, proff, staff, qui a la possibilite de se connecter a l'Eschool
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <exception cref="InvalidOperationException">CAN_NOT_CREAT_STAFF_PROFILE</exception>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = SecurityClearances.CustomerWrite)]
        public bool AddCustomer(Customer newCustomer) 
        {
            Guard.WhenArgument(newCustomer.Person.FullName, "CUSTOMER_NAME_CAN_NOT_BE_EMPTY").IsNullOrEmpty().IsEqual("Inconnue").Throw();

            using (var db = new WinxoContext())
            {
                if (newCustomer.CustomerGuid == Guid.Empty)
                    newCustomer.CustomerGuid = Guid.NewGuid();
                if (newCustomer.Person.PersonGuid == Guid.Empty)
                    newCustomer.Person.PersonGuid = Guid.NewGuid();

                // ReSharper disable once PossibleNullReferenceException
                var userTrace = (Guid) Membership.GetUser().ProviderUserKey;
                newCustomer.DateAdded = DateTime.Now;
                newCustomer.AddUserGuid = userTrace;
                newCustomer.LastEditDate = DateTime.Now;
                newCustomer.LastEditUserGuid = userTrace;

                db.Set<Person>().Add(newCustomer.Person);
                db.Customers.Add(newCustomer);
                return db.SaveChanges() > 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="myCustomer"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = SecurityClearances.StaffWrite)]
        public bool UpdateCustomer(Customer myCustomer)
        {
            using (var db = new WinxoContext())
            {
                // ReSharper disable once PossibleNullReferenceException
                var userTrace = (Guid)Membership.GetUser().ProviderUserKey;                
                myCustomer.LastEditDate = DateTime.Now;
                myCustomer.LastEditUserGuid = userTrace;

                db.Customers.Attach(myCustomer);
                db.Entry(myCustomer).State = EntityState.Modified;

                db.Set<Person>().Attach(myCustomer.Person);
                db.Entry(myCustomer.Person).State = EntityState.Modified;

                return db.SaveChanges() > 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = SecurityClearances.StaffDelete)]
        public bool DeleteStaff(Guid customerGuid)
        {
            using (var db = new WinxoContext())
            {
                var theMan = db.Customers.Find(customerGuid);

                Guard.WhenArgument(theMan, "CAN_NOT_FIND_STAFF_REFERENCE").IsNull().Throw();
                
                theMan.Person.DeleteDate = DateTime.Now;
                theMan.Person.IsDeleted = true;
                theMan.Person.DeleteUserGuid = Guid.Empty;

                db.Customers.Attach(theMan);
                db.Entry(theMan).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        #endregion



        #region HELPERS


        /// <summary>
        /// Renvoi la list des Staff 
        /// </summary>
        /// <param name="searchString">Parametre de Recherche</param>
        /// <param name="maxResult">Nombre max de Resultat</param>
        /// <returns></returns>        
        public HashSet<SearchCard> Search(string searchString, int maxResult = 7)
        {
            searchString = searchString.Trim();
            List<Guid> searchResult;

            if (!string.IsNullOrEmpty(searchString))
                using (var db = new WinxoContext())
                {
                    searchResult = db.Customers.Where(s => (s.Person.FirstName + " " + s.Person.LastName).Contains(searchString) ||
                                                         (s.Person.LastName + " " + s.Person.FirstName).Contains(searchString) ||
                                                         s.Person.EmailAdress.Equals(searchString, StringComparison.CurrentCultureIgnoreCase) ||                                                        
                                                         s.Matricule.Equals(searchString, StringComparison.CurrentCultureIgnoreCase)
                        ).Take(maxResult).Select(s => s.CustomerGuid).ToList();
                }
            else{
                using (var db = new WinxoContext())
                    searchResult = db.Customers.Take(7).Select(s => s.CustomerGuid).ToList();                
            }

            var results = new HashSet<SearchCard>();

            foreach (var result in searchResult)
                results.Add(new SearchCard(result, true));

            return results;
        }

       
        public Staff GetStaffByGuid(Guid staffGuid)
        {
            using (var db = new WinxoContext())
                return db.Staffs.Include(s => s.Person).FirstOrDefault(s => s.StaffGuid == staffGuid);
        }

        
        public IEnumerable GetAllCustomers()
        {
            using (var db = new WinxoContext())
                return db.Customers.Include(s => s.Person).OrderBy(s => s.Person.FirstName).ToList();
        }

       
        public Person GetPerson(Guid personGuid)
        {
            using (var db = new WinxoContext())
                return db.Set<Person>().Find(personGuid);
        }

       
        public Staff GetCustomerByEmail(string email)
        {
            using (var db = new WinxoContext())
                return db.Staffs.Include(s => s.Person).FirstOrDefault(s => s.Person.EmailAdress.Equals(email));
        }

        
        public Customer GetCustomer(string customerMatricule)
        {
            using (var db = new WinxoContext())
                return db.Customers.Include(s => s.Person).FirstOrDefault(s => s.Matricule.Equals(customerMatricule));
        }

     
        public Customer GetCustomer(Guid customerGuid)
        {
            using (var db = new WinxoContext())
                return db.Customers.Include(s => s.Person).FirstOrDefault(s => s.CustomerGuid == customerGuid);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        public bool CustomerIdExist(string staffId)
        {
            using (var db = new WinxoContext())
            {
                return db.Staffs.Any(s => s.Matricule == staffId);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffEMail"></param>
        /// <returns></returns>
        ///[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public bool CustomerEmailExist(string staffEMail)
        {
            using (var db = new WinxoContext())
            {
                return db.Staffs.Any(s => s.Person.EmailAdress.Equals(staffEMail));
            }
        }

        
        public string NewMatricule()
        {
            string newStaffId;

            do newStaffId = "S" + RandomHelper.GetRandLetters(1) + "-" + DateTime.Today.Month + DateTime.Today.Year.ToString().Substring(2) + "-" + RandomHelper.GetRandNum(4);
            while (
                     CustomerIdExist(newStaffId)
                  );

            return newStaffId;
        }

                    
        /// <summary>
        /// Return les nationalites des etudiants ainsi que des staffs
        /// </summary>
        /// <returns></returns>
        public IEnumerable AllNationalities()
        {
            var nationalities = new List<string>();

            using (var db = new WinxoContext())
                nationalities.AddRange(db.Set<Person>().Select(p => p.Nationality).ToList());

            if (nationalities.Count != 0) return nationalities.Distinct();

            nationalities.Add("Maroc");
            nationalities.Add("Mali");
            nationalities.Add("US");
            nationalities.Add("France");
            nationalities.Add("Senegal");
            nationalities.Add("Algerie");
            nationalities.Add("Liberia");
            nationalities.Add("Guinee");
            nationalities.Add("Afrique Du Sud");
            nationalities.Add("Nigeria");
            nationalities.Add("Soudan");
            nationalities.Add("Gambie");
            nationalities.Add("Congo");
            nationalities.Add("Burkina Fasso");

            return nationalities.Distinct();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable AllBirthPlaces()
        {
            var birthPlace = new List<string>();

            using (var db = new WinxoContext())
            {
                var studentBp = (from s in db.Customers.ToList() where s.Person.BirthPlace != null select s.Person.BirthPlace).ToList().Distinct().ToList();
                birthPlace.AddRange(studentBp);

                var staffBp = (from s in db.Staffs.ToList() where s.Person.BirthPlace != null select s.Person.BirthPlace).ToList().Distinct().ToList();
                birthPlace.AddRange(staffBp);
            }

            if (birthPlace.Count != 0) return birthPlace.Distinct();

            birthPlace.Add("Rabat");
            birthPlace.Add("Casablanca");
            birthPlace.Add("Bamako");
            birthPlace.Add("Toumbouctou");
            birthPlace.Add("Tayba");
            birthPlace.Add("Dakar");

            return birthPlace;
        }

    

        #endregion



        #region internal Static


        internal static Staff StaticGetStaffByGuid(Guid staffGuid)
        {
            try
            {
                using (var db = new WinxoContext())
                {
                    var x = db.Staffs.Include(s => s.Person).FirstOrDefault(s => s.StaffGuid == staffGuid);
                    return x;
                }
            }
            catch (Exception exception)
            {
                DebugHelper.WriteException(exception);
                //throw;
            }
            return null;
        }



        #endregion



    }
}
