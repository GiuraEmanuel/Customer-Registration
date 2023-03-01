using Custom_Registration.CodeFirst;

namespace Custom_Registration.Web.Models
{
    public class CustomerDetailsViewModel
    {
        public CustomerDetailsViewModel(int id, string name, string website, string email, string phoneNumber,
            int postalAddressId, Address postalAddress, int invoiceAddressId, Address invoiceAddress)
        {
            Id = id;
            Name = name;
            Website = website;
            Email = email;
            PhoneNumber = phoneNumber;
            PostalAddressId = postalAddressId;
            PostalAddress = postalAddress;
            InvoiceAddressId = invoiceAddressId;
            InvoiceAddress = invoiceAddress;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int PostalAddressId { get; set; }

        public Address PostalAddress { get; set; }

        public int InvoiceAddressId { get; set; }

        public Address InvoiceAddress { get; set; }
    }
}
