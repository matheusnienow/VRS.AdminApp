using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRS.AdminApp.Model
{
    public class Client
    {
        public Client()
        {
        }

        public Client(VRSServiceReference.ClientDTO x)
        {
            Id = x.Id;
            Name = x.Name;
            Surname = x.Surname;
            Sex = x.Sex;
            Phone = x.Phone;
            City = x.City;
            BirthDate = x.BirthDate;
            UserId = x.UserId;
            Passport = x.Passport;
            CPF = x.CPF;
            Address = x.Address;
            Country = x.Country;
        }

        public Client(string name, string surname, string sex, string phone, string city, DateTime birthDate, int userId)
        {
            Name = name;
            Surname = surname;
            Sex = sex;
            Phone = phone;
            City = city;
            BirthDate = BirthDate;
            UserId = userId;

            Passport = "";
            CPF = 0;
            Address = "";
        }
        
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Passport { get; set; }

        public int? CPF { get; set; }//BRAZILIAN DOCUMENT NUMBER

        public string Sex { get; set; }

        public string Phone { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int? UserId { get; set; }
    }
}
