using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDataAccess
    {
        #region Add - if productId is already existed, update product info, else create a new product.
        public bool Add(Product productData)
        {
            bool result;

            try
            {
                using (WebAPITestEntities entities = new WebAPITestEntities())
                {
                    Product tmpProduct = entities.Products.FirstOrDefault(e => e.ProductId == productData.ProductId);
                    if (tmpProduct != null)
                    {
                        //Update existing product
                        tmpProduct.ProductId = productData.ProductId;
                        tmpProduct.ProductName = productData.ProductName;
                        tmpProduct.Quantity = productData.Quantity;
                        tmpProduct.SaleAmount = productData.SaleAmount;
                        entities.Products.Attach(tmpProduct);
                        entities.Entry(tmpProduct).State = EntityState.Modified;
                    }
                    else
                    {
                        //Create a new product
                        entities.Products.Add(productData);
                    }
                    entities.SaveChanges();
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
        #endregion

        #region GetAllByFilter
        public List<Product> GetByEventAndProductId(string eventId, List<Product> productIdList)
        {
            List<Product> productList = new List<Product>();
            List<Product> tempList = new List<Product>();
            Product product;

            try
            {
                using (WebAPITestEntities entities = new WebAPITestEntities())
                {
                    foreach (Product p in productIdList)
                    {
                        product = new Product();
                        product = entities.Products.FirstOrDefault(pe => pe.EventId == eventId && pe.ProductId == p.ProductId);

                        if (product != null)
                            productList.Add(product);
                    }
                }
            }
            catch (Exception)
            {
                //log error.
            }

            return productList;
        }
        #endregion

    }
}
