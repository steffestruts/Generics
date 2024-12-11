using MainApp.Models;
using MainApp.Services;

namespace MainApp.Dialogs;

public class MenuDialog(ProductService productService, UserService userService)
{
    private readonly ProductService _productService = productService;
    private readonly UserService _userService = userService;

    public void MenuOptionsDialog()
    {
        while (true)
        {
            Dialogs.MenuHeading("MAIN MENU");
            Console.WriteLine("1. New Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. New User");
            Console.WriteLine("4. View Users");
            Console.WriteLine("-----------------------");
            var option = Dialogs.Prompt("Select option: ");
            switch (option)
            {
                case "1":
                    AddProductDialog();
                    break;
                case "2":
                    ViewProductsDialog();
                    break;
                case "3":
                    AddUserDialog();
                    break;
                case "4":
                    ViewUsersDialog();
                    break;
                // Going extra path. Trying adding a new case here, quit the application.
                case "Q":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    public void AddProductDialog()
    {
        Dialogs.MenuHeading("NEW PRODUCT");

        var product = new Product
        {
            Title = Dialogs.Prompt("Enter product title: "),
            Price = Dialogs.Prompt("Enter product price: ")
        };

        var result = _productService.SaveProduct(product);

        // Console.WriteLine("Product added successfully.");
        // Console.ReadKey();
    }

    public void ViewProductsDialog()
    {
        Dialogs.MenuHeading("PRODUCTS");

        foreach (var product in _productService.GetProducts())
        {
            Console.WriteLine($"{product.Id} - {product.Title} ({product.Price} SEK)");
        }
        Console.ReadKey();
    }

    public void AddUserDialog()
    {
        Dialogs.MenuHeading("NEW USER");

        var user = new User
        {
            Name = Dialogs.Prompt("Enter user name: "),
            LastName = Dialogs.Prompt("Enter user last name: "),
            Email = Dialogs.Prompt("Enter user email: ")
        };

        var result = _userService.SaveUser(user);

        // Console.WriteLine("User added successfully.");
        // Console.ReadKey();
    }
}
