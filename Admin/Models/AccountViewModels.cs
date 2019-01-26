using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Admin.Code.Attributes;

namespace Admin.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить вас?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Заполните поле \"{0}\"")]
        [RegularExpression(@"^[а-яА-ЯёЁъЪ\-\ ]{1,30}$", ErrorMessage = "Допустимы только буквы русского алфавита")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [RegularExpression(@"^[а-яА-ЯёЁъЪ\-\ ]{1,30}$", ErrorMessage = "Допустимы только буквы русского алфавита")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        [RegularExpression(@"^[а-яА-ЯёЁъЪ\-\ ]{1,30}$", ErrorMessage = "Допустимы только буквы русского алфавита")]
        public string Patronymic { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime? DateOfBirth { get; set; }
        
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Заполните поле \"{0}\"")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Укажите корректный Email.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} должен быть не короче {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение пароля не совпадают.")]
        public string ConfirmPassword { get; set; }
        
        [Display(Name = "Я согласна получать Email сообщения!")]
        public bool AgreeToReceiveEmailMessages { get; set; }

        [Display(Name = "Я согласна получать СМС сообщения!")]
        public bool AgreeToReceiveSmsMessages { get; set; }

        [Display(Name = "Я согласна на обработку персональных данных!")]
        [EnforceTrue]
        public bool AgreeToTheProcessingOfPersonalData { get; set; }

        [Display(Name = "Я согласна с правилами сайта!")]
        [EnforceTrue]
        public bool AgreeWithTheRules { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} должен быть не короче {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение пароля не совпадают.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
