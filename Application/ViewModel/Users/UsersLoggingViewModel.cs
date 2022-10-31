using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Application.ViewModel.Users
{
    public class UsersLoggingViewModel
    {
        [Required(ErrorMessage = "please check your name")]
        [DataType(DataType.Text)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "password is Required")]
        [DataType(DataType.Password)]
        public string? UsersPasswork { get; set; }
    }
}
