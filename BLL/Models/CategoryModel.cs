using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public CategoryModel() { }
        public CategoryModel(Categories p)
        {
            CategoryID = p.CategoryID;
            Name = p.Name;

        }
    }
}
