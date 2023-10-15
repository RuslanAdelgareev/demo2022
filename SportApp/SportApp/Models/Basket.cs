using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace SportApp.Models
{
    public class Basket
    {
        public struct BuyItem
        {
            public int Count { get; set; }
            public double Total { get; set; }
        }
        public static Dictionary<Product, BuyItem> GetBasket { get; } = new Dictionary<Product, BuyItem>();
        public static void AddProductInBasket(Product product)
        {
            if (GetBasket.ContainsKey(product))
            {
                int k = GetBasket[product].Count + 1;
                double p = Convert.ToDouble(product.GetPriceWithDiscount) * k;
                GetBasket[product] = new BuyItem { Count = k, Total = p };
            }
            else
            {
                double p = Convert.ToDouble(product.GetPriceWithDiscount);
                GetBasket[product] = new BuyItem { Count = 1, Total = p };
            }
        }
        public static void SetCount(Product product, int count)
        {
            if (GetBasket.ContainsKey(product))
            {
                int k = count;
                double p = Convert.ToDouble(product.GetPriceWithDiscount) * k;
                GetBasket[product] = new BuyItem { Count = k, Total = p };
                if (k <= 0)
                {
                    GetBasket.Remove(product);
                }
            }

        }
        public static void DeleteProductFromBasket(Product product)
        {
            if (GetBasket.ContainsKey(product))
            {
                GetBasket.Remove(product);
            }
        }
        public static double GetTotalCost
        {
            get
            {
                double sum = 0;
                foreach (var item in GetBasket)
                {
                    sum += item.Value.Total;
                }
                return sum;
            }
        }
        public static int GetCount
        {
            get
            {
                return GetBasket.Count;
            }
        }
        public static bool IsOnStock
        {
            get
            {
                foreach (var item in GetBasket)
                {
                    if (item.Key.ProductQuantityInStock < 3)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
    }

