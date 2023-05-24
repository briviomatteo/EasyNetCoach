using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyNet.Models;

public partial class Utente
{
    [Key]
    public int IdUtente { get; set; }

    public string Username { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Mail { get; set; } = null!;
    public string Password { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateTime? DataNascita { get; set; } = null!;

    public string FotoProfilo { get; set; } = null!;
    public int FkPost { get;set; }
    [ValidateNever]
    [ForeignKey(nameof(FkPost))]
    public Post post { get; set; } = null!;

    public virtual ICollection<Commento> Commentos { get; set; } = new List<Commento>();
}
