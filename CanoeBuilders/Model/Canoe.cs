using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Canoe
    {
        [Required]
        [StringLength(100, ErrorMessage = "The canoe name can not be longer than 100 characters.")]
        public string Name { get; set; }
        [Required]
        public int BuilderID { get; set; }
        [Required]
        public int QTY { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool MyProperty { get; set; }
        [Required]
        public int CanoeType { get; set; }
    }
}
