﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_ALDB.Models
{
    public class SaleRespEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
    }
}
