using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class ServiceModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Затрачиваемое время")]
        [Required(ErrorMessage = "Поле {0} должно быть заполнено.")]
        [RegularExpression(@"^([0-1]\d|2[0-3])(:[0-5]\d){1}$", ErrorMessage = "Не верный формат времини.")]
        public string TimeCost { get; set; }

        public bool IsActive { get; set; }

        public int OrderBy { get; set; }
    }
}