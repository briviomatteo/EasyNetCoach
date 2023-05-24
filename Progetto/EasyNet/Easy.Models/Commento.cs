using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyNet.Models;

public partial class Commento
{
    [Key]
    public int IdCommento { get; set; }

    public string Testo { get; set; } = null!;
    
    public int FkPost { get; set; }
    [ValidateNever]
    [ForeignKey(nameof(FkPost))]
    public Post Post { get; set; } = null!;

    public int? FkUtente { get; set; }
    [ForeignKey(nameof(FkUtente))]
    public Utente utente { get; set; } = null!;
}
