using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        //public IEnumerable<UserRole> Roles { get; set; }

        public List<SelectListItem> RoleItems { get; set; }

        public UserViewModel()
        {
            RoleItems = new List<SelectListItem>();
        }
        public void SetRoleItems(IEnumerable<IdentityRole> roles)
        {
            foreach (var style in roles)
            {
                RoleItems.Add(new SelectListItem()
                {
                    Value = style.Id.ToString(),
                    Text = style.Name
                });
            }
        }
    }
}