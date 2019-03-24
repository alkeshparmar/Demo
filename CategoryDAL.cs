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
    public class CategoryDAL
    {
        DBOperations DB = new DBOperations();
        public List<Category> GetAllCategory()
        {
            List<Category> lstCategory = null;
            try
            {
                DataSet dsCategory = new DataSet();
                dsCategory = DB.FillData("SelectAllCategory");
                lstCategory = dsCategory.Tables[0].ToList<Category>();
            }
            catch (Exception ex)
            {

            }
            return lstCategory;
        }

        public Category GetCategoryBYID(int cid)
        {
            List<Category> lstCategory = null;
            SqlParameter[] spCol = new SqlParameter[]
            {
                new SqlParameter("cid",cid),
            };
            try
            {
                DataSet dsCategory = new DataSet();
                dsCategory = DB.FillDataByID("SelectCategoryDetails",spCol);
                lstCategory = dsCategory.Tables[0].ToList<Category>();
            }
            catch (Exception ex)
            {

            }

            var category = (from cat in lstCategory
                            select cat).SingleOrDefault();

            return category;
        }


        public int AddCategory(Category objCategory)
        {
            int result = 0;
            SqlParameter[] spCol = new SqlParameter[]
            {
                 new SqlParameter("cname",objCategory.cname),
                new SqlParameter("cdescription", objCategory.cdescription),
                new SqlParameter("AddedBy", objCategory.AddedBy),
                new SqlParameter("AddedOn", objCategory.AddedOn),
            };
            result = DB.InsertUpdateDelete("AddCategory", spCol);
            return result;
        }

        public int UpdateCategory(Category objCategory)
        {
            int result = 0;
            SqlParameter[] spCol = new SqlParameter[]
            {
                 new SqlParameter("cname",objCategory.cname),
                new SqlParameter("cdescription", objCategory.cdescription),
                new SqlParameter("UpdateBy", objCategory.UpdateBy),
                new SqlParameter("UpdateOn", objCategory.UpdateOn),
                new SqlParameter("cid", objCategory.cid),
            };
            result = DB.InsertUpdateDelete("UpdateCategory", spCol);
            return result;
        }

        public int DeleteCategory(int cid)
        {
            int result = 0;
            SqlParameter[] spCol = new SqlParameter[]
            {                
                new SqlParameter("cid", cid),
            };
            result = DB.InsertUpdateDelete("DeleteCategory", spCol);
            return result;
        }
    }
}