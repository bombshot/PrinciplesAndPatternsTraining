using System;

namespace Solid_Master.Null.After
{
    public class LifeTimeWarranty: IWarranty
    {
        private readonly DateTime _purchaseDate;

        public LifeTimeWarranty(DateTime purchaseDate)
        {
            _purchaseDate = purchaseDate;
        }

        public void Claim(DateTime claimDate, Action callback)
        {
            if (IsValidOn(claimDate))
            {
                Console.WriteLine("Claim of the Lifetime warranty successful");
                callback();
            }
            else
            {
                Console.WriteLine("Sorry! No Donut for you!");    
            }
        }

        private bool IsValidOn(DateTime claimDate)
        {
            return _purchaseDate <= claimDate;
        }
    }
}
