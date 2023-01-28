using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Blog : IEntity
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; } = string.Empty;
        public string BlogContent { get; set; } = string.Empty;
        public string BlogThumbnailImage { get; set; } = string.Empty;
        public string BlogImage { get; set; } = string.Empty;
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryID { get; set; }
        public int UserId { get; set; }
        public Category? Category { get; set; }
        public User? User { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
