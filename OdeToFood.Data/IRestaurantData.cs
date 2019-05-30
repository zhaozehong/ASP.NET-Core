using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
  // Building a Data Access service
  public interface IRestaurantData
  {
    IEnumerable<Restaurant> GetAll();
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
    public IEnumerable<Restaurant> GetAll()
    {
      return from r in _restaurants
             orderby r.Name
             select r;
    }

    private readonly List<Restaurant> _restaurants;
  }
}
