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
            if (item.Name.Length > 32) {
                return BadRequest(new Exception("Length of Name too long"));
            }
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new { id = item.Id}, item);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(long id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Item>>> GetTodoItems()
        {
            List<Item> list = await _context.Items.ToListAsync();
            list.Sort((x, y) => y.Score.CompareTo(x.Score));
            while (list.Count > 10) {
                _context.Remove(list[list.Count -1]);
                list.RemoveAt(list.Count - 1);
            }
            await _context.SaveChangesAsync();
            return list;
        }

    }
    
}
