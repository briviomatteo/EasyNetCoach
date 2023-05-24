using EasyNet.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models
{
    public partial class Like
    {
        [Key]
        public int IdLike { get; set; }
        public int FKUtente { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(FKUtente))]
        public Utente Utente { get; set; } = null!;
        public int FkPost { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(FkPost))]
        public Post Post { get; set; } = null!;
    }
}
