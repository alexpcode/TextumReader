﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextumReader.ProblemDomain;

namespace TextumReader.WebUI.Models
{
    public class MaterialViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int MaterialId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CategoryId { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? DictionaryId { get; set; }

        [Display(Name = "Text in a foreign language")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string ForeignText { get; set; }

        [Display(Name = "Translation")]
        [DataType(DataType.MultilineText)]
        public string NativeText { get; set; }
    }
}