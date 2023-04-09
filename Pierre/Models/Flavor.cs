using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pierre.Models
{
  public class Flavor
  {
    public int FlavorId {get;set;}
    
     [Required(ErrorMessage = "This Flavor's Description Type cannot be empty!")]
    public string Description {get;set;}
    
    public ApplicationUser User { get; set; }
    public List<TreatFlavor> JoinEntities {get; set; }
  }
}