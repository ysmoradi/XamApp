using Acr.UserDialogs;
using Bit.ViewModel;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamApp.Models;

namespace XamApp.ViewModels
{
    public class ProductsViewModel : BitViewModelBase
    {
        public ProductsViewModel()
        {
            ShowProductDetailsCommand = new BitDelegateCommand<Product>(ShowProductDetails);
        }

        public BitDelegateCommand<Product> ShowProductDetailsCommand { get; set; }
        public List<Product> Products { get; set; }

        public IUserDialogs UserDialogs { get; set; }

        public async override Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            Products = new List<Product> // getting products from server or sqlite database
            {
                new Product { Id = 1, IsActive = true, Name = "Product1" , Price = 12.2m /* m => decimal */ },
                new Product { Id = 2, IsActive = false, Name = "Product2" , Price = 14 },
                new Product { Id = 3, IsActive = true, Name = "Product3" , Price = 11 },
            };

            await base.OnNavigatedToAsync(parameters);
        }

        async Task ShowProductDetails(Product product)
        {
            string productDetail = $"Product: {product.Name}'s more info: ..."; // get more info from server.
            await UserDialogs.AlertAsync(productDetail, "Product Detail");
        }
    }
}
