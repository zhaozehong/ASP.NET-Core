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
  public class DetailModel : PageModel
  {
    public DetailModel(IRestaurantData data)
    {
      _data = data;
    }
    public IActionResult OnGet(int restaurantId)
    {
      Restaurant = _data.GetRestaurantById(restaurantId);
      if(Restaurant == null)
      {
        return RedirectToPage("./NotFound");
      }
      return Page();
    }

    [TempData]
    public string EditMessage { get; set; }
    public Restaurant Restaurant { get; private set; }

    private readonly IRestaurantData _data;
  }
}