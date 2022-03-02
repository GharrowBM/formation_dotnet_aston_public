namespace CaisseEnregistreuse.Models
{
    public class Sale
    {
        public static int Count;
        public int Id { get; set; }
        public DateTime DateOfSale { get; set; }
        public List<Product> Products { get; set; }
        public Client Client { get; set; }
        public decimal Total 
        { 
            get 
            {
                decimal total = 0;

                foreach (var item in Products) total += item.Price;

                return total;
            } 
        }

        public Sale()
        {
            Id = ++Count;
            Products = new List<Product>();
            DateOfSale = DateTime.Now;
        }
    }
}
