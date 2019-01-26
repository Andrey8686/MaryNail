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
    public class NailDesignTypeModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле '{0}' необходимо заполнить.")]
        public string Name { get; set; }

        public int OrderBy { get; set; }

        public bool IsActive { get; set; }
    }
}