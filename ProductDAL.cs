using MVCCRUDOnlineShoppign.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestMVC.Models;

namespace TestMVC.DAL
{
    public class ProductDAL
    {
        DBOperations DB = new DBOperations();
        public List<Product> GetAllProduct()
        {
            List<Product> lstProduct = null;
            try
            {
                DataSet ds = new DataSet();
                ds = DB.FillData("SelectAllProduct");
                lstProduct = ds.Tables[0].ToList<Product>();

            }
            catch (Exception ex)
            {

            }
            return lstProduct;
        }

        public Product GetProductBYID(int pid)
        {
            List<Product> lstProduct = null;
            SqlParameter[] spCol = new SqlParameter[]
            {
                new SqlParameter("pid",pid)
            };
            try
            {
                DataSet ds = new DataSet();
                ds = DB.FillDataByID("SelectProductDetails",spCol);
                lstProduct = ds.Tables[0].ToList<Product>();

            }
            catch (Exception ex)
            {

            }
            var product = (from pro in lstProduct
                           select pro).SingleOrDefault();
            return product;
        }

        public int AddProduct(Product objProduct)
        {
            int reuslt = 0;
            SqlParameter[] spCol = new SqlParameter[]
            {
                new SqlParameter("cid",objProduct.cid),
                new SqlParameter("pname",objProduct.pname),
                new SqlParameter("pprice",objProduct.pprice),
                new SqlParameter("pdescription",objProduct.pdescription),
                new SqlParameter("images",objProduct.images),
                new SqlParameter("Quantity",objProduct.Quantity),
                new SqlParameter("AddedBy",objProduct.AddedBy),
                new SqlParameter("AddedOn",objProduct.AddedOn),                
                new SqlParameter("ImageURL",objProduct.ImageURL),
            };
            reuslt = DB.InsertUpdateDelete("AddProduct", spCol);
            return reuslt;
        }

        public int UpdateProduct(Product objProduct)
        {
            int result = 0;
            SqlParameter[] spCol = new SqlParameter[]
            {
                new SqlParameter("cid",objProduct.cid),
                new SqlParameter("pname",objProduct.pname),
                new SqlParameter("pprice",objProduct.pprice),
                new SqlParameter("pdescription",objProduct.pdescription),
                new SqlParameter("images",objProduct.images),
                new SqlParameter("Quantity",objProduct.Quantity),
                new SqlParameter("UpdateBy",objProduct.UpdateBy),
                new SqlParameter("UpdateOn",objProduct.UpdateOn),
                new SqlParameter("ImageURL",objProduct.ImageURL),
                new SqlParameter("pid",objProduct.pid),

            };
            result = DB.InsertUpdateDelete("UpdateProduct", spCol);
            return result;
        }

        public int DeleteProduct(int pid)
        {
            int result = 0;
            SqlParameter[] spCol = new SqlParameter[]
            {
                new SqlParameter("pid",pid),
            };
            result = DB.InsertUpdateDelete("DeleteProduct", spCol);
            return result;
        }
    }
}