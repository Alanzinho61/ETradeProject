using ETrade.Model.Entities;
using ETrade.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace ETrade.WebUI.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            var cartItems=GetShoppingCartItems();
            decimal total=0;
            foreach (var item in cartItems) 
            {
                total+=item.TotalAmount;
            }
            var cart = new ShoppingCart()
            {
                ShoppingCartItems = cartItems,
                TotalAmount = total
            };
            return View(cart);
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            var cartItems = HttpContext.Session.GetString("CartItems");
            if (cartItems == null)
            {
                return new List<ShoppingCartItem>();
            }
            return JsonConvert.DeserializeObject<List<ShoppingCartItem>>(cartItems);
        }

        public IActionResult AddToCart(Product p, int Quantity=1) 
        {
            //Sepetteki mevcut kayitlari getirir
            var cartItems=GetShoppingCartItems();
            // Eklenmek istenilen urunu sepete ekle
            AddProductToCart(cartItems,p,Quantity);
            // Sepeti kaydet
            SaveCartItems(cartItems);

            return RedirectToAction("Index");
        }

        private void AddProductToCart(List<ShoppingCartItem> shoppingCartItems, Product p, int quantity) 
        {
            var record=shoppingCartItems.FirstOrDefault(x=>x.Id==p.Id);
            if (record != null) 
            {
                record.Quantity += quantity;
            }
            else
            {
                shoppingCartItems.Add(new ShoppingCartItem()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ProductPrice = p.ProductPrice,
                    Quantity = quantity
                });
            }

        }

        public void SaveCartItems(List<ShoppingCartItem> shoppingCartItems)
        {
            var jsonData=JsonConvert.SerializeObject(shoppingCartItems); // Listeyi jsona donusturuldu
            HttpContext.Session.SetString("CartItems", jsonData); // Sessiona donusurulen degeri sessiona atadik
        }
        public IActionResult CartClear()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult RemoveToCart(int productId, int Quantity = 1)
        {
            var cartItems = GetShoppingCartItems();
            
            if (productId!=null)
            {
                foreach (var item in cartItems)
                {
                    item.Quantity -= 1;
                }
            }
            var a = productId;
            var b= cartItems.FirstOrDefault();
            return RedirectToAction("Index");
        }
    }
}
