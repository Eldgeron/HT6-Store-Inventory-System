using System;
using System.Text.RegularExpressions;

namespace MyClass
{
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public virtual string UnitOfMeasure { get; set; } = "units";

        protected Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    class Beverage : Product, ICountable
    {
        public double AlcoholContent { get; set; }
        public override string UnitOfMeasure { get; set; } = "bottles";
        public Beverage(string name, double price, int quantity, double alcoholContent)
            : base(name, price, quantity)
        {
            AlcoholContent = alcoholContent;
        }

        public double CountAmount()
        {
            return Quantity;
        }
    }

    class Vegetable : Product, ICountable
    {
        public string Origin { get; set; }
        public override string UnitOfMeasure { get; set; } = "pc";
        public Vegetable(string name, double price, int quantity, string origin)
            : base(name, price, quantity)
        {
            Origin = origin;
        }

        public double CountAmount()
        {
            return Quantity;
        }
    }

    class Milk : Product, ICountable
    {
        public string LactoseContent { get; set; }
        public override string UnitOfMeasure { get; set; } = "l";
        public Milk(string name, double price, int quantity, string lactoseContent)
            : base(name, price, quantity)
        {
            LactoseContent = lactoseContent;
        }
        public double CountAmount()
        {
            return Quantity;
        }
    }

    class Meat : Product, ICountable
    {
        public string Animal { get; set; }
        public override string UnitOfMeasure { get; set; } = "kg";
        public Meat(string name, double price, int quantity, string animal)
            : base(name, price, quantity)
        {
            Animal = animal;
        }
        public double CountAmount()
        {
            return Quantity;
        }
    }

    class Fish : Product, ICountable
    {
        public string WaterType { get; set; }
        public override string UnitOfMeasure { get; set; } = "kg";
        public Fish(string name, double price, int quantity, string waterType)
            : base(name, price, quantity)
        {
            WaterType = waterType;
        }
        public double CountAmount()
        {
            return Quantity;
        }
    }

    public interface ICountable
    {
        double CountAmount();
    }

    //create a class that will store the user data
    public class UserDB
    {
        //create a dictionary to store the username and password
        private Dictionary<string, string> userDB = new Dictionary<string, string>();

        //create new user
        public void SignIn()
        {
            bool validKey = true;

            Console.WriteLine("Registration form. " +
                        "\nUsername Requirements: " +
                        "\n-- can be simple " +
                        "\n-- must containe only latin letters" +
                        "\n-- must be unique " +
                        "\n-- case-sensitive " +
                        "\n-- must be from 8 to 13 characters " +
                        "\n-- can't be only from white spaces" +
                        "\nPassword requirements" +
                        "\n-- must be from 8 to 13 characters " +
                        "\n-- must containe only latin letters, digits and symbols" +
                        "\n-- case-sensitive " +
                        "\n-- can't be only from white spacec");
            do
            {
                validKey = false;
                Console.WriteLine("Enter a Username:");
                string userName = Console.ReadLine();
                if (ValidUsername(userDB, userName))
                {
                    do
                    {
                        validKey = false;
                        Console.WriteLine("Enter a password");
                        string userPassword = Console.ReadLine();
                        if (ValidPassword(userPassword))
                        {
                            Add(userName, userPassword);
                            Console.WriteLine("New User was created");
                            validKey = true;
                        }
                    }
                    while (!validKey);
                }
            }
            while (!validKey);
        }

        //check if the username is valid and not used
        public bool ValidUsername(Dictionary<string, string> dictionary, string input)
        {
            bool compairAnswer = true;
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Username can't be empty or be only from spaces");
                compairAnswer = false;
            }
            else if (input.Length < 8 || input.Length >= 13)
            {
                Console.WriteLine("Username must be from 8 to 13 characters");
                compairAnswer = false;
            }
            else if (dictionary.ContainsKey(input))
            {
                Console.WriteLine("This usernsme is used. Try another username");
                compairAnswer = false;
            }
            else if (!input.All(char.IsLetter) || isContaineRegEx(input))
            {
                Console.WriteLine("Username must containe only latin letter. No digits, no symbols");
                compairAnswer = false;
            }
            else { compairAnswer = true; }

            if (compairAnswer) { return true; }
            return false;
        }

        //check if the username is valid
        public bool ValidUsername(string input)
        {
            bool compairAnswer = true;
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Username can't be empty or be only from spaces");
                compairAnswer = false;
            }
            else if (input.Length < 8 || input.Length >= 13)
            {
                Console.WriteLine("Username must be from 8 to 13 characters");
                compairAnswer = false;
            }
            else if (!input.All(char.IsLetter) || isContaineRegEx(input))
            {
                Console.WriteLine("Username must containe only latin letter. No digits, no symbols");
                compairAnswer = false;
            }
            else { compairAnswer = true; }

            if (compairAnswer) { return true; }
            return false;
        }

        //check if the password is valid
        public bool ValidPassword(string input)
        {
            bool compairAnswer = true;
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Username can't be empty");
                compairAnswer = false;
            }
            else if (!input.All(char.IsLetterOrDigit))
            {
                Console.WriteLine("Password must containe only latin letter, digits and symbols");
                compairAnswer = false;
            }
            else if (input.Length >= 13 || input.Length < 8)
            {
                Console.WriteLine("Password must be from 8 to 13 characters");
                compairAnswer = false;
            }
            else { compairAnswer = true; }

            if (compairAnswer) { return true; }
            return false;

        }

        //check if the input string containe only latin letters
        public bool isContaineRegEx(string input)
        {
            string strRegex = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9] 
                        {2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input))
            {
                return true;
            }
            else { return false; }

        }

        //login
        public bool Login()
        {
            bool key = true;
            bool recall = false;
            do
            {
                key = false;
                Console.WriteLine("Enter username: ");
                string username = Console.ReadLine();
                if (userDB.ContainsKey(username))
                {
                    do
                    {
                        key = false;
                        Console.WriteLine("Enter password: ");
                        string password = Console.ReadLine();
                        if (userDB[username] == password)
                        {
                            Console.WriteLine("Login is successful");
                            key = true;
                            recall = true;
                        }
                        else
                        {
                            Console.WriteLine("Password is incorrect. Try again");
                            key = false;
                        }
                    }
                    while (!key);
                }
                else
                {
                    Console.WriteLine("Username is incorrect. Try again");
                    key = false;
                }
            }
            while (!key);
            return recall;
        }

        //add user
        public void Add(string username, string password)
        {
            userDB.Add(username, password);
        }

        //List all admins
        public void ListAdmins()
        {
            foreach (var admin in userDB)
            {
                Console.WriteLine($"Username: {admin.Key}, Password: {admin.Value}");
            }
        }
    }
    
    //create a class product manager
    public class ProductManager
    {
        //create a list to store the products
        private List<Product> products = new List<Product>();

        //add product
        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine($"Product {product.Name} was added");
        }

        //add product by type
        public void AddProduct<T>() where T : Product
        {
            Console.WriteLine("Enter product name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product price: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter product quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            if (typeof(T) == typeof(Beverage))
            {
                Console.WriteLine("Enter alcohol content: ");
                double alcoholContent = Convert.ToDouble(Console.ReadLine());
                Beverage beverage = new Beverage(name, price, quantity, alcoholContent);
                products.Add(beverage);
                Console.WriteLine($"Product {beverage.Name} was added");
            }
            else if (typeof(T) == typeof(Vegetable))
            {
                Console.WriteLine("Enter origin: ");
                string origin = Console.ReadLine();
                Vegetable vegetable = new Vegetable(name, price, quantity, origin);
                products.Add(vegetable);
                Console.WriteLine($"Product {vegetable.Name} was added");
            }
            else if (typeof(T) == typeof(Milk))
            {
                Console.WriteLine("Enter lactose content: ");
                string lactoseContent = Console.ReadLine();
                Milk milk = new Milk(name, price, quantity, lactoseContent);
                products.Add(milk);
                Console.WriteLine($"Product {milk.Name} was added");
            }
            else if (typeof(T) == typeof(Meat))
            {
                Console.WriteLine("Enter animal: ");
                string animal = Console.ReadLine();
                Meat meat = new Meat(name, price, quantity, animal);
                products.Add(meat);
                Console.WriteLine($"Product {meat.Name} was added");
            }
            else if (typeof(T) == typeof(Fish))
            {
                Console.WriteLine("Enter water type: ");
                string waterType = Console.ReadLine();
                Fish fish = new Fish(name, price, quantity, waterType);
                products.Add(fish);
                Console.WriteLine($"Product {fish.Name} was added");
            }
        }
        
        //list all products
        public void ListAllProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity} {product.UnitOfMeasure}");
            }
        }

        //list products by type
        public void ListProductsByType<T>() where T : Product
        {
            double totalQuantity = 0;
            foreach (var product in products)
            {
                if (product is T)
                {
                    totalQuantity += product.Quantity;
                    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity} {product.UnitOfMeasure}");
                }
            }
            //display the total quantity of the products
            Console.WriteLine($"Total {typeof(T).Name}s: {totalQuantity} {products.OfType<T>().FirstOrDefault()?.UnitOfMeasure}");
        }

        //remove product by name
        public void RemoveProduct(string name)
        {
            //find the product by name
            Product product = products.Find(p => p.Name == name);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine($"Product {product.Name} was removed");
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }

    }
}
