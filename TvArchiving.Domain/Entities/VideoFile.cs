using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvArchiving.Domain.Entities
{
    public class VideoFile
    {

        [Key]
        public long ID { get; set; }

        [Required]
        public string m_fileName { get; set; }

        [Required]
        public string m_filePath { get; set; }

        public float m_fileLength { get; set; }

        [DefaultValue(0.000000f)]
        public DateTime m_fileDate { get; set; }

        [DefaultValue(0)]
        public virtual double m_fps { get; set; }

        [DefaultValue(0)]
        public virtual double m_duration { get; set; }
    }
}
