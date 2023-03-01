namespace Custom_Registration.CodeFirst
{
    public class Customer
    {
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
