using System;

namespace Solid_Master.Null.After
{
    public interface IWarranty
    {
        void Claim(DateTime claimDate, Action callback);
    }
}