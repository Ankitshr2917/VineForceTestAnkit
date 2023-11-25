using System.ComponentModel.DataAnnotations;

namespace VineForceTestAnkit.Models
{
    public class StatewithCounrtry
    {
        public int id { get; set; }
        public string Name { get; set; }
        [Display(Name ="Country")]
        public int Countryid { get; set; }
        public Country Country { get; set; }
    }
}
