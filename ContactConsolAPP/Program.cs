using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactConsolAPP
{
    internal class Program
    {

        static void FindContact()
        {
            Console.Write("Enter ID: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            clsContact Contact = clsContact.Find(ID);

            if (Contact != null)
            {
                Console.WriteLine(Contact.FirstName + " " + Contact.LastName);
                Console.WriteLine(Contact.Email);
                Console.WriteLine(Contact.Phone);
                Console.WriteLine(Contact.Address);
                Console.WriteLine(Contact.DateOfBirth);
                Console.WriteLine(Contact.CountryID);
                Console.WriteLine(Contact.ImagePath);
            }
            else
            {
                Console.WriteLine("Contact [" + ID + "] Not Found!");
            }
        }

        static void AddNewContact()
        {
            clsContact contact = new clsContact();

            Console.Write("Enter FirstName: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter LastName: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Enter Email: ");
            contact.Email = Console.ReadLine();

            Console.Write("Enter Phone: ");
            contact.Phone = Console.ReadLine();

            Console.Write("Enter Address: ");
            contact.Address = Console.ReadLine();

            Console.Write("Enter Country ID: ");

            int CountryID = 1;

            if (CountryID < 1 || CountryID > 5)
            {
                Console.WriteLine("Invalid Country ID");
                contact.CountryID = 1;
            }
            else
            {
                contact.CountryID = Convert.ToInt32(Console.ReadLine());
            }

            if (contact.Save())
            {
                Console.WriteLine("Contact Added Successfully with ID = " + contact.ID);
            }
        }

        static void UpdateContact()
        {

            Console.Write("Enter ID: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            clsContact contact = clsContact.Find(ID);

            if (contact != null)
            {
                Console.Write("Enter FirstName: ");
                contact.FirstName = Console.ReadLine();

                Console.Write("Enter LastName: ");
                contact.LastName = Console.ReadLine();

                Console.Write("Enter Email: ");
                contact.Email = Console.ReadLine();

                Console.Write("Enter Phone: ");
                contact.Phone = Console.ReadLine();

                Console.Write("Enter Address: ");
                contact.Address = Console.ReadLine();

                Console.Write("Enter Country ID: ");

                int CountryID = 1;

                if (CountryID < 1 || CountryID > 5)
                {
                    Console.WriteLine("Invalid Country ID");
                    contact.CountryID = 1;
                }
                else
                {
                    contact.CountryID = Convert.ToInt32(Console.ReadLine());
                }
            }
            else
            {
                Console.Write("Contact Not Found!");
            }

            if (contact.Save())
            {
                Console.WriteLine("Contact Updated Successfully!");
            }
        }

        static void DeleteContact()
        {
            Console.Write("Enter ID: ");
            int ID = Convert.ToInt32(Console.ReadLine());

            if (clsContact.isContactExist(ID))
            {
                if(clsContact.DeleteContact(ID))
                {
                    Console.WriteLine("Contact Deleted Successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to Delete Contact!");
                }
            }
            else
            {
                Console.WriteLine("Contact Not Found!");
            }
        }

        static void GetAllContacts()
        {
            DataTable dataTable = clsContact.GetAllContacts();

            Console.WriteLine("Contacts Data: ");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]}- {row["FirstName"]} {row["LastName"]}");
            }
        }

        static void isContactExist(int ID)
        {
            if (clsContact.isContactExist(ID))
            {
                Console.WriteLine("Contact Exist!");
            }
            else
            {
                Console.WriteLine("Contact NOT Exist!");
            }
        }

        static void Main(string[] args)
        {
            //FindContact();
            //AddNewContact();
            //UpdateContact();
            //DeleteContact();
            //GetAllContacts();
            //isContactExist(1);

            Console.ReadKey();
        }
    }
}
