using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyNet.Models;

public partial class Post
{
    [Key]
    public int IdPost { get; set; }

    public string? Foto { get; set; }

    public string Descrizione { get; set; } = null!;

    public string FkUtente { get; set; } = null!;
    [ForeignKey(nameof(FkUtente))]
    public Utente Utente { get; set; } = null!;
}
