using CompositionExec.Entities;
using CompositionExec.Entities.Enums;
using System.Globalization;

namespace CompositionExec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime brthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, brthDate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());            

            Order order = new Order(status, client);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string pName = Console.ReadLine();
                Console.Write("Product price: ");
                double pPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int qtd = int.Parse(Console.ReadLine());                
                Product product = new Product(pName, pPrice);
                OrderItem orderItem = new OrderItem(qtd, pPrice, product);
                order.addItem(orderItem);
            }
                        
            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}