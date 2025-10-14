using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsite.Models
{
    public class Skill
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
