using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
  public class DetailModel : PageModel
  {
    public DetailModel(IRestaurantData restaurantData)
    {
      _restaurantData = restaurantData;
    }

    public IActionResult OnGet(int restaurantId)
    {
      Restaurant = _restaurantData.GetById(restaurantId);
      if (Restaurant == null)
        return RedirectToPage("./NotFound");
      return Page();
    }

    public Restaurant Restaurant { get; set; }
    [TempData]
    public string Message { get; set; }

    private readonly IRestaurantData _restaurantData;
  }
}