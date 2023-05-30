using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyNet.Models;

public  class Utente:IdentityUser
{

    public string CodiceFiscale { get; set; } = null!;

    public string NomeProfilo { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Mail { get; set; } = null!;
    public string Password { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateTime? DataNascita { get; set; } = null!;

    public string FotoProfilo { get; set; } = null!;
    public int? FkPost { get;set; }
    [ValidateNever]
    [ForeignKey(nameof(FkPost))]
    public Post Post { get; set; } = null!;

    public virtual ICollection<Commento> Commentos { get; set; } = new List<Commento>();
}
