using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EmsBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool Fix { get; set; }
    }
}
