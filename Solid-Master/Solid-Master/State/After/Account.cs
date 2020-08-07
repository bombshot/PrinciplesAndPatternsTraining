using System;

namespace Solid_Master.State.After
{
    internal class Account
    {
        public Account(Action onUnfreeze)
        {
            State = new NotVerifiedAccount(onUnfreeze);
        }

        public decimal Balance { get; private set; }

        private IAccountState State { get; set; }

        // #1 (Interaction): Deposit was invoked on the State
        // #2 (Behavior): Result of State.Deposit is new State
        // #5 (Behavior): Deposit 10, Deposit 1 - Balance == 11
        public void Deposit(decimal amount)
        {
            State = State.Deposit(() => { Balance += amount; });
        }

        // #3 (Interaction): Withdraw was invoked on the State
        // #4 (Behavior): Result of State.Withdraw is new State
        // #6 (Behavior): Deposit 1, Verify, Withdraw 1 - Balance == 9
        public void Withdraw(decimal amount)
        {
            State = State.Withdraw(() =>
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"Successfully withdrawn {amount}");
                }
                else
                {
                    Console.WriteLine("amount less than Balance - cannot withdraw");
                }
            });
        }

        public void HolderVerified()
        {
            State = State.HolderVerified();
        }

        public void Close()
        {
            State = State.Close();
        }

        public void Freeze()
        {
            State = State.Freeze();
        }
    }
}