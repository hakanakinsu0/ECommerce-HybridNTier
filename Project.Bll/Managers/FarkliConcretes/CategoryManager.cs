using Project.Bll.Managers.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.FarkliConcretes
{
    public class CategoryManager : BaseMongoManager<Category>, ICategoryManager
    {
    }
}
