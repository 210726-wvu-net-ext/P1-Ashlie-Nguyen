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
    public class ProductOrdersController : Controller
    {
        private readonly IProductOrderRepository _porepo;

        public ProductOrdersController(IProductOrderRepository porepo)
        {
            _porepo = porepo;
        }

        // GET: ProductOrders
        public IActionResult Index()
        {
            return View(_porepo.GetAll());
        }

        // GET: ProductOrders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productOrder = _porepo.Get(id);
            if (productOrder == null)
            {
                return NotFound();
            }

            return View(productOrder);
        }

        // GET: ProductOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductOrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var productOrder = new ProductOrder(viewModel.Number, viewModel.Product, viewModel.Order);
                _porepo.Create(productOrder);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: ProductOrders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productOrder = _porepo.Get(id);
            if (productOrder == null)
            {
                return NotFound();
            }
            return View(productOrder);
        }

        // POST: ProductOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductOrderViewModel viewModel)
        {
            if (viewModel.Id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var productOrder = new ProductOrder(viewModel.Id, viewModel.Number, viewModel.Product, viewModel.Order);
                    _porepo.Update(productOrder);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductOrderExists(viewModel.Id))
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

        // GET: ProductOrders/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productOrder = _porepo.Get(id);
            if (productOrder == null)
            {
                return NotFound();
            }

            return View(productOrder);
        }

        // POST: ProductOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _porepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductOrderExists(int id)
        {
            return _porepo.Get(id) != null ? true : false;
        }
        // GET: ProjectOrders/History/5
        public IActionResult History(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var po = _porepo.Get(id);
            if (po == null)
            {
                return NotFound();
            }
            return View(po);
        }
    }
}
