using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL_Construction.Data;

namespace Construction_intranet.Models
{
    public class ContractorModel
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> Isactive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUser> tblUsers { get; set; }
    }
    public class ContractorDB
    {
        Construction_DBEntities _entities = new Construction_DBEntities();
        public ContractorModel GetContractorbyId(int id)
        {
            var _list = (from p in _entities.tblContractors
                         where p.Id == id
                         select new ContractorModel
                         {
                             Id = id,
                             FirstName = p.FirstName,
                             LastName = p.LastName,
                             Email = p.Email,
                             Address = p.Address,
                             City = p.City,
                             Notes = p.Notes,
                             Phone = p.Phone,
                             State = p.State,
                             Zip = p.Zip




                         }).SingleOrDefault();
            return _list;
           

        }
        public List<ContractorModel> GetContractor()
        {
            var _list = (from p in _entities.tblContractors
                         
                         select new ContractorModel
                         {
                             Id = p.Id,
                             FirstName = p.FirstName,
                             LastName = p.LastName,
                             Email = p.Email,
                             Address = p.Address,
                             City = p.City,
                             Notes = p.Notes,
                             Phone = p.Phone,
                             State = p.State,
                             Zip = p.Zip,
                             CreatedDate=p.CreatedDate,
                             Isactive=p.Isactive,
                             Status=p.Isactive==true?"Active":"Inactive"
                           
                           




                         }).ToList();
            return _list;


        }




    }




}