﻿using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    public class Category
    {
        [Key]//ràng buộc annotations
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Display Order")]
        [Range(1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int DisplayOrder { get; set; }
        public DateTime CreateDatetime { get; set; } = DateTime.Now;
    }
}
