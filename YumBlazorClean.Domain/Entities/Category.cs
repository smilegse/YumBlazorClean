using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumBlazorClean.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public required string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
