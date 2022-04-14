using System;
using System.ComponentModel.DataAnnotations;
namespace REST_API_CRUD.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        public string Name { get; set; }
    }
}
