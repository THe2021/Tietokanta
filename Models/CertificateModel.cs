using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataBaseA.Models
{
    public class CertificateModel
    {
        public int Id { get; set; }
        public int WelderId { get; set; }
        public string CertificateName { get; set; }
        public string WelderName { get; set; }
        public string WelderCode { get; set; }
        public string Employer { get; set; }
        public string IssuingAuthority { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string ProductType { get; set; }
        public decimal? MaterialThickness { get; set; }
        public decimal? PipeDiameter { get; set; }
        public string WeldingPosition { get; set; }
        public string TestSupervisorName { get; set; }
        public string ExaminationBody { get; set; }
        public string ExaminationSignature { get; set; }
        public string Remarks { get; set; }

        public List<string> JointTypes { get; set; } = new List<string>();
        public List<string> ParentMaterials { get; set; } = new List<string>();
        public List<ProcessModel> Processes { get; set; } = new List<ProcessModel>();
    }
/*
    public class ProcessDetails
    {
        public string ProcessCode { get; set; }
        public string FillerMaterialGroup { get; set; }
        public string FillerMaterialDesignation { get; set; }
        public string FillerMaterialTradeName { get; set; }
        public string FillerMaterialType { get; set; }
        public string Polarity { get; set; }
        public string ShieldingGas { get; set; }
        public string Auxiliaries { get; set; }
        public bool IsMultilayer { get; set; }
    }
*/
}