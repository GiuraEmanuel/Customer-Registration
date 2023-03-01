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
        public async Task<IActionResult> Detail(int id)
        {
            var customerInfo = await _appDbContext.Customers.Where(c => c.Id == id)
                .Select(c => new CustomerDetailsViewModel(c.Id, c.Name, c.Website, c.Email, c.PhoneNumber,
                    c.PostalAddressId, c.PostalAddress, c.InvoiceAddressId, c.InvoiceAddress)).SingleOrDefaultAsync();


            return View(customerInfo);
        }
    }
}
