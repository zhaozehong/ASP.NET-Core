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
    Restaurant Update(Restaurant updatedRestaurant);
    Restaurant Add(Restaurant newRestaurant);
    int Commit();
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

    public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
    {
      return from r in _restaurants
             where string.IsNullOrWhiteSpace(name) || r.Name.StartsWith(name)
             orderby r.Name
             select r;
    }
    public Restaurant GetById(int id)
    {
      return _restaurants.FirstOrDefault(p => p.Id == id);
    }
    public Restaurant Update(Restaurant updatedRestaurant)
    {
      var restaurant = _restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
      if(restaurant != null)
      {
        restaurant.Name = updatedRestaurant.Name;
        restaurant.Location = updatedRestaurant.Location;
        restaurant.Cuisine = updatedRestaurant.Cuisine;
      }
      return restaurant;
    }
    public Restaurant Add(Restaurant newRestaurant)
    {
      _restaurants.Add(newRestaurant);
      newRestaurant.Id = _restaurants.Max(p => p.Id) + 1;
      return newRestaurant;
    }

    public int Commit()
    {
      return 0;
    }
    

    private readonly List<Restaurant> _restaurants;
  }
}
