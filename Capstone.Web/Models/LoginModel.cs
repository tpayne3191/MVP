using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Capstone.Web.Models
{
    public class LoginModel
    {
        /// <summary>String value for the user's username</summary>
        [Required]
        [MaxLength(256)]
        public string UserName { get; set; }
        /// <summary>String value for the user's password</summary>
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<SelectListItem> AvailableLogins { get; set; }
    }
}
