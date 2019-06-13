using DotNetCoreApp.Core;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreApp.Data
{
  public interface IRestaurantData
  {
    IEnumerable<Restaurant> GetRestaurantsByName(string name);
    Restaurant GetRestaurantById(int id);
    Restaurant Add(Restaurant newRestaurant);
    Restaurant Update(Restaurant newRestaurant);
    int Commit();
  }
  public class InMemoryRestaurantData : IRestaurantData
  {
    public InMemoryRestaurantData()
    {
      _restaurants = new List<Restaurant>()
      {
        new Restaurant(){Id=1, Name="Zehong's Pizza", Location="Shanghai", Cuisine= CuisineType.Italian},
        new Restaurant(){Id=2, Name="Holiday Inn", Location="Puerto Rico", Cuisine= CuisineType.Mexican},
        new Restaurant(){Id=3, Name="Hanting Hotel", Location="Hangzhou", Cuisine= CuisineType.Chinese},
      };
    }

    public IEnumerable<Restaurant> GetRestaurantsByName(string name)
    {
      var temp = from r in _restaurants
                 where string.IsNullOrWhiteSpace(name) || r.Name.Contains(name)
                 orderby r.Name
                 select r;
      return temp;
    }
    public Restaurant GetRestaurantById(int id)
    {
      return _restaurants.FirstOrDefault(p => p.Id == id);
    }
    public Restaurant Add(Restaurant newRestaurant)
    {
      newRestaurant.Id = _restaurants.Max(p => p.Id) + 1;
      _restaurants.Add(newRestaurant);
      return newRestaurant;
    }
    public Restaurant Update(Restaurant updatedRestaurant)
    {
      var temp = _restaurants.FirstOrDefault(p => p.Id == updatedRestaurant.Id);
      if (temp != null)
      {
        temp.Name = updatedRestaurant.Name;
        temp.Location = updatedRestaurant.Location;
        temp.Cuisine = updatedRestaurant.Cuisine;
      }
      return temp;
    }
    public int Commit()
    {
      return 0;
    }

    public readonly List<Restaurant> _restaurants;
  }
}
