using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Web.Security;
using Bytes2you.Validation;
using CLib;
using Core.Model;
using Core.Model.Security.Entity;
using Core.Model.Shared.Entity;



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


        ///// <summary>
        ///// Renvoi la list des Staff 
        ///// </summary>
        ///// <param name="searchString">Parametre de Recherche</param>
        ///// <param name="maxResult">Nombre max de Resultat</param>
        ///// <returns></returns>        
        //public HashSet<SearchCard> Search(string searchString, int maxResult = 7)
        //{
        //    searchString = searchString.Trim();
        //    List<Guid> searchResult;

        //    if (!string.IsNullOrEmpty(searchString))

        //        using (var db = new WinxoContext())
        //        {
        //            searchResult = db.Staffs.Where(s => (s.Person.FirstName + " " + s.Person.LastName).Contains(searchString) ||
        //                                                 (s.Person.LastName + " " + s.Person.FirstName).Contains(searchString) ||
        //                                                 s.Person.EmailAdress.Equals(searchString, StringComparison.CurrentCultureIgnoreCase) ||
        //                                                 s.PositionPrincipale.Equals(searchString, StringComparison.CurrentCultureIgnoreCase) ||
        //                                                 s.DepartementPrincipale.Equals(searchString, StringComparison.CurrentCultureIgnoreCase) ||
        //                                                 s.Qualification.Equals(searchString, StringComparison.CurrentCultureIgnoreCase) ||
        //                                                 s.Matricule.Equals(searchString, StringComparison.CurrentCultureIgnoreCase)
        //                ).Take(maxResult).Select(s => s.StaffGuid).ToList();
        //        }
        //    else
        //    {
        //        using (var db = new WinxoContext())
        //            searchResult = db.Staffs.Take(7).Select(s => s.StaffGuid).ToList();



        //        //using (var mc = new WinxoContext())
        //        //    searchResult = mc.SchoolFees.Where(s => s.DueDate <= DateTime.Today && !s.IsPaid).Select(f => f.StudentGuid).Distinct().Take(30).ToList();
        //        //if (!searchResult.Any())
        //        //    using (var db = new WinxoContext())
        //        //        searchResult = db.Student.Take(maxResult).Select(s => s.StudentGuid).ToList();
        //    }

        //    var results = new HashSet<SearchCard>();

        //    foreach (var result in searchResult)
        //        results.Add(new SearchCard(result, true));

        //    return results;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="staffGuid"></param>
        ///// <returns></returns>
        //public Staff GetStaffByGuid(Guid staffGuid)
        //{
        //    using (var db = new WinxoContext())
        //        return db.Staffs.Include(s => s.Person).FirstOrDefault(s => s.StaffGuid == staffGuid);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable GetAllStaffs()
        //{
        //    using (var db = new WinxoContext())
        //        return db.Staffs.Include(s => s.Person).OrderBy(s => s.Person.FirstName).ToList();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="personGuid"></param>
        ///// <returns></returns>
        //public Person GetPerson(Guid personGuid)
        //{
        //    using (var db = new WinxoContext())
        //        return db.Set<Person>().Find(personGuid);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public Staff GetStaffByEmail(string email)
        //{
        //    using (var db = new WinxoContext())
        //        return db.Staffs.Include(s => s.Person).FirstOrDefault(s => s.Person.EmailAdress.Equals(email));
        //}

        ///// <summary>
        ///// Get Staff from Its Matricule
        ///// </summary>
        ///// <param name="staffMatricule"></param>
        ///// <returns></returns>
        //public Staff GetStaff(string staffMatricule)
        //{
        //    using (var db = new WinxoContext())
        //        return db.Staffs.Include(s => s.Person).FirstOrDefault(s => s.Matricule.Equals(staffMatricule));
        //}

        ///// <summary>
        ///// Dictionnaire des Staffs
        ///// </summary>
        ///// <returns>Une Dictionaire</returns>        
        //public Dictionary<string, Guid> GetAllStaffsDictionary()
        //{
        //    using (var db = new WinxoContext())
        //        return db.Staffs.OrderByDescending(a => a.HiredDate)
        //            .ToDictionary(a => a.Person.FirstName + " " + a.Person.LastName, a => a.StaffGuid);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="depName"></param>
        ///// <returns></returns>
        //public List<Staff> GetDepStaffs(string depName = null)
        //{
        //    using (var db = new WinxoContext())
        //        return depName == null
        //            ? db.Staffs.Where(s => string.IsNullOrEmpty(s.DepartementPrincipale)).OrderBy(s => s.Person.LastName).ToList()
        //            : db.Staffs.Where(s => s.DepartementPrincipale == depName).OrderBy(s => s.Person.LastName).ToList();
        //}

        ///// <summary>
        ///// Renvoi la list des departements avec leur employer
        ///// </summary>
        ///// <returns></returns>
        //public List<DepStaffCard> GetDepStaffsCard()
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        var depStaffCardList = new ConcurrentBag<DepStaffCard>();

        //        var nd = new DepStaffCard("");
        //        if (nd.StaffsList.Any()) { depStaffCardList.Add(nd); }

        //        var deps = (db.Staffs.Where(s => !s.Person.IsDeleted).ToList()
        //            .Where(s => string.IsNullOrEmpty(s.DepartementPrincipale) == false)
        //            .Select(s => s.DepartementPrincipale)).Distinct().ToList();

        //        Parallel.ForEach(deps, dep => {
        //            depStaffCardList.Add(new DepStaffCard(dep));
        //        });

        //        return depStaffCardList.Any() ? depStaffCardList.OrderBy(d => d.DepartementName).ToList() : null;
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="staffId"></param>
        ///// <returns></returns>
        //public string GetStaffFullName(string staffId)
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        return db.Staffs.First(s => s.Matricule == staffId).Person.FullName;
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="staffId"></param>
        ///// <returns></returns>
        //public bool StaffIdExist(string staffId)
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        return db.Staffs.Any(s => s.Matricule == staffId);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="staffEMail"></param>
        ///// <returns></returns>
        /////[PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        //public bool StaffEmailExist(string staffEMail)
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        return db.Staffs.Any(s => s.Person.EmailAdress.Equals(staffEMail));
        //    }
        //}

        ///// <summary>
        ///// Nouveau Numero de Staff Unique
        ///// </summary>       
        ///// <returns>Renvoi un nouveau Numéro de Staff Unique</returns>
        //public string GetNewStaffMatricule()
        //{
        //    string newStaffId;

        //    do newStaffId = "S" + RandomHelper.GetRandLetters(1) + "-" + DateTime.Today.Month + DateTime.Today.Year.ToString().Substring(2) + "-" + RandomHelper.GetRandNum(4);
        //    while (
        //             StaffIdExist(newStaffId)
        //          );

        //    return newStaffId;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable AllDepartement()
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        var deps = (from s in db.Staffs.ToList() where s.DepartementPrincipale != null select s.DepartementPrincipale).Distinct().ToList();

        //        return deps;
        //    }
        //    //Deps.Count == 0 ? new List<string> { "Departement de Mathematique", "Departement de Chimie", "Departement de Physique" } :
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable AllStaffPositions()
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        var pos = (from s in db.Staffs.ToList() where !string.IsNullOrEmpty(s.PositionPrincipale) select s.PositionPrincipale).Distinct().ToList();

        //        return !pos.Any()
        //            ? new List<string>
        //            {
        //                "Professeur",
        //                "Enseignant",
        //                "Instructeur",
        //                "Conferencier",
        //                "Chef Departement",
        //                "Directeur General",
        //                "Directeur Financier",
        //                "Directeur Pedagogique",
        //                "Secretaire"
        //            }
        //            : pos;
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable AllStaffQualifications()
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        var quals = (from s in db.Staffs.ToList() where s.Qualification != null select s.Qualification).Distinct().ToList();

        //        return quals.Count == 0 ? new List<string> { "Engenieur Etat En Informatique", "Doctorat En Mathematique", "Master En Anglais" } : quals;
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable AllDepartements()
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        var deps = (from s in db.Employments.ToList() where !string.IsNullOrEmpty(s.Departement) select s.Departement).Distinct().ToList();

        //        return !deps.Any()
        //            ? new List<string>
        //            {
        //                "Departement de Mathematique",
        //                "Departement de Chimie",
        //                "Departement de Physique",
        //                "Departement de Market",
        //                "Departement de Geographie",
        //                "Departement de Economie"
        //            }
        //            : deps;
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable AllPositions()
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        var pos = (from s in db.Employments.ToList() where !string.IsNullOrEmpty(s.Position) select s.Position).Distinct().ToList();

        //        return !pos.Any()
        //            ? new List<string>
        //            {
        //                "Professeur",
        //                "Enseignant",
        //                "Instructeur",
        //                "Conferencier",
        //                "Chef Departement",
        //                "Directeur General",
        //                "Directeur Financier",
        //                "Directeur Pedagogique",
        //                "Secretaire"
        //            }
        //            : pos;
        //    }
        //}

        ///// <summary>
        ///// Return les nationalites des etudiants ainsi que des staffs
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable AllNationalities()
        //{
        //    var nationalities = new List<string>();

        //    using (var db = new WinxoContext())
        //        nationalities.AddRange(db.Set<Person>().Select(p => p.Nationality).ToList());

        //    if (nationalities.Count != 0) return nationalities.Distinct();

        //    nationalities.Add("Maroc");
        //    nationalities.Add("Mali");
        //    nationalities.Add("US");
        //    nationalities.Add("France");
        //    nationalities.Add("Senegal");
        //    nationalities.Add("Algerie");
        //    nationalities.Add("Liberia");
        //    nationalities.Add("Guinee");
        //    nationalities.Add("Afrique Du Sud");
        //    nationalities.Add("Nigeria");
        //    nationalities.Add("Soudan");
        //    nationalities.Add("Gambie");
        //    nationalities.Add("Congo");
        //    nationalities.Add("Burkina Fasso");

        //    return nationalities.Distinct();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable AllBirthPlaces()
        //{
        //    var birthPlace = new List<string>();

        //    using (var db = new WinxoContext())
        //    {
        //        var studentBp = (from s in db.Students.ToList() where s.Person.BirthPlace != null select s.Person.BirthPlace).ToList().Distinct().ToList();
        //        birthPlace.AddRange(studentBp);

        //        var staffBp = (from s in db.Staffs.ToList() where s.Person.BirthPlace != null select s.Person.BirthPlace).ToList().Distinct().ToList();
        //        birthPlace.AddRange(staffBp);
        //    }

        //    if (birthPlace.Count != 0) return birthPlace.Distinct();

        //    birthPlace.Add("Rabat");
        //    birthPlace.Add("Casablanca");
        //    birthPlace.Add("Bamako");
        //    birthPlace.Add("Toumbouctou");
        //    birthPlace.Add("Tayba");
        //    birthPlace.Add("Dakar");

        //    return birthPlace;
        //}

        ///// <summary>
        ///// AllCategories
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable AllCategories()
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        var pos = (from s in db.Employments.ToList() where !string.IsNullOrEmpty(s.Category) select s.Category).Distinct().ToList();

        //        return !pos.Any()
        //            ? new List<string>
        //            {
        //                "Full Time",
        //                "Temps Plein",
        //                "contracteur",
        //                "Temps Partiel",
        //                "Part Time"
        //            }
        //            : pos;
        //    }
        //}

        ///// <summary>
        ///// AllGrades
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable AllGrades()
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        var pos = (from s in db.Employments.ToList() where !string.IsNullOrEmpty(s.Grade) select s.Grade).Distinct().ToList();

        //        return !pos.Any()
        //            ? new List<string>
        //            {
        //                "Senior",
        //                "Junior"
        //            }
        //            : pos;
        //    }
        //}

        ///// <summary>
        ///// AllDivisions
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable AllDivisions()
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        var pos = (from s in db.Employments.ToList() where !string.IsNullOrEmpty(s.Division) select s.Division).Distinct().ToList();

        //        return !pos.Any()
        //            ? new List<string>
        //            {
        //                "Marketing",
        //                "Finance",
        //                "Recherche"
        //            }
        //            : pos;
        //    }
        //}

        ///// <summary>
        ///// AllProjets
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable AllProjets()
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        var pos = (from s in db.Employments.ToList() where !string.IsNullOrEmpty(s.Project) select s.Project).Distinct().ToList();

        //        return !pos.Any()
        //            ? new List<string>
        //            {
        //                "Recherche Marché",
        //                "Alpha 1",
        //                "XKeyscore"
        //            }
        //            : pos;
        //    }
        //}

        ///// <summary>
        ///// AllStaffsNames
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable AllStaffsNames()
        //{
        //    using (var db = new WinxoContext())
        //    {
        //        return db.Staffs.Select(s => s.Person.FirstName + " " + s.Person.LastName).Distinct().ToList();
        //    }
        //}

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
