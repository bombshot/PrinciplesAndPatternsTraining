using System;

namespace Solid_Master.Null.After
{
    //This class can be a singleton as it does not have any state.
    // It only represents the Null object behavior
    public class VoidWarranty: IWarranty
    {
        //This will ensure thread safety
        private static readonly VoidWarranty _instance = new VoidWarranty();

        private VoidWarranty()
        {
        }

        public static VoidWarranty Instance
        {
            get { return _instance; }
        }

        public void Claim(DateTime claimDate, Action callback)
        {
            Console.WriteLine("Sorry! You broke it! Warranty has been voided");
            callback();
        }
    }
}
