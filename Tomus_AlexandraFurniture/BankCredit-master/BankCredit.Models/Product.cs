
namespace Furniture.Models
{
   public  class Product
    {
      

        public Product(int ID, string Title, string Description, string Color, int Size, int Price, int Stock)
        {
            this.ID = ID;
            this.Title=Title;
            this.Description=Description;
            this.Color=Color;
            this.Size=Size;
            this.Price=Price;
            this.Stock=Stock;
        }
        public Product() { }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; } 
    }
}
