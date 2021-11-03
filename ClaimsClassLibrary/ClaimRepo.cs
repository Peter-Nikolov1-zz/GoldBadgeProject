using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsClassLibrary
{
    public class ClaimRepo
    {
        protected readonly Queue<Claim> claims = new Queue<Claim>();
        public Queue<Claim> SeeAllClaims()
        {
            return claims;
        }

        public Claim NextClaim()
        {
            return claims.Peek();
        }

        public bool AddClaimToList(Claim claim)
        {
            int startingCount = claims.Count;
            claims.Enqueue(claim);
            bool wasAdded = claims.Count > startingCount ? true : false;
            return wasAdded;
        }

        public void DequeueClaim()
        {
            claims.Dequeue();
        }
    }
}
