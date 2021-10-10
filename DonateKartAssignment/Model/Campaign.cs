using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateKartAssignment.Model
{
    public class Campaign
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public bool Featured { get; set; }
        public int Priority { get; set; }
        public string ShortDesc { get; set; }
        public string ImageSrc { get; set; }
        public DateTime Created { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalAmount { get; set; }
        public double ProcuredAmount { get; set; }
        public double TotalProcured { get; set; }
        public double BackersCount { get; set; }
        public string CategoryId { get; set; }
        public string Location { get; set; }
        public string NGOCode { get; set; }
        public string NGOName { get; set; }
        public int DaysLeft { get; set; }
        public double Percentage { get; set; }
    }
}
