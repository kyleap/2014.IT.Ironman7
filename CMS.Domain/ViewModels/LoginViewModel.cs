using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.ViewModels
{
    public class LoginViewModel
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        public string LoginID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string LoginPwd { get; set; }
    }
}
