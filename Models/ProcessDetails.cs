using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseA.Models
{
    public class ProcessDetails
    {
        public string ProcessCode { get; set; }
        public string FillerMaterialGroup { get; set; }
        public string FillerMaterialDesignation { get; set; }
        public string FillerMaterialTradeName { get; set; }
        public string FillerMaterialType { get; set; }
        public string Polarity { get; set; }
        public string Auxiliaries { get; set; }
        public string ShieldingGas { get; set; }
        public decimal? DepositedThickness { get; set; }
        public bool IsMultilayer { get; set; }
        public string WeldDetails { get; set; }
    }
}
