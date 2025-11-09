using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    public class clsContact
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }

        public clsContact()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryID = -1;
            this.ImagePath = "NULL";

            this.Mode = enMode.AddNew;
        }
        private clsContact(int ID, string FirstName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;

            this.Mode = enMode.Update;
        }

        public static clsContact Find(int ID)
        {
            string FirstName = "", lastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int countryID = 1;

            if (clsContactsData.GetContactByID(ID, ref FirstName, ref lastName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref countryID, ref ImagePath))
            {
                return new clsContact(ID, FirstName, lastName, Email, Phone, Address, DateOfBirth, countryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewContact()
        {
            this.ID = clsContactsData.AddNewContact(this.FirstName, this.LastName, this.Email, this.Phone, this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);

            return (this.ID != -1);
        }

        private bool _UpdateContact()
        {
            return clsContactsData.UpdateContact(this.ID, this.FirstName, this.LastName, this.Email, this.Phone, this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);
        }

        public static bool DeleteContact(int ID)
        {
            return clsContactsData.DeleteContact(ID);
        }

        public static DataTable GetAllContacts()
        {
            return clsContactsData.GetAllContacts();
        }

        public static bool isContactExist(int ID)
        {
            return clsContactsData.isContactExist(ID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewContact())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateContact();
            }

            return false;
        }
    }
}
