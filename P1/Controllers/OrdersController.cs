using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P1.Domain;
using P1.ViewModels;

namespace P1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderrepository;
        private readonly ICustomerRepository _customerrepository;
        private readonly ILocationRepository _locationrepository;

        public OrdersController(IOrderRepository orderrepository, ICustomerRepository customerrepository, ILocationRepository locationrepository)
        {
            _orderrepository = orderrepository;
            _customerrepository = customerrepository;
            _locationrepository = locationrepository;
        }

        // GET: Orders
        public IActionResult Index()
        {
            var order = _orderrepository.GetAll()
                .Select(o => new Order()
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    TotalPrice = o.TotalPrice,
                    Customer = o.Customer,
                    Location = o.Location,
                    CustomerNavigation = _customerrepository.Get(o.Customer),
                    LocationNavigation = _locationrepository.Get(o.Location)
                })
                .OrderByDescending(o => o.CustomerNavigation.FullName)
                .OrderByDescending(o => o.OrderDate);
            return View(order);
        }

        // GET: Orders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderrepository.Get(id);
            order.CustomerNavigation = _customerrepository.Get(order.Customer);
            order.LocationNavigation = _locationrepository.Get(order.Location);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            // SelectItemList is a special ASP.net method for use in displaying drop down lists. Thank you StackOverflow!
            var vm = new OrderViewModel();
            vm.Customers = _customerrepository.GetAll()
                                .Select(a => new SelectListItem()
                                {
                                     Value = a.Id.ToString(),
                                     Text = a.FullName
                                })
                                .ToList();
            vm.Locations = _locationrepository.GetAll()
                                .Select(a => new SelectListItem()
                                {
                                    Value = a.Id.ToString(),
                                    Text = a.StoreName
                                })
                                .ToList();
            return View(vm);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    OrderDate = viewModel.OrderDate,
                    TotalPrice = viewModel.TotalPrice,
                    Customer = viewModel.Customer,
                    Location = viewModel.Location,
                    CustomerNavigation = _customerrepository.Get(viewModel.Customer),
                    LocationNavigation = _locationrepository.Get(viewModel.Location)
                };
                _orderrepository.Create(order);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Orders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderrepository.Get(id);
            if (order == null)
            {
                return NotFound();
            }

            var o = new OrderViewModel()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Customer = order.Customer,
                Location = order.Location
            };

            o.Customers = _customerrepository.GetAll()
                                .Select(a => new SelectListItem()
                                {
                                    Value = a.Id.ToString(),
                                    Text = a.FullName
                                })
                                .ToList();
            o.Locations = _locationrepository.GetAll()
                                .Select(a => new SelectListItem()
                                {
                                    Value = a.Id.ToString(),
                                    Text = a.StoreName
                                })
                                .ToList();
            return View(o);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderViewModel viewModel)
        {
            if (viewModel.Id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var order = new Order()
                    {
                        Id = viewModel.Id,
                        OrderDate = viewModel.OrderDate, 
                        TotalPrice = viewModel.TotalPrice, 
                        Customer = viewModel.Customer, 
                        Location = viewModel.Location,
                        CustomerNavigation = _customerrepository.Get(viewModel.Customer),
                        LocationNavigation = _locationrepository.Get(viewModel.Location)
                    };
                    _orderrepository.Update(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Orders/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderrepository.Get(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _orderrepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _orderrepository.Get(id) != null ? false : true;
        }

        // GET: Orders/History/5
        public IActionResult History(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderrepository.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}
