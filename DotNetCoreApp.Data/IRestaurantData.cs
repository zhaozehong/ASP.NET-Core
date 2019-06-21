using System.Collections.Generic;
using DotNetCoreApp.Core;

namespace DotNetCoreApp.Data
{
  public interface IRestaurantData
  {
    IEnumerable<Restaurant> GetRestaurantsByName(string name);
    Restaurant GetRestaurantById(int id);
    Restaurant Add(Restaurant newRestaurant);
    Restaurant Update(Restaurant updatedRestaurant);
    Restaurant Delete(int id);
    int GetCount();
    int Commit();
  }
}
