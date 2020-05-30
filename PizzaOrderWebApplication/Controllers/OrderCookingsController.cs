using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrderWebApplication.Models;

namespace PizzaOrderWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCookingsController : ControllerBase
    {
        private readonly PizzaContext _context;

        public OrderCookingsController(PizzaContext context)
        {
            _context = context;
        }

        // GET: api/OrderCookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderCooking>>> GetOrderCooking()
        {
            return await _context.OrderCooking.ToListAsync();
        }

        // GET: api/OrderCookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderCooking>> GetOrderCooking(int id)
        {
            var orderCooking = await _context.OrderCooking.FindAsync(id);

            if (orderCooking == null)
            {
                return NotFound();
            }

            return orderCooking;
        }

        // PUT: api/OrderCookings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderCooking(int id, OrderCooking orderCooking)
        {
            if (id != orderCooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderCooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderCookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderCookings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderCooking>> PostOrderCooking(OrderCooking orderCooking)
        {
            _context.OrderCooking.Add(orderCooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderCooking", new { id = orderCooking.Id }, orderCooking);
        }

        // DELETE: api/OrderCookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderCooking>> DeleteOrderCooking(int id)
        {
            var orderCooking = await _context.OrderCooking.FindAsync(id);
            if (orderCooking == null)
            {
                return NotFound();
            }

            _context.OrderCooking.Remove(orderCooking);
            await _context.SaveChangesAsync();

            return orderCooking;
        }

        private bool OrderCookingExists(int id)
        {
            return _context.OrderCooking.Any(e => e.Id == id);
        }
    }
}
