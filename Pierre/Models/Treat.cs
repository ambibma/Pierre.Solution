using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pierre.Models
{
  public class Treat 
  {
    public int TreatId{get;set;}
    [Required(ErrorMessage = "This Treats Type cannot be empty!")]
    public string Type {get;set;}

    public ApplicationUser User { get; set; }

     public List<TreatFlavor> JoinEntities {get; set; }

  }
}