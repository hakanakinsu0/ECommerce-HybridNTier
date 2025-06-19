using Project.Entities.Models;

namespace Project.MvcUI.Areas.Admin.Models.PageVms
{
    public class CreateProductPageVm
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}
