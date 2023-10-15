using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System;

namespace SportApp.Models
{
    public partial class Product
    {
        public string GetPhoto 
        {
            get
            {
                if (ProductPhoto is null)
                {
                    return Directory.GetCurrentDirectory() + @"\Images\picture.png";
                }
                return Directory.GetCurrentDirectory() + @"\Images\" + ProductPhoto.Trim();
            }
        }
        public string GetColor
        {
            get
            {
                if (ProductDiscountAmount > 15)
                    return "#7fff00";
                else
                    return "fff";
            }
        }
        public double GetPriceWithDiscount
        {
            get
            {
                double p = Convert.ToDouble(ProductCost);
                byte d = Convert.ToByte(ProductDiscountAmount);
                return p * (100 - d) / 100;
            }
        }
        public string GetVisibility
        {
            get
            {
                if (ProductDiscountAmount > 0)
                    return "Visible";
                return "Collapsed";
            }
        }
        public string GetCountInStock
        {
            get
            {
                return $"в наличии на складе{ProductQuantityInStock} {UnitType.UnitTypeName}";
            }
        }
    }
}
