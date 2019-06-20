using System.Linq;
using System.Collections.Generic;
using DotNetCoreApp.Core;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreApp.Data
{
  public class SqlRestaurantData : IRestaurantData
  {
    public SqlRestaurantData(DotNetCoreAppDbContext db)
    {
      this._db = db;
    }

    public Restaurant Add(Restaurant newRestaurant)
    {
      this._db.Restaurants.Add(newRestaurant);
      return newRestaurant;
    }

    public int Commit()
    {
      return this._db.SaveChanges();
    }

    public Restaurant Delete(int id)
    {
      var restaurant = GetRestaurantById(id);
      if (restaurant != null)
        this._db.Restaurants.Remove(restaurant);
      return restaurant;
    }

    public Restaurant GetRestaurantById(int id)
    {
      return this._db.Restaurants.Find(id);
    }

    public IEnumerable<Restaurant> GetRestaurantsByName(string name)
    {
      var query = from r in _db.Restaurants
                  where r.Name.StartsWith(name) || string.IsNullOrWhiteSpace(name)
                  orderby r.Name
                  select r;
      return query;
    }

    public Restaurant Update(Restaurant updatedRestaurant)
    {
      var entity = _db.Restaurants.Attach(updatedRestaurant);
      entity.State = EntityState.Modified;
      return updatedRestaurant;
    }

    private DotNetCoreAppDbContext _db;
  }
}
