using Pustok2.ViewModel.ProductVM;
using Pustok2.ViewModel.SliderVM;

namespace Pustok2.ViewModel.HomeVm
{
    public class HomeVm
    {
        public IEnumerable<SliderListItemVM> Sliders { get; set; }
        public IEnumerable<ProductListVM> Products { get; set; }
    }
}
