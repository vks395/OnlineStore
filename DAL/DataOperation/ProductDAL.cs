using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataOperation
{
    public class ProductDAL
    {
        private readonly OnlineStoreDbEntities dbEntities;
        public ProductDAL()
        {
            this.dbEntities = new OnlineStoreDbEntities();
        }
        public Product getProductByProductId(int ProductId)
        {
            return dbEntities.Products.Where(m => m.ProductId == ProductId).FirstOrDefault();
        }
        public List<Product> getAllProducts()
        {
            return dbEntities.Products.ToList();
        }
        public bool existingProduct(int ProductId)
        {
            var records = dbEntities.Products.Where(m => m.ProductId == ProductId).FirstOrDefault();
            if (records == null) return false;
            return true;
        }
        public string createProduct(Product Product)
        {
            if (!existingProduct(Product.ProductId))
            {
                dbEntities.Products.Add(Product);
                dbEntities.SaveChanges();
                return "New Product Added successfully !";
            }
            else
            {
                return "Product Already Exist !";
            }
        }

        public string updateProduct(Product Product)
        {
            if (existingProduct(Product.ProductId))
            {
                Product objProduct = new Product();
                var old = dbEntities.Products.Find(Product.ProductId);
                objProduct.ProductId = Product.ProductId;
                objProduct.ProductName = Product.ProductName;
                objProduct.ImageName = Product.ImageName;
                objProduct.ImagePath = Product.ImagePath;
                objProduct.Description = Product.Description;
                objProduct.Price = Product.Price;
                dbEntities.Entry(old).State = EntityState.Detached;
                dbEntities.Entry(objProduct).State = EntityState.Modified;
                dbEntities.SaveChanges();
                return "Product Updated successfully !";
            }
            else
            {
                return "Product Not Found !";
            }
        }
        public string DeleteProduct(int ProductId)
        {
            if (existingProduct(ProductId))
            {
                var records = dbEntities.Products.Where(m => m.ProductId == ProductId).FirstOrDefault();
                dbEntities.Products.Remove(records);
                dbEntities.SaveChanges();
                return "Product Deleted successfully !";
            }
            else
            {
                return "Product Not Found !";
            }
        }
    }
}
