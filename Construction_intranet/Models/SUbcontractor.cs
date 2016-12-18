using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL_Construction.Data;
using Construction_intranet.Concrete_Classes;

namespace Construction_intranet.Models
{
    public class SUbcontractorModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public Nullable<int> Contractorid { get; set; }
        public Nullable<System.DateTime> Added { get; set; }
    }

    public class SUbcontractorDB
    {
        Construction_DBEntities oDB = new Construction_DBEntities();

       


     
        public List<SUbcontractorModel> GetSubcontractor()
        {
            var _list = (from p in oDB.tbl_sub_contractor
                         where  p.Contractorid==SessionManager.ContractorId
                         select new SUbcontractorModel
                         {
                             id= p.id,
                             Name = p.Name,
                             Added=p.Added,
                             Email=p.Email,
                             Fax=p.Fax,
                             Phone=p.Phone,
                             Address = p.Address,
                             
                             Contact = p.Contact






                         }).ToList();
            return _list;


        }

        public SUbcontractorModel GetSUbcontractorbyId(int id)
        {
            var _list = (from p in oDB.tbl_sub_contractor
                         where p.id==id && p.Contractorid == SessionManager.ContractorId
                         select new SUbcontractorModel
                         {

                             id = p.id,
                             Name = p.Name,
                             Added = p.Added,
                             Email = p.Email,
                             Fax = p.Fax,
                             Phone = p.Phone,
                             Address = p.Address,

                             Contact = p.Contact










                         }).SingleOrDefault();
            return _list;


        }


    }
}