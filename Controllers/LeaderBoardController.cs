using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using hunt_api.Models;
using System.Threading.Tasks;
using System;

namespace hunt_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaderBoardController : ControllerBase {

        private readonly LeaderBoardContext _context;

        public LeaderBoardController(LeaderBoardContext context){
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Item>> PostTodoItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.Id}, item);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(long id)
        {
            var todoItem = await _context.Items.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Item>>> GetTodoItems()
        {
            return await _context.Items.ToListAsync();
        }

    }
    
}
