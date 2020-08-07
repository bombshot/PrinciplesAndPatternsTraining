using System;

namespace Solid_Master.Null.Before
{
    public class SoldArticle
    {
        private readonly DateTime _purchasedDate;
        private readonly TimeSpan _duration;
        private readonly bool _isLifeTime;
        private bool _isVoid;

        //Looks like the Domain object SoldArticle is mixed up with the Warranty logic
        // Any new requirement will make this harder to maintain and more buggy
        public SoldArticle(DateTime purchasedDate, TimeSpan duration, bool isLifeTime)
        {
            _purchasedDate = purchasedDate;
            _duration = duration;
            _isLifeTime = isLifeTime;
        }

        public void VisibleDamageDone()
        {
            _isVoid = true;
        }

        public void Claim(DateTime claimDate)
        {
            Console.WriteLine(IsValidOn(claimDate)
                ? "Claim of the limited warranty successful"
                : "Sorry dude! No Donut for you!");
        }

        private bool IsValidOn(DateTime claimDate)
        {
            if (_isLifeTime) return true;
            if (_isVoid) return false;
            
            return _purchasedDate + _duration >= claimDate;
        }
    }
}