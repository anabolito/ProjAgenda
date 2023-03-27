using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgenda
{
    internal class Address
    {
        
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        
        public Address()
        {

        }

        public override string ToString()
        {
            return $"\n  Rua: {Street}\n  Cidade: {City}\n  Estado: {State}\n  CEP: {PostalCode}\n  Country: {Country}";
        }

        public string ToFile()
        {
            return $"{Street}*{City}*{State}*{PostalCode}*{Country}";
        }

        public void EditStreet(string street)
        {
            this.Street = street;
        }

        public void EditCity(string city)
        {
            this.City = city;
        }

        public void EditState(string state)
        {
            this.State = state;
        }

        public void EditPostalCode(string postalCode)
        {
            this.PostalCode = postalCode;
        }

        public void EditCountry(string country)
        {
            this.Country = country;
        }

        public Address EditarAdress(string street, string city, string state, string postalCode, string country)
        {
            this.Street = street;
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
            this.Country = country;

            return this;
        }



    }
}