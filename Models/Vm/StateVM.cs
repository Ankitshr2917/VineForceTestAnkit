using Microsoft.AspNetCore.Mvc.Rendering;

namespace VineForceTestAnkit.Models.Vm
{
    public class StateVM
    {
        public IEnumerable< SelectListItem>  CountryList { get; set; }
        public StatewithCounrtry StatewithCounrtry { get; set; }
    }
}
