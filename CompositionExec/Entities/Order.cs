using CompositionExec.Entities.Enums;
using System.Globalization;
using System.Text;

namespace CompositionExec.Entities
{
    class Order
    {
        public DateTime Moment { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }
        public List<OrderItem> Orders { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }
        public Product Product { get; set; }

        public Order() { }

        public Order(OrderStatus status, Client client)
        {
            Status = status;
            Client = client;
        }

        public void addItem(OrderItem item)
        {
            Orders.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Orders.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Orders)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine("Order moment: " + Moment);
            sb.AppendLine("Order status: " + Status);
            sb.Append("Client: " + Client.Name);
            sb.Append(" " + Client.BirthDate.ToString("dd/MM/yyyy"));
            sb.AppendLine(" - " + Client.Email);
            sb.AppendLine("Order items: ");

            foreach (OrderItem orderItem in Orders)
            {
                sb.AppendLine(orderItem.ToString());
            }

            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
