using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostWebsite.Models.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();
        Category GetCategoryById(int categoryId);
    }
}
