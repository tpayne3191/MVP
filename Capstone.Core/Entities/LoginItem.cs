using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Core.Entities
{
    public class LoginItem
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public int? PlayerId { get; set; }
    }
}
