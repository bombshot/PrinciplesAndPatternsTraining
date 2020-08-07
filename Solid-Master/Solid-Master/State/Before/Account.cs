using System;

namespace Solid_Master.State.Before
{
    class Account
    {
        private decimal _balance;
        private bool _isClosed;
        private bool _isFrozen;
        private bool _isVerified;
        
        private Action OnUnfreeze { get; }

        public decimal Balance => _balance;

        public bool IsFrozen => _isFrozen;

        public bool IsClosed => _isClosed;

        public bool IsVerified => _isVerified;

        public Account(Action onUnfreezeAction)
        {
            this.OnUnfreeze = onUnfreezeAction;
        }

        public void Deposit(decimal amount)
        {
            if (IsClosed)
                return;
            Unfreeze();
            _balance = Balance + amount;
        }

        public void VerifyHolder()
        {
            _isVerified = true;
        }

        public void Withdraw(decimal amount)
        {
            if (!IsVerified)
                return;
            if (IsClosed)
                return;
            Unfreeze();
            _balance = Balance - amount;
        }

        public void Unfreeze()
        {
            if (IsFrozen)
            {
                _isFrozen = false;
            }
            OnUnfreeze();
        }

        public void Freeze()
        {
            if (IsClosed)
                return;
            if (!IsVerified)
                return;
            _isFrozen = true;
        }

        public void Close()
        {
            _isClosed = true;
        }

    }
}
