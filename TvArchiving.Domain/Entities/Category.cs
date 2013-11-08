using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvArchiving.Domain.Entities
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Category Title cannot be empty")]
        public string Name { get; set; }
        public virtual ICollection<Shot> Shots { get; set; }
    }
}
