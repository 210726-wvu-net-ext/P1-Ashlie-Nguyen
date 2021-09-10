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
    public class LocationsController : Controller
    {
        private readonly ILocationRepository _locationrepository;
        private readonly ICustomerRepository _customerrepository;
        private readonly IOrderRepository _orderrepository;

        public LocationsController(ILocationRepository locationrepository, ICustomerRepository customerrepository, IOrderRepository orderrepository)
        {
            _locationrepository = locationrepository;
            _customerrepository = customerrepository;
            _orderrepository = orderrepository;
        }

        // GET: Locations
        public ActionResult Index()
        {
            return View( _locationrepository.GetAll().ToList());
        }

        // GET: Locations/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location =  _locationrepository.Get(id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LocationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var location = new Location() 
                {
                    StoreName = viewModel.StoreName,
                    Phone = viewModel.Phone,
                    Hours = viewModel.Hours,
                    StreetAddress = viewModel.StreetAddress,
                    ZipCode = viewModel.ZipCode,
                    State = viewModel.State,
                    OpeningDate = viewModel.OpeningDate
                };
                _locationrepository.Create(location);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = _locationrepository.Get(id);
            if (location == null)
            {
                return NotFound();
            }

            var l = new LocationViewModel()
            {
                Id = location.Id,
                StoreName = location.StoreName,
                Phone = location.Phone,
                Hours = location.Hours,
                StreetAddress = location.StreetAddress,
                ZipCode = location.ZipCode,
                State = location.State,
                OpeningDate = location.OpeningDate
            };
            return View(l);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LocationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var location = new Location()
                    {
                        Id = viewModel.Id,
                        StoreName = viewModel.StoreName,
                        Phone = viewModel.Phone,
                        Hours = viewModel.Hours,
                        StreetAddress = viewModel.StreetAddress,
                        ZipCode = viewModel.ZipCode,
                        State = viewModel.State,
                        OpeningDate = viewModel.OpeningDate
                    }; 
                    _locationrepository.Update(location);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(viewModel.Id))
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

        // GET: Locations/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = _locationrepository.Get(id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _locationrepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _locationrepository.Get(id) != null ? true : false;
        }

        // GET: Locations/History/5
        public IActionResult History(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IEnumerable<Order> orders = _orderrepository.GetAll();

            if (orders == null)
            {
                return NotFound();
            }

            if (orders.Count(p => p.Location == id) == 0)
            {
                return NotFound();
            }

            orders = orders.Where(p => p.Location == id).Select(o => new Order()
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Customer = o.Customer,
                Location = o.Location,
                CustomerNavigation = _customerrepository.Get(o.Location)
            });
            return View(orders);
        }
    }
}
