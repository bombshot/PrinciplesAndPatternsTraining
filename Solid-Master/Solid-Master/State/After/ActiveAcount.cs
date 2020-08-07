using System;

namespace Solid_Master.State.After
{
    internal class ActiveAcount : IAccountState
    {
        public ActiveAcount(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        private Action OnUnfreeze { get; }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState Freeze()
        {
            return new FrozenAccount(OnUnfreeze);
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