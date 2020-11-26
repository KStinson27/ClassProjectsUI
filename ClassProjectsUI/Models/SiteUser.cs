using System;
using System.ComponentModel.DataAnnotations;

namespace ClassProjectsUI.Models
{
    public class SiteUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        
    }
}
