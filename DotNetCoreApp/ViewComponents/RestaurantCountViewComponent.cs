using DotNetCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApp.ViewComponents
{
  public class RestaurantCountViewComponent : ViewComponent
  {
    public RestaurantCountViewComponent(IRestaurantData data)
    {
      this._data = data;
    }

    public IViewComponentResult Invoke()
    {
      var count = _data.GetCount();
      return View(count);
    }

    private readonly IRestaurantData _data;
  }
}
