using System;
using System.ComponentModel.DataAnnotations;
using Assignment.Models;

namespace Assignment.ViewModel
{
    public class NewsArticleViewModel
    {
       
        public required string NewsArticleId { get; set; }
        [Required, StringLength(255)]
        public string? NewsTitle { get; set; }
        public string Headline { get; set; } = null!;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public string? NewsContent { get; set; }
        public bool? NewsStatus { get; set; } = true;
        public short? CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
