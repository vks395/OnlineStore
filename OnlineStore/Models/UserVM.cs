using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineStore.Models
{
    public class UserVM
    {

        [Display(Name ="* User Id")]
        [Required(ErrorMessage = "User Id Is Required")]
        public string UserId { get; set; }
        [Display(Name = "* User Name")]
        [Required(ErrorMessage = "User Name Is Required")]
        public string UserName { get; set; }
        [Display(Name = "* Password")]
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
        [Display(Name = "* Role")]
        [Required(ErrorMessage = "Role Is Required")]
        public string RoleId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
