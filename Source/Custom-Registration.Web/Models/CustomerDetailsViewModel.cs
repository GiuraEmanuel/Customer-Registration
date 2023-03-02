namespace Custom_Registration.Web.Models
{
    public class CustomerDetailsViewModel
    {
        public CustomerDetailsViewModel(string name, string website, string email, string phoneNumber, Address postalAddress, Address invoiceAddress)
        {
            Name = name;
            Website = website;
            Email = email;
            PhoneNumber = phoneNumber;
            PostalAddress = postalAddress;
            InvoiceAddress = invoiceAddress;
        }

        public string Name { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Address PostalAddress { get; set; }

        public Address InvoiceAddress { get; set; }

        public class Address
        {
            public Address(string street, string streetNumber, string postCode,
                string city, string country)
            {
                Street = street;
                StreetNumber = streetNumber;
                PostCode = postCode;
                City = city;
                Country = country;
            }

            public string Street { get; set; }

            public string StreetNumber { get; set; }

            public string PostCode { get; set; }

            public string City { get; set; }

            public string Country { get; set; }

            public override string ToString()
            {
                return $"{StreetNumber} {Street}\n{City}, {Country}\n{PostCode}";
            }
        }
    }
}
