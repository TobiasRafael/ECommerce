﻿using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ECommerce.Models
{
    public class User
    {
        [PrimaryKey]
        public int UserId { get; set; }

        [ForeignKey(typeof(Company))]
        public int IdCompany { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Photo { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        [ManyToOne]
        public Company Company { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsUser { get; set; }

        public bool IsCustomer { get; set; }

        public bool IsSupplier { get; set; }

        public bool IsRemembered { get; set; }

        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public string Password { get; set; }

        public string PhotoFullPath { get { return string.Format("http://zulu-software.com/Ecommerce{0}", Photo.Substring(1)); }  }
        public override int GetHashCode()
        {
            return UserId;
        }

    }
}
