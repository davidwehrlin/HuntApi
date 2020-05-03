using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using hunt_api.Models;

namespace hunt_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaderBoardController : ControllerBase {
        private readonly List<Item> _items = new List<Item>();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        public ActionResult<Item> Post(Item item) {
            _items.Add(item);
            return CreatedAtAction("Post", item);
        }

        [HttpGet]
        public List<Item> Get() {
           return _items;
        }

    }
    
}
