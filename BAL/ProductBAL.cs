using DAL;
using DAL.DataOperation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class ProductBAL
    {
        private readonly ProductDAL ProductDal;
        public ProductBAL()
        {
            this.ProductDal = new ProductDAL();
        }
        public Product getProductByProductId(int ProductId)
        {
            try
            {
                return ProductDal.getProductByProductId(ProductId);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<Product> getAllProducts()
        {
            try
            {
                return ProductDal.getAllProducts();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool existingProduct(int ProductId)
        {
            try
            {
                return ProductDal.existingProduct(ProductId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string createProduct(Product Product)
        {
            try
            {
                return ProductDal.createProduct(Product);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string updateProduct(Product Product)
        {
            try
            {
                return ProductDal.updateProduct(Product);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string DeleteProduct(int ProductId)
        {

            try
            {
                return ProductDal.DeleteProduct(ProductId);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
