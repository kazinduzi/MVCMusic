using MVCMusic.DAL;
using MVCMusic.Models;
using MVCMusic.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MVCMusic.Controllers
{
    public class CustomersController : Controller
    {
        private MusicContext _context;
        
        // Constructor
        public CustomersController()
        {
            _context = new MusicContext();    
        }

        // DbContext is disposable
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Custormers
        public ActionResult Index()
        {
            var custMovieViewModel = new CustMovieViewModel() {
                Customers = _context.Customers.ToList()
            };
            return View(custMovieViewModel);
        }

        // GET: Detail/{id}
        public ActionResult Detail(int id)
        {
            var viewModel = new CustomerViewModel
            {
                Customer = _context.Customers.SingleOrDefault(c => c.ID == id)
            };
            return View(viewModel);
        }

        // GET: New
        public ActionResult New()
        {
            var viewModel = new CustomerViewModel
            {
                Customer = new CustomerModel()
            };
            return View("CustomerForm", viewModel);
        }

        // GET: Edit/{id}
        public ActionResult Edit(int id)
        {
            var viewModel = new CustomerViewModel
            {
                Customer = _context.Customers.SingleOrDefault(c => c.ID == id)
            };            
            return View("CustomerForm", viewModel);
        }
        
        [HttpPost]
        public ActionResult Save(CustomerModel customer)
        {
            if (! ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = customer
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.ID == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerToUpdate = _context.Customers.Single(c => c.ID == customer.ID);
                customerToUpdate.Name = customer.Name;
                customerToUpdate.Country = customer.Country;
                customerToUpdate.CustomerId = customer.CustomerId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}