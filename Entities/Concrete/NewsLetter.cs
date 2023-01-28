using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class NewsLetter : IEntity
    {
        [Key]
        public int MailID { get; set; }
        public string MailAddress { get; set; } = string.Empty;
        public bool MailStatus { get; set; }
    }
}
