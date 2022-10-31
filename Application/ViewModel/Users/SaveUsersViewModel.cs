using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Application.ViewModel.Users
{
    public class SaveUsersViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "please check your User name")]
        [DataType(DataType.Text)]
        public string? UserNickName { get; set; }

        [Required(ErrorMessage = "please check your name")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "please check your last name")]
        [DataType(DataType.Text)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "please check your email")]
        [DataType(DataType.Text)]
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "please check your phone number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Home Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number, please use a correct format like this 000-000-0000 or 0000000000")]
        public string? UserPhone { get; set; }

        [Required(ErrorMessage = "password is Required")]
        [DataType(DataType.Password)]
        public string? UserPassword { get; set; }

        [Compare(nameof(UserPassword), ErrorMessage = "the password aren't equal")]
        [Required(ErrorMessage = "password is Required")]
        [DataType(DataType.Password)]
        public string? ConfirmUsersPasswork { get; set; }

    }
}
