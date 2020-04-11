using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch2_Claim
{
    public class Claim
    {
        public string ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public string DateOfIncident { get; set; }
        public string DateofClaim { get; set; }
        public bool IsValid { get; set; }


        public Claim() { }

        public Claim(string claimID, string claimType, string description, double claimAmount, string dateOFIncident, string dateOfClaim, bool isvalid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOFIncident;
            DateofClaim = dateOfClaim;
            IsValid = isvalid;
        }
    }
}
