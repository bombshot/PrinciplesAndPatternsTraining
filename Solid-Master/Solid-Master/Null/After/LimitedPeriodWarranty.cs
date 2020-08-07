using System;

namespace Solid_Master.Null.After
{
    public class LimitedPeriodWarranty : IWarranty
    {
        private readonly DateTime _purchaseDate;
        private readonly TimeSpan _duration;

        public LimitedPeriodWarranty(DateTime purchaseDate, TimeSpan duration)
        {
            _purchaseDate = purchaseDate;
            _duration = duration;
        }
        public void Claim(DateTime claimDate, Action callback)
        {
            if (IsValidOn(claimDate))
            {
                Console.WriteLine("Claim of the Limited warranty successful");
                callback();
            }
            else
            {
                Console.WriteLine("Sorry! No Donut for you!");
            }
        }

        private bool IsValidOn(DateTime claimDate)
        {
            return _purchaseDate + _duration >= claimDate;
        }
    }
}
