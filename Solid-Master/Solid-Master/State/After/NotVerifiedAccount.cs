using System;

namespace Solid_Master.State.After
{
    internal class NotVerifiedAccount : IAccountState
    {
        public NotVerifiedAccount(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        private Action OnUnfreeze { get; }

        public IAccountState Close()
        {
            return new ClosedAccount();
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Freeze()
        {
            return this;
        }

        public IAccountState HolderVerified()
        {
            return new ActiveAcount(OnUnfreeze);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            return this;
        }
    }
}