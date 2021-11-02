﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPISourceCode.Models;
using test.Data;

namespace ShopAPISourceCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public OrdersController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutOrder(int id,[FromForm] Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }
            var isUserIdValid = int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return Unauthorized();
            }
            else if (user.UserId != order.OrderUserId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("order updated");
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Order>> PostOrder([FromForm] Order order)
        {
            var isUserIdValid = int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return Unauthorized();
            }
            else if (user.UserId != order.OrderUserId)
            {
                return BadRequest();
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            var isUserIdValid = int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString(), out int userId);
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return Unauthorized();
            }
            else if (user.UserId != order.OrderUserId)
            {
                return BadRequest();
            }

            
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok("order deleted");
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}