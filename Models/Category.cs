﻿using System.ComponentModel.DataAnnotations;

namespace bloginterior.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; } 
    }
}
