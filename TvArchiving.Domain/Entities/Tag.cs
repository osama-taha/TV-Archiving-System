using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TvArchiving.Domain.Entities
{
    public class Tag
    {
        [Key]
        public long ID { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
