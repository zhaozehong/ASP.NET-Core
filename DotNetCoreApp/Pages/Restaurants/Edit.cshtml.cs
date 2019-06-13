using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreApp.Core;
using DotNetCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNetCoreApp.Pages.Restaurants
{
  public class EditModel : PageModel
  {
    public EditModel(IRestaurantData data, IHtmlHelper htmlHelper)
    {
      _data = data;
      _htmlHelper = htmlHelper;
      Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
    }
    public IActionResult OnGet(int? restaurantId)
    {
      if (restaurantId.HasValue)
        Restaurant = _data.GetRestaurantById(restaurantId.Value);
      else
        Restaurant = new Restaurant();
      if (Restaurant == null)
        return RedirectToPage("./NotFound");
      return Page();
    }
    public IActionResult OnPost()
    {
      //ModelState["Name"].AttemptedValue
      if (!ModelState.IsValid)
        return Page();

      if (Restaurant.Id == 0)
        _data.Add(Restaurant);
      else
        _data.Update(Restaurant);
      _data.Commit();
      TempData["EditMessage"] = "Restaurant saved!";
      return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
    }

    [BindProperty]
    public Restaurant Restaurant { get; set; }
    public IEnumerable<SelectListItem> Cuisines { get; private set; }

    private readonly IRestaurantData _data;
    private readonly IHtmlHelper _htmlHelper;
  }
}