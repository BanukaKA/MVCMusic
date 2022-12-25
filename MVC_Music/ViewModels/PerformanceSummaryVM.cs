using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVC_Music.ViewModels
{
    public class PerformanceSummaryVM
    {
        public int ID { get; set; }

        [Display(Name = "Musician")]
        public string FormalName { get; set; }

        [Display(Name = "Average Fee Paid")]
        [DataType(DataType.Currency)]
        public double AverageFeePaid { get; set; }

        [Display(Name = "Highest Fee Paid")]
        [DataType(DataType.Currency)]
        public double HighestFeePaid { get; set; }

        [Display(Name = "Lowest Fee Paid")]
        [DataType(DataType.Currency)]
        public double LowestFeePaid { get; set; }

        [Display(Name = "Total Number of Performances")]
        public int TotalNumberOfPerformances { get; set; }

        [Display(Name = "Total Number of Songs Performed")]
        public int TotalNumberOfPerformancesSongsPerformed { get; set; }
    }
}
