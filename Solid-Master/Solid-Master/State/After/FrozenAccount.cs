using System;

namespace Solid_Master.State.After
{
    internal class FrozenAccount : IAccountState
    {
        public FrozenAccount(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        private Action OnUnfreeze { get; }

        public IAccountState Deposit(Action addToBalance)
        {
            OnUnfreeze();
            addToBalance();
            return new ActiveAcount(OnUnfreeze);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            OnUnfreeze();
            subtractFromBalance();
            return new ActiveAcount(OnUnfreeze);
        }

        public IAccountState Freeze()
        {
            return this;
        }

        public IAccountState HolderVerified()
        {
            return this;
        }

        public IAccountState Close()
        {
            return new ClosedAccount();
        }
    }
}