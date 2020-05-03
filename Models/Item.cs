using System;
using System.ComponentModel.DataAnnotations;

namespace hunt_api.Models
{
    public class Item
    {
        [Key]
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

    }
}
