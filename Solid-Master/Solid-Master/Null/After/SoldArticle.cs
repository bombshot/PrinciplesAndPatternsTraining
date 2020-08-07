using System;

namespace Solid_Master.Null.After
{
    public class SoldArticle
    {
        private IWarranty _warranty;

        public SoldArticle(IWarranty warranty)
        {
            _warranty = warranty;
        }

        public void VisibleDamageDone()
        {
            _warranty = VoidWarranty.Instance;
        }

        public void Claim(DateTime claimDate)
        {
            _warranty.Claim(claimDate, OnSuccessfulClaim);
        }

        private void OnSuccessfulClaim()
        {
            //Do something
        }
    }
}