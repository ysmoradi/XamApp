using Bit.Model;

namespace XamApp.Models
{
    public class Product : Bindable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public decimal Price { get; set; }
    }
}
