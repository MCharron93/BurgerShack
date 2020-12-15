using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repository
{
  public class BurgerRepository
  {
    private readonly IDbConnection _db;
    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Burger> GetBurgers()
    {
      // NOTE FROM will be pulling from "table" as to "collection"
      string sql = "SELECT * FROM borgers";
      return _db.Query<Burger>(sql);
    }

    public Burger GetOneBurger(int id)
    {
      // NOTE FROM will be pulling from "table" as to "collection"
      string sql = "SELECT * FROM borgers WHERE id = @Id";
      return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }

    public Burger Create(Burger newBurger)
    {
      // NOTE FROM will be pulling from "table" as to "collection"
      string sql = @"INSERT INTO borgers 
      (bun, protein, toppings, condiments)
      VALUES
      (@Bun, @Protein, @Toppings, @Condiments);
      SELECT LAST_INSERT_ID();";
      newBurger.Id = _db.ExecuteScalar<int>(sql, newBurger);
      return newBurger;
    }


    public bool Delete(int id)
    {
      string sql = "DELETE FROM borgers WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }
    public Burger UpdateBurger(int id, Burger updatedBurger)
    {
      // NOTE will use REPLACE method to update the information and rewrite the data that was in the unique index given
      string sql = @"REPLACE INTO borgers VALUES(bun, protein, toppings, condiments)";
      updatedBurger.Id = _db.Execute(sql, updatedBurger);
      return updatedBurger;
    }
  }
}