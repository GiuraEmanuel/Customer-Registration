using Custom_Registration.CodeFirst;
using Custom_Registration.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Custom_Registration.Web.Controllers
{
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CustomerController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("Customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _appDbContext.Customers.Select(c => new CustomerViewModel.Customer(c.Id, c.Name, c.Website, c.Email, c.PhoneNumber)).ToListAsync();

            var customerViewModel = new CustomerViewModel(customers);

            return View(customerViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CustomerDetail(int id)
        {
            var customerInfo = await _appDbContext.Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerDetailsViewModel(
                    c.Name,
                    c.Website,
                    c.Email,
                    c.PhoneNumber,
                    new CustomerDetailsViewModel.Address(
                        c.PostalAddress.Street,
                        c.PostalAddress.Number,
                        c.PostalAddress.PostCode,
                        c.PostalAddress.City,
                        c.PostalAddress.Country
                    ),
                    new CustomerDetailsViewModel.Address(
                        c.InvoiceAddress.Street,
                        c.InvoiceAddress.Number,
                        c.InvoiceAddress.PostCode,
                        c.InvoiceAddress.City,
                        c.InvoiceAddress.Country
                    )
                ))
                .SingleOrDefaultAsync();

            return View(customerInfo);
        }

        [HttpGet("AddCustomer")]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(AddCustomerViewModel model)
        {
            var validator = new AddCustomerViewModelValidator();
            var result = validator.Validate(model);

            if (result.IsValid)
            {
                var customer = new Customer
                {
                    Name = model.Name,
                    Website = model.Website,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    PostalAddress = new Address
                    {
                        Street = model.PostalAddressStreet,
                        Number = model.PostalAddressStreetNumber,
                        PostCode = model.PostalAddressPostCode,
                        City = model.PostalAddressCity,
                        Country = model.PostalAddressCountry
                    }
                };

                if (!model.IsInvoiceAddressDifferent)
                    customer.InvoiceAddress = customer.PostalAddress;
                else
                    customer.InvoiceAddress = new Address
                    {
                        Street = model.InvoiceAddressStreet,
                        Number = model.InvoiceAddressStreetNumber,
                        PostCode = model.InvoiceAddressPostCode,
                        City = model.InvoiceAddressCity,
                        Country = model.InvoiceAddressCountry
                    };

                _appDbContext.Customers.Add(customer);
                _appDbContext.SaveChanges();

                return RedirectToAction("Customers");
            }
            else
            {
                // The model is invalid, display validation errors to the user
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }

                return View(model);
            }
        }
    }
}
