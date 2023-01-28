using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class About : IEntity
    {
        [Key]
        public int AboutID { get; set; }
        public string AboutDetails1 { get; set; } = string.Empty;
        public string AboutDetails2 { get; set; } = string.Empty;
        public string AboutImage1 { get; set; } = string.Empty;
        public string AboutImage2 { get; set; } = string.Empty;
        public string AboutMapLocation { get; set; } = string.Empty;
        public bool AboutStatus { get; set; }
    }
}
