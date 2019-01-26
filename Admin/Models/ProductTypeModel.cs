using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Admin.Code.Attributes;

namespace Admin.Models
{
    public class ProductTypeModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Родительская категория")]
        [UIHint("DropDownListProductTypes")]
        [CompareExtansion("Id", false, ErrorMessage = "Нельзя выбирать в родитеи самого себя!")]
        public Guid? ProductTypeId { get; set; }

        [Display(Name = "Название категории")]
        [Required(ErrorMessage = "Поле '{0}' необходимо заполнить.")]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int OrderBy { get; set; }
    }
}