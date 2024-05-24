//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using optimization.Models;

//namespace optimization.Controller
//{
//    public class OrderModelsController : Controller
//    {
//        private readonly optimizationContext _context;

//        public OrderModelsController(optimizationContext context)
//        {
//            _context = context;
//        }

//        // GET: OrderModels
//        public async Task<IActionResult> Index()
//        {
//              return _context.OrderModel != null ? 
//                          View(await _context.OrderModel.ToListAsync()) :
//                          Problem("Entity set 'optimizationContext.OrderModel'  is null.");
//        }

//        // GET: OrderModels/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.OrderModel == null)
//            {
//                return NotFound();
//            }

//            var orderModel = await _context.OrderModel
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (orderModel == null)
//            {
//                return NotFound();
//            }

//            return View(orderModel);
//        }

//        // GET: OrderModels/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: OrderModels/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,ProductID,NumberOfProduct,CustomerID,CourierCompany,Date")] OrderModel orderModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(orderModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(orderModel);
//        }

//        // GET: OrderModels/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.OrderModel == null)
//            {
//                return NotFound();
//            }

//            var orderModel = await _context.OrderModel.FindAsync(id);
//            if (orderModel == null)
//            {
//                return NotFound();
//            }
//            return View(orderModel);
//        }

//        // POST: OrderModels/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int? id, [Bind("ID,ProductID,NumberOfProduct,CustomerID,CourierCompany,Date")] OrderModel orderModel)
//        {
//            if (id != orderModel.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(orderModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!OrderModelExists(orderModel.ID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(orderModel);
//        }

//        // GET: OrderModels/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.OrderModel == null)
//            {
//                return NotFound();
//            }

//            var orderModel = await _context.OrderModel
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (orderModel == null)
//            {
//                return NotFound();
//            }

//            return View(orderModel);
//        }

//        // POST: OrderModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int? id)
//        {
//            if (_context.OrderModel == null)
//            {
//                return Problem("Entity set 'optimizationContext.OrderModel'  is null.");
//            }
//            var orderModel = await _context.OrderModel.FindAsync(id);
//            if (orderModel != null)
//            {
//                _context.OrderModel.Remove(orderModel);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool OrderModelExists(int? id)
//        {
//          return (_context.OrderModel?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
