using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreApp.Core;
using DotNetCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetCoreApp.Pages.Restaurants
{
  public class ListModel : PageModel
  {
    public ListModel(IRestaurantData data)
    {
      _data = data;
    }
    public void OnGet()
    {
      Restaurants = _data.GetRestaurantsByName(SearchTerm);
    }

    public IEnumerable<Restaurant> Restaurants { get; private set; }
    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }

    private readonly IRestaurantData _data;
  }
}