using System;
using System.Collections.Generic;

namespace Pierre.Models
{
  public class Treat 
  {
    public int TreatId{get;set;}
    public string Type {get;set;}

    public ApplicationUser User { get; set; }

     public List<TreatFlavor> JoinEntities {get; set; }

  }
}