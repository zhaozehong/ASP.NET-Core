using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetCoreApp.Core
{
  public class Restaurant //: IValidatableObject
  {
    public int Id { get; set; }

    [Required, StringLength(80)]
    public string Name { get; set; }

    [Required, StringLength(255)]
    public string Location { get; set; }

    public CuisineType Cuisine { get; set; }
  }
  public enum CuisineType { None, Mexican, Italian, Chinese }
}
