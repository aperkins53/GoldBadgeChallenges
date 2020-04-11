using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch2_Claim
{
    //The Dequeue and Peek methods do not work properly. Andrew and I looked at it for a good
    //30 mins and couldnt find any problems
    public class ClaimRepo
    {
        private Queue<Claim> _claimQueue = new Queue<Claim>();

        //see all claims
        public Queue<Claim> GetClaimQueue()
        {
            return _claimQueue;
        }

        //take care of next claim
        public void DequeueNextClaim()
        {
           _claimQueue.Dequeue();
        }

        //enter a new claim
        public void EnterNewClaim(Claim claim)
        {
            _claimQueue.Enqueue(claim);
        }

        //helper for taking care of the next claim
        public void SeeNextClaimInQueue()
        {
            Console.WriteLine(_claimQueue.Peek());
        }
    }
}
