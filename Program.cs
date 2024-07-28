using MyClass;

UserDB userDB = new UserDB();
userDB.Add("admin2", "admin2");
userDB.ListAdmins();

bool key = true;

ProductManager productDB = new ProductManager();
Beverage beer = new Beverage("Carlsberg", 5, 10, 5.2);
Vegetable tomato = new Vegetable("Tomato", 2, 10, "Spain");
Milk milk = new Milk("Milk", 1, 10, "lactose free");
Meat beef = new Meat("Beef", 10, 10, "Argentina");
Fish fish = new Fish("Salmon", 15, 10, "Norway");
productDB.AddProduct(beer);
productDB.AddProduct(tomato);
productDB.AddProduct(milk);
productDB.AddProduct(beef);
productDB.AddProduct(fish);

do
{
    key = false;
    Console.WriteLine("Welcome to the Store Inventory System. \n\nSelect next action: \n 1 --> SignIn; \n 2 --> LogIn \n E --> exit store");
    string action = Console.ReadLine().ToUpper();

    switch (action)
    {
        case "1":
            userDB.SignIn();
            key = false;
            break;
        case "2":
            key = false;
            if (userDB.Login() == true)
            {
                do
                {
                    key = false;
                    Console.WriteLine("Select: \n 1 ==> All products; \n 2 ==> All products by type \n 3 ==> add product \n 4 ==> remove product \n E ==> exit to previouse menu");
                    string answer = Console.ReadLine().ToUpper();
                    switch (answer)
                    {
                        //show all products
                        case "1":
                            productDB.ListAllProducts();
                            key = false;
                            break;
                        //show products by type
                        case "2":
                            key = false;
                            bool SPkey = false;
                            do
                            {
                                key = false;
                                SPkey = false;
                                Console.WriteLine("Select product type: \n 1 ==> Beverage; \n 2 ==> Vegetable; \n 3 ==> Milk; \n 4 ==> Meat; \n 5 ==> Fish; \n E ==> exit to previouse menu");
                                string userChoice = Console.ReadLine().ToUpper();
                                switch (userChoice)
                                {
                                    case "1":
                                        productDB.ListProductsByType<Beverage>();
                                        SPkey = false;
                                        break;
                                    case "2":
                                        productDB.ListProductsByType<Vegetable>();
                                        SPkey = false;
                                        break;
                                    case "3":
                                        productDB.ListProductsByType<Milk>();
                                        SPkey = false;
                                        break;
                                    case "4":
                                        productDB.ListProductsByType<Meat>();
                                        SPkey = false;
                                        break;
                                    case "5":
                                        productDB.ListProductsByType<Fish>();
                                        SPkey = false;
                                        break;
                                    case "E":
                                        SPkey = true;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input. Please try again.");
                                        SPkey = false;
                                        break;
                                }
                            }
                            while (!SPkey);
                            break;
                        //add product
                        case "3":
                            key = false;
                            bool APkey = false;
                            do
                            {
                                Console.WriteLine("Select product type: \n 1 ==> Beverage; \n 2 ==> Vegetable; \n 3 ==> Milk; \n 4 ==> Meat; \n 5 ==> Fish; \n E ==> exit to previouse menu");
                                string answer2 = Console.ReadLine().ToUpper();
                                switch (answer2)
                                {
                                    case "1":
                                        productDB.AddProduct<Beverage>();
                                        APkey = false;
                                        break;
                                    case "2":
                                        productDB.AddProduct<Vegetable>();
                                        APkey = false;
                                        break;
                                    case "3":
                                        productDB.AddProduct<Milk>();
                                        APkey = false;
                                        break;
                                    case "4":
                                        productDB.AddProduct<Meat>();
                                        APkey = false;
                                        break;
                                    case "5":
                                        productDB.AddProduct<Fish>();
                                        APkey = false;
                                        break;
                                    case "E":
                                        APkey = true;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input. Please try again.");
                                        APkey = false;
                                        break;
                                }
                            }
                            while (!APkey);
                            break;
                        //remove product
                        case "4":
                            Console.WriteLine("Select product to remove: ");
                            string userAnswer = Console.ReadLine().ToLower();
                            productDB.RemoveProduct(userAnswer);
                            break;
                        //exit to previouse menu
                        case "E":
                            key = true;
                            break;
                    }
                }
                while (!key);
            }
            break;
        //exit store
        case "E":
            Console.WriteLine("Thank you for using the Store Inventory System. Goodbye!");
            key = true;
            break;
        default:
            Console.WriteLine("Invalid input. Please try again.");
            key = false;
            break;
    }   
}
while (!key);

