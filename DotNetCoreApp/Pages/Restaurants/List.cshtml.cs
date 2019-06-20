using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreApp.Core;
using DotNetCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreApp.Pages.Restaurants
{
  public class ListModel : PageModel
  {
    public ListModel(IConfiguration config,  IRestaurantData data)
    {
      _config = config;
      _data = data;
    }
    public void OnGet()
    {
      Message = _config["Message"];
      Restaurants = _data.GetRestaurantsByName(SearchTerm);
    }

    public IEnumerable<Restaurant> Restaurants { get; private set; }
    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }
    public string Message { get; set; }

    private readonly IConfiguration _config;
    private readonly IRestaurantData _data;
  }
}