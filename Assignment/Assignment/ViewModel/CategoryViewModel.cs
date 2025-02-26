using System.ComponentModel.DataAnnotations;
namespace Assignment.ViewModel
{
    public class CategoryViewModel
    {
        public short CategoryId { get; set; }
        [Required, StringLength(100)]
        public string CategoryName { get; set; } = null!;
        public string CategoryDesciption { get; set; } = null!;
        public bool? IsActive { get; set; }
    }
}
