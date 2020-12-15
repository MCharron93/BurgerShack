using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Burger
  {
    public int Id { get; set; }
    [Required]
    public string Bun { get; set; }
    [Required]

    public string Protein { get; set; }
    public string Toppings { get; set; }
    public string Condiments { get; set; }

    // public Burger(string bun, string protein, string toppings, string condiments)
    // {
    //   this.Bun = bun;
    //   this.Protein = protein;
    //   this.Toppings = toppings;
    //   this.Condiments = condiments;

    // }
  }
}