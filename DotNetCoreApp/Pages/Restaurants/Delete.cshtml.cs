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
  public class DeleteModel : PageModel
  {
    public DeleteModel(IRestaurantData data)
    {
      this._data = data;
    }

    public IActionResult OnGet(int restaurantId)
    {
      Restaurant = _data.GetRestaurantById(restaurantId);
      if (Restaurant == null)
        return RedirectToPage("./NotFound");
      return Page();
    }
    public IActionResult OnPost(int restaurantId)
    {
      var restaurant = _data.Delete(restaurantId);
      _data.Commit();

      if (restaurant == null)
        return RedirectToPage("./NotFound");

      TempData["Message"] = $"{restaurant.Name} deleted";
      return RedirectToPage("./List");
    }

    public Restaurant Restaurant { get; set; }

    private IRestaurantData _data;
  }
}