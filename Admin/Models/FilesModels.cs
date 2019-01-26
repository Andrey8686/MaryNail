using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Models
{
    public class FileModel
    {
        public Guid? Id { get; set; }

        public string AppDataDir { get; set; }
        public string FileName { get; set; } // GetFile
        public string Param { get; set; } // GetFile

        public string Prefix { get; set; }

        public int ImageMaxWidth { get; set; }
        public int ImageMaxHeight { get; set; }
        public int ImageFixWidth { get; set; }
        public int ImageFixHeight { get; set; }

        public string[] FileUrl { get; set; } // GetFile

        public bool IsFileExists { get; set; }
        public string HashCode
        {
            get => Guid.NewGuid().ToString();
        }
    }
}