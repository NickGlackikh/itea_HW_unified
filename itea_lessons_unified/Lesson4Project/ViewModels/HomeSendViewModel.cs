using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.ViewModels
{
    public class HomeSendViewModel
    {
        [Required]
        public string AddrTo { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string MessageType { get; set; }
    }
}
