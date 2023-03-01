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
            var customers = await _appDbContext.Customers.Select(c=> new CustomerViewModel.Customer(c.Name,c.Website,c.Email,c.PhoneNumber)).ToListAsync();

            var customerViewModel = new CustomerViewModel(customers);

            return View(customerViewModel);
        }
    }
}
