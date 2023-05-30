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
    
    public int? FkPost { get; set; }
    [ValidateNever]
    [ForeignKey(nameof(FkPost))]
    public Post Post { get; set; } = null!;

    public string FkUtente { get; set; }=null!;
    [ValidateNever]
    [ForeignKey(nameof(FkUtente))]
    public Utente Utente { get; set; } = null!;

    
}
