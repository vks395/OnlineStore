using BAL;

using DAL;
using DAL.DataOperation;

using OnlineStore.ActionFilters;
using OnlineStore.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    
    public class ProductsController : OnlineStoreBaseController
    {
        private readonly ProductBAL ProductBal;
        string[] allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
        public ProductsController()
        {
            ProductBal = new ProductBAL();

        }
        // GET: Products 
        [CustomAuthorizeAttribute(Roles = "customers,sellers,administrators")]
        public ActionResult ProductsDetails()
        {
            var ProductRecord = ProductBal.getAllProducts();
            List<ProductVM> ProductList = new List<ProductVM>();
            foreach (var Productdata in ProductRecord)
            {
                ProductVM objProduct = BindProductVM(Productdata);
                ProductList.Add(objProduct);

            }
            return View(ProductList);
        }
        [CustomAuthorizeAttribute(Roles = "sellers")]
        public ActionResult ProductsAdd()
        {
            ProductVM Product = new ProductVM();
            return View(Product);
        }

        [CustomAuthorizeAttribute(Roles = "sellers")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductsAdd(ProductVM product, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
               
                
                
                if (product.ProductId == 0)
                {
                   
                    TempData["msg"] = "";
                    if (!ProductBal.existingProduct(product.ProductId))
                    {
                        if (file != null)
                        {
                            var ext = Path.GetExtension(file.FileName);
                            if (allowedExtensions.Contains(ext))
                            {


                                //saving new image 
                                string path = ImageSave(file);
                                product.ImageName = file.FileName;
                                product.ImagePath = path;
                            }
                            else
                            {
                                TempData["msg"] = "Not Valid File !";
                                return View(product);
                            }
                        }
                        Product objProduct = BindProductData(product);
                        //create new record of Product
                        TempData["msg"] = ProductBal.createProduct(objProduct);
                    }
                    return RedirectToAction("ProductsDetails");
                }


                return View(product);
            }


            return View(product);
        }

        private string ImageSave(HttpPostedFileBase file)
        {
            string id = Guid.NewGuid().ToString();
            var originalDirectory = new DirectoryInfo(string.Format("{0}UploadedImages\\images", Server.MapPath(@"\write\")));
            string pathString = System.IO.Path.Combine(originalDirectory.ToString(), id);
            bool isExists = System.IO.Directory.Exists(pathString);
            if (!isExists)
                System.IO.Directory.CreateDirectory(pathString);
            var path = string.Format("{0}\\{1}", pathString, file.FileName);
            file.SaveAs(path);
         

            return path;
        }
        private static void DeleteOldImage(ProductVM product, HttpPostedFileBase file)
        {
            var originalDirectorynew = new DirectoryInfo(product.ImagePath.Replace(@"\" + product.ImageName, ""));
            System.IO.FileInfo[] files = originalDirectorynew.GetFiles();
            foreach (var filenew in files)
            {
                if (filenew.Name != file.FileName)
                    filenew.Delete();
            }
        }
        [CustomAuthorizeAttribute(Roles = "sellers")]
        public ActionResult ProductsDelete(int ProductId)
        {
            if (ProductBal.existingProduct(ProductId))
            {
                TempData["msg"] = ProductBal.DeleteProduct(ProductId);
            }
            else
            {
                TempData["msg"] = "Not Found";
            }
            return RedirectToAction("ProductsDetails");
        }
        [CustomAuthorizeAttribute(Roles = "sellers")]
        public ActionResult ProductsEdit(int ProductId)
        {

            ProductVM objProduct = new ProductVM();
            var Productdata = ProductBal.getProductByProductId(ProductId);
            objProduct=BindProductVM(Productdata);
            return View(objProduct);
        }
        [CustomAuthorizeAttribute(Roles = "sellers")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductsEdit(ProductVM product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (product.ProductId!=0)
                {
                   
                    Product objProduct = BindProductData(product);
                    TempData["msg"] = "";
                    if (ProductBal.existingProduct(product.ProductId))
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            var ext = Path.GetExtension(file.FileName);
                            if (allowedExtensions.Contains(ext))
                            {
                                if (file != null && string.IsNullOrEmpty(product.ImagePath))
                                {

                                    string path = ImageSave(file);
                                    objProduct.ImageName = file.FileName;
                                    objProduct.ImagePath = path;
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(product.ImagePath) && file != null && file.ContentLength > 0)
                                    {//deleting existing image of same path and image
                                        DeleteOldImage(product, file);
                                        string path = ImageSave(file);
                                        objProduct.ImageName = file.FileName;
                                        objProduct.ImagePath = path;
                                    }

                                }
                            }
                            else
                            {
                                TempData["msg"] = "Not Valid File !";
                                return View(product);
                            }
                        }

                        TempData["msg"] = ProductBal.updateProduct(objProduct);
                    }
                    return RedirectToAction("ProductsDetails");
                }


                return View(product);
            }
            return View(product);
        }

		

		private static ProductVM BindProductVM(Product Productdata)
        {
            ProductVM objProduct = new ProductVM();
            objProduct.ProductId = Productdata.ProductId;
            objProduct.ProductName = Productdata.ProductName;
            objProduct.ImageName = Productdata.ImageName;
            objProduct.ImagePath = Productdata.ImagePath;
            objProduct.Description = Productdata.Description;
            objProduct.Price = Productdata.Price;
            return objProduct;
        }
        private static Product BindProductData(ProductVM product)
        {
            Product objProduct = new Product();
            objProduct.ProductId = product.ProductId;
            objProduct.ProductName = product.ProductName;
            objProduct.ImageName = product.ImageName;
            objProduct.ImagePath = product.ImagePath;
            objProduct.Description = product.Description;
            objProduct.Price = product.Price;
            return objProduct;
        }
        //[HttpPost]
        //[AllowAnonymous]
        //public JsonResult deleteProductRecord(int ProductId)
        //{
        //    if (ProductBal.existingProduct(ProductId))
        //    {
        //        //TempData["msg"] = ProductBal.DeleteProduct(ProductId);
        //        return Json(new { Result = "success" }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { Result = "failed" }, JsonRequestBehavior.AllowGet);
        //    }
        //    //var result = SVWrapper.UpdateReturnToRequesterList(wOIds, Comments);
        //    //if (result)
        //    //{
        //    //    return Json(new { Result = JsonReturnEnum.success.ToString() }, JsonRequestBehavior.AllowGet);
        //    //}
        //    //else
        //    //{
        //    //    return Json(new { Result = JsonReturnEnum.failed.ToString() }, JsonRequestBehavior.AllowGet);
        //    //}
        //}
    }
}