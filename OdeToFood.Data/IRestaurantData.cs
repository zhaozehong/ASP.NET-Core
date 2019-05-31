using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
  // Building a Data Access service
  public interface IRestaurantData
  {
    IEnumerable<Restaurant> GetRestaurantsByName(string name);
    Restaurant GetById(int id);
  }
  public class InMemoryRestaurantData : IRestaurantData
  {
    public InMemoryRestaurantData()
    {
      _restaurants = new List<Restaurant>()
      {
        new Restaurant{Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian},
        new Restaurant{Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Italian},
        new Restaurant{Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Italian}
      };
    }
    public Restaurant GetById(int id)
    {
      return _restaurants.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
    {
      return from r in _restaurants
             where string.IsNullOrWhiteSpace(name) || r.Name.StartsWith(name)
             orderby r.Name
             select r;
    }

    private readonly List<Restaurant> _restaurants;
  }
}
