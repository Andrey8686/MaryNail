using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Code.Attributes;
using _Data.Models;

namespace Admin.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Тип работы")]
        public Guid ServiceId { get; set; }

        [Display(Name = "Родительская категория")]
        [UIHint("DropDownListProductTypes")]
        public Guid ProductTypeId { get; set; }

        [Display(Name = "Название категории")]
        [Required(ErrorMessage = "Поле '{0}' необходимо заполнить.")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Затрачиваемое время")]
        [Required(ErrorMessage = "Поле {0} должно быть заполнено.")]
        [RegularExpression(@"^([0-1]\d|2[0-3])(:[0-5]\d){1}$", ErrorMessage = "Не верный формат времини.")]
        public string TimeCost { get; set; }

        public bool IsActive { get; set; }

    }
}