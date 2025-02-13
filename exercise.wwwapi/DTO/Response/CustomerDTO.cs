﻿using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<OrderCustomerDTO> Orders { get; set;} = new List<OrderCustomerDTO>();
    }
}
