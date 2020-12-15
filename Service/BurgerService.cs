using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Repository;

namespace BurgerShack.Services
{
  public class BurgerService
  {
    private readonly BurgerRepository _repo;
    public BurgerService(BurgerRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Burger> GetBurgers()
    {
      return _repo.GetBurgers();
    }

    public Burger GetOneBurger(int id)
    {
      Burger exists = GetOneBurger(id);
      if (exists == null)
      {
        throw new Exception("that borger does not exist.");
      }
      return _repo.GetOneBurger(id);
    }

    public Burger Create(Burger newBurger)
    {
      return _repo.Create(newBurger);
    }

    public string Delete(int id)
    {
      if (_repo.Delete(id))
      {
        return "Great success, deleted the borger!";
      }
      return "that borger does not exist!";
    }

    public Burger UpdateBurger(int id, Burger updatedBurger)
    {
      return _repo.UpdateBurger(id, updatedBurger);
    }
  }
}