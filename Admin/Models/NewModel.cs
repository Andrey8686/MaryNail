using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Models
{
    public class NewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Название новости")]
        [Required(ErrorMessage = "Поле {0} должно быть заполнено.")]
        public string Name { get; set; }

        [Display(Name = "Краткое описание новости")]
        [Required(ErrorMessage = "Поле {0} должно быть заполнено.")]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Полный текст новости")]
        [Required(ErrorMessage = "Поле {0} должно быть заполнено.")]
        [AllowHtml]
        public string FullText { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}