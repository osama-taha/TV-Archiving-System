using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvArchiving.Domain.Entities
{
    public class Shot
    {
        [Key]
        public long Id { get; set; }
        public virtual int KeyFrame { get; set; }
        [Required]
        public double From { get; set; }
        [Required]
        public double ToTime { get; set; }

        [Required]
        public string m_fileName { get; set; }

        [Required]
        public string m_filePath { get; set; }

        [MaxLength(100)]
        public virtual string Description { get; set; }
        [Required]
        public virtual byte[] ThumbnailImage { get; set; }
        public virtual string AddedBy { get; set; }
        public virtual string DateAdded { get; set; }
        public double Rating { get; set; }
        public virtual string Tags { get; set; }
        public virtual int Category_ID { get; set; }
        [ForeignKey("Category_ID")]
        public virtual Category Category { get; set; }


    }
}
