using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Learning.Entities
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string ClaimNumber { get; set; }
        public int PersonId { get; set; }
        public DateTime ClaimDate { get; set; }
        public decimal Amount { get; set; }

        public Person Person { get; set; }

        public Claim()
        {
            
        }

        public Claim(Claim claim)
        {
            ClaimId = claim.ClaimId;
            ClaimNumber = claim.ClaimNumber;
            PersonId = claim.PersonId;
            ClaimDate = claim.ClaimDate;
            Amount = claim.Amount;
        }
    }
}
