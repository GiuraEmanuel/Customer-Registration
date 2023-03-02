namespace Custom_Registration.Web.Models
{
    public class CustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; }

        public CustomerViewModel(IEnumerable<Customer> customers)
        {
            Customers = customers;
        }

        public class Customer
        {
            public Customer(int id, string name, string website, string email, string phoneNumber)
            {
                Id = id;
                Name = name;
                Website = website;
                Email = email;
                PhoneNumber = phoneNumber;
            }

            public int Id { get; set; }

            public string Name { get; set; }

            public string Website { get; set; }

            public string Email { get; set; }

            public string PhoneNumber { get; set; }
        }
    }
}
