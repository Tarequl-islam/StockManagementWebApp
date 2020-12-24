using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.DAL
{
    public class CategoryManger
    {
        CategoryGateway categoryGateway = new CategoryGateway();

        public string Save(Category category)
        {
            if (categoryGateway.IsNameExist(category.Name))
            {
                return "Category already Exist";
            }
            else
            {
                int rowAffect = categoryGateway.Save(category);
                if (rowAffect > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
            
        }

        public List<Category> GetAllCategories()
        {
            return categoryGateway.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return categoryGateway.GetCategoryById(id);
        }

        public int Update(Category category)
        {
            return categoryGateway.Update(category);
        }

    }
}