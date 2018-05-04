
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            var creator = new RestaurantCreator();
            creator.Create();
        }
    }

    public class RestaurantCreator
    {
        private readonly Random rand;

        public RestaurantCreator()
        {
            rand = new Random();
        }

        public Restaurant Create()
        {
            var restaurant = new Restaurant();
            restaurant.Id = Guid.NewGuid().ToString();
            restaurant.Name = Path.GetRandomFileName();
            restaurant.Address = Path.GetRandomFileName();
            restaurant.Bar = CreateBar();
            restaurant.Halls = CreateHalls();
            return restaurant;
        }

        private List<Hall> CreateHalls(int count = 0)
        {
            var halls = new List<Hall>();
            for (int i = 0; i < count; i++)
            {
                halls.Add()
            }
            return halls;
        }

        private Hall CreateHall()
        {
            var hall = new Hall();
            hall.Id = Guid.NewGuid().ToString();
            hall.Number = rand.Next(1, 10);
            hall.Administrator = 
            return hall;
        }

        private List<Administrator> CreateAdministrators(int count = 0)
        {
            var administartors = new List<Administrator>();
            for (int i = 0; i < count; i++)
            {
                administartors.Add();
            }
            return administartors;
        }

        private Administrator CreateAdministrator()
        {

        }

        private Bar CreateBar()
        {
            var bar = new Bar();
            bar.Id = Guid.NewGuid().ToString();
            bar.Barmens = CreateBarmans(10);
            bar.Drinks = CreateDrinks(150);
            return bar;
        }


        private List<Barman> CreateBarmans(int count = 0)
        {
            var barmans = new List<Barman>();
            for (int i = 0; i < count; i++)
            {
                barmans.Add(CreateBarman());
            }
            return barmans;
        }

        private Barman CreateBarman()
        {
            var barman = CreateHuman<Barman>();        
            return barman;
        }

        private T CreateHuman<T>() where T : Human
        {
            var human = (T)Activator.CreateInstance(typeof(T));
            human.Id = Guid.NewGuid().ToString();
            human.Name = Path.GetRandomFileName();
            human.Age = rand.Next(18, 35);
            human.Sex = (Gender)rand.Next(0, 1);
            return human;
        }

        private List<Drink> CreateDrinks(int count = 0)
        {
            var drinks = new List<Drink>();
            for (int i = 0; i < count; i++)
            {
                drinks.Add(CreateDrink());
            }
            return drinks;
        }

        private Drink CreateDrink()
        {
            var drink = new Drink();
            drink.Id = Guid.NewGuid().ToString();
            drink.Name = Path.GetRandomFileName();
            drink.Type = (DrinkType)rand.Next(0, 1);
            return drink;
        }

    }

    public static class RestaurantRepository
    {
        public static List<Restaurant> Restaurants { get; set; }
    }

    #region Enums

    public enum Gender
    {
        Man = 0,
        Woman = 1
    }

    public enum DrinkType
    {
        Alcoholic = 0,
        NonAlcoholic = 1
    }

    public enum DishType
    {
        Vegetarian = 0,
        Normal = 1
    }
    #endregion

    public class Bar : BaseEntity
    {
        public List<Barman> Barmens { get; set; }
        public List<Drink> Drinks { get; set; }

    }

    public class Hall : BaseEntity
    {
        public List<Waiter> Waiters { get; set; }
        public List<Administrator> Administrator { get; set; }
        public int Number { get; set; }
    }

    public class Kitchen : BaseEntity
    {
        public List<Human> Cookers { get; set; }
    }

    #region Workers

    public class Barman : Human
    {
       // public List<Drink> Drinks { get; set; }
    }

    public class Cooker : Human
    {

    }

    public class Owner : Human
    {

    }

    public class Waiter : Human
    {
        public List<Order> Orders { get; set; }
    }

    public class Administrator : Human
    {

    }

#endregion

    public class Order : BaseEntity
    {
        public int PositionNumber { get; set; }
        public int TableNumber { get; set; }
        public List<Dish> Dishes { get; set; }
        public List<Drink> Drinks { get; set; }
        public double Price { get; set; }
        public DateTime DateCreate { get; set; } 
    }

    public class Dish : BaseEntity
    {
        public string Name { get; set; }
        public DishType Type { get; set; }
        public double Price { get; set; }
    }

    public class Drink : BaseEntity
    {
        public string Name { get; set; }
        public DrinkType Type { get; set; }
    }

    public class Human : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Sex { get; set; }
    }

    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Owner> Owners { get; set; }
        public Kitchen Kitchen { get; set; }
        public List<Hall> Halls { get; set; }
        public Bar Bar { get; set; }
    }

    public class BaseEntity
    {
        public string Id { get; set; }
    }
}