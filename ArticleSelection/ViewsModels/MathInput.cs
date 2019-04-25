using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleSelection.Models
{
    public class MathInput
    {
        [Required]
        public int Uid { get; set; }
        [Required]
        public int Left { get; set; }

        [Required]
        public int Right { get; set; }
//@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+/.[A-Za-z]{2,4}")
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+/.[A-Za-z]{2,4}")]
        public string Email { get; set; }
    }
}
