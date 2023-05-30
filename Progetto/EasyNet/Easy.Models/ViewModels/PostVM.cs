using EasyNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.ViewModels
{
    public  class PostVM
    {
        public Post Post { get; set; } = null!;
        public Utente Utente { get; set; }=null!;

    }
}
