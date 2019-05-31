using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
  public class ListModel : PageModel
  {
    // Injecting an using Configuration
    public ListModel(IConfiguration config, IRestaurantData restaurantData)
    {
      _config = config;
      _restaurantData = restaurantData;
    }
    public void OnGet(string searchTerm) // response to HTTP GET request
    {
      //HttpContext.Request.QueryString
      this.SearchTerm = searchTerm;
      Message = _config["Message"];
      Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
    }

    // Building a Page Model
    public string Message { get; set; }
    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }
    public IEnumerable<Restaurant> Restaurants { get; set; }

    private readonly IConfiguration _config;
    private readonly IRestaurantData _restaurantData;
  }
}