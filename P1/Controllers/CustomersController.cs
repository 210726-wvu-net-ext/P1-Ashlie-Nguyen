using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P1.Domain;
using P1.ViewModels;

namespace P1.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerrepository;

        private readonly IOrderRepository _orderrepository;

        private readonly ILocationRepository _locationrepository;

        public CustomersController(ICustomerRepository customerrepository, IOrderRepository orderrepository, ILocationRepository locationrepository)
        {
            _customerrepository = customerrepository;
            _orderrepository = orderrepository;
            _locationrepository = locationrepository;
    }
        // Index action in Customers controller
        // GET: Customers
        public IActionResult Index(string searchString)
        {
            IEnumerable<Customer> customers = _customerrepository.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.FullName.Contains(searchString));
            }

            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerrepository.Get(id ?? throw new ArgumentNullException(nameof(id), "Cannot set to null"));
                //.FirstOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer(viewModel.FirstName, viewModel.LastName, viewModel.Phone, viewModel.RegistrationDate);
                _customerrepository.Create(customer);
                //await _customerrepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerrepository.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            var c = new CustomerViewModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                RegistrationDate = customer.RegistrationDate
            };
            return View(c);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var customer = new Customer(viewModel.Id, viewModel.FirstName, viewModel.LastName, viewModel.Phone, viewModel.RegistrationDate);
                    _customerrepository.Update(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerrepository.Get(id);
                //.FirstOrDefaultAsync(m => m.Id == id);
            return customer == null ? NotFound() : View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // var customer = _customerrepository.Customer.FindAsync(id);
            _customerrepository.Delete(id);
            // await _customerrepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _customerrepository.Get(id) != null ? true : false;
        }

        // GET: Customers/History/5
        public IActionResult History(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IEnumerable<Order> orders = _orderrepository.GetAll();

            if (orders.Count(p => p.Customer == id) == 0)
            {
                return NotFound();
            }

            orders = orders.Where(p => p.Customer == id).Select(o => new Order()
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Customer = o.Customer,
                Location = o.Location,
                LocationNavigation = _locationrepository.Get(o.Location)
            });

            return View(orders);
        }

    }
}
