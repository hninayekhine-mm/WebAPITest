using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    public class ProductController : ApiController
    {
        private string errorMessage { get; set; }


        [Route("api/Products/GetProducts")]
        [HttpPost]
        public EventView GetProducts(EventView eventView)
        {
            EventView eventResult = new EventView();
            List<ProductView> productViewList = new List<ProductView>();
            if (IsValidQuery(eventView))
            {
                Event eventModel = MapToEvent(eventView);
                List<Product> productList = MapToProduct(eventView.id, eventView.products);

                ProductDataAccess productData = new ProductDataAccess();
                productViewList = MapToProductView(productData.GetByEventAndProductId(eventView.id, productList));
            }

            if (productViewList.Count > 0)
            {
                eventResult.id = eventView.id;
                eventResult.timestamp = eventView.timestamp;
                eventResult.products = productViewList;
                eventResult.message = "Product(s) info has been retrieved successfully.";
            }
            else
            {
                eventResult.message = "There is no product that match your query.";
            }

            return eventResult;
        }
        
        [Route("api/Products/PutProducts")]
        [HttpPost]
        public string PutProducts(EventView eventView)
        {
            string result = string.Empty;
            bool isEventCreated = false;
            bool isProductCreated = false;

            if (IsValid(eventView))
            {
                Event newEvent = MapToEvent(eventView);
                List<Product> productList = MapToProduct(eventView.id, eventView.products);

                ProductDataAccess productData = new ProductDataAccess();
                foreach (Product p in productList)
                {
                    isProductCreated = productData.Add(p);
                    if (!isProductCreated) break;
                }

                if (isProductCreated)
                {
                    EventDataAccess eventData = new EventDataAccess();
                    isEventCreated = eventData.Add(newEvent);

                    if (isEventCreated)
                        result = "Product(s) info has been created successfully.";
                    else
                        result = "Product(s) info creation was failed.";
                }
                else
                {
                    result = "Product(s) info creation was failed.";
                }
            }
            else
            {
                result = "Product(s) info can't be created. " + this.errorMessage;
            }

            return result;
        }

        #region Validation
        public bool IsValid(EventView eventView)
        {
            List<string> errorList = new List<string>();
            bool isValid = true;

            // All fields must be included

            // event id
            string tmpId = eventView.id.Trim();
            if (String.IsNullOrEmpty(eventView.id))
            {
                isValid = false;
                errorList.Add("Event id is required.");
            }

            // event timestamp
            DateTime tmpTS;
            if (eventView.timestamp == null || DateTime.Compare(eventView.timestamp, DateTime.MinValue) == 0)
            {
                isValid = false;
                errorList.Add("Event timestamp is required. Format should be 'yyyy-MM-ddTHH:mm:ssZ'.");
            }
            else
            {
                if (!DateTime.TryParse(eventView.timestamp.ToString("yyyy-MM-ddTHH:mm:ssZ"), out tmpTS))
                {
                    isValid = false;
                    errorList.Add("Event timestamp format is not correct. It should be in 'yyyy-MM-ddTHH:mm:ssZ' format.");
                }
            }
            
            // products
            if (eventView.products == null || eventView.products.Count == 0)
            {
                isValid = false;
                errorList.Add("At least one product is required.");
            }
            else
            {
                int productSN = 1;
                foreach(ProductView pv in eventView.products)
                {
                    if (pv.id == 0)
                    {
                        isValid = false;
                        errorList.Add("Product SN: " + productSN + ": Product id is required.");
                    }                        

                    if (string.IsNullOrEmpty(pv.name))
                    {
                        isValid = false;
                        errorList.Add("Product SN: " + productSN + ": Product name is required.");
                    }   

                    if (pv.quantity == 0)
                    {
                        isValid = false;
                        errorList.Add("Product SN: " + productSN + ": Product quantity is required.");
                    }
                        
                    if (pv.sale_amount == 0)
                    {
                        isValid = false;
                        errorList.Add("Product SN: " + productSN + ": Product sale amount is required.");
                    }

                    productSN++;
                }
            }

            this.errorMessage = String.Join(",", errorList);
            return isValid;
        }

        public bool IsValidQuery(EventView eventView)
        {
            List<string> errorList = new List<string>();
            bool isValid = true;

            // event id
            string tmpId = eventView.id.Trim();
            if (String.IsNullOrEmpty(eventView.id))
            {
                isValid = false;
                errorList.Add("Event id is required.");
            }

            // products
            if (eventView.products == null || eventView.products.Count == 0)
            {
                isValid = false;
                errorList.Add("At least one product is required.");
            }
            else
            {
                int productSN = 1;
                foreach (ProductView pv in eventView.products)
                {
                    if (pv.id == 0)
                    {
                        isValid = false;
                        errorList.Add("Product SN: " + productSN + ": Product id is required.");
                    }
                }
            }
            return isValid;
        }
        #endregion

        #region Map to View Model       
        public List<ProductView> MapToProductView(List<Product> products)
        {
            List<ProductView> productViewList = new List<ProductView>();
            ProductView productView;

            foreach (Product p in products)
            {
                productView = new ProductView();
                productView.id = p.ProductId;
                productView.name = p.ProductName;
                productView.quantity = p.Quantity;
                productView.sale_amount = Convert.ToDouble(p.SaleAmount);
                productViewList.Add(productView);
            }

            return productViewList;
        }
                
        #endregion

        #region Map to DB Model
        public List<Product> MapToProduct(string eventId, List<ProductView> productViews)
        {
            List<Product> productList = new List<Product>();
            Product productModel;

            foreach (ProductView pv in productViews)
            {
                productModel = new Product();
                productModel.EventId = eventId;
                productModel.ProductId = pv.id;
                productModel.ProductName = pv.name;
                productModel.Quantity = pv.quantity;
                productModel.SaleAmount = Convert.ToDecimal(pv.sale_amount);
                productList.Add(productModel);
            }

            return productList;
        }

        public Event MapToEvent(EventView eventView)
        {
            Event eventModel = new Event();
            eventModel.EventId = eventView.id;
            eventModel.EventTimestamp = eventView.timestamp;

            return eventModel;
        }
        #endregion
    }
}
