﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Code.Attributes;
using _Data.Models;

namespace Admin.Models
{
    public class NailDesignModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле '{0}' необходимо заполнить.")]
        public string Name { get; set; }

        [Display(Name = "Затрачиваемое время")]
        [Required(ErrorMessage = "Поле {0} должно быть заполнено.")]
        [RegularExpression(@"^([0-1]\d|2[0-3])(:[0-5]\d){1}$", ErrorMessage = "Не верный формат времини.")]
        public string TimeOut { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Поле {0} должно быть заполнено.")]
        public int Price { get; set; }

        public int OrderBy { get; set; }

        public bool IsActive { get; set; }

        public ICollection<NailDesignType> NailDesignTypes { get; set; }
    }

    public class NailDesignRequestModel : NailDesignModel
    {
        public List<Guid> NailDesignTypesGuids { get; set; }
    }
}