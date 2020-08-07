using FluentAssertions;
using NUnit.Framework;

namespace Solid_Master.State.Before
{
    [TestFixture]
    class AccountTests
    {
        private Account _account;

        [SetUp]
        public void Init()
        {
            _account = new Account(() =>
            {
                //Do nothing on unfreeze
            });
        }

        [Test]
        public void WhenClosed_Deposit_ShouldNotChangeBalance()
        {
            _account.Close();
            _account.Deposit(1);
            _account.Balance.Should().Be(0);
        }

        [Test]
        public void WhenClosed_Withdraw_ShouldNotChangeBalance()
        {
            _account.VerifyHolder();
            _account.Close();
            _account.Withdraw(1);
            _account.Balance.Should().Be(0);
        }

        [Test]
        public void WhenActive_Deposit_ShouldIncreaseBalance()
        {
            _account.Deposit(1);
            _account.Balance.Should().Be(1);
        }

        [Test]
        public void WhenFrozen_Deposit_ShouldUnfreezeAccount()
        {
            _account.Freeze();
            _account.Deposit(1);
            _account.IsFrozen.Should().BeFalse();

        }

        [Test]
        public void WhenFrozen_Deposit_ShouldUnfreezeAccountAndCallback()
        {
            bool calledBack = false;
            _account = new Account(() =>
            {
                calledBack = true;
            });
            _account.Freeze();
            _account.Deposit(1);
            calledBack.Should().BeTrue();

        }

        [Test]
        public void WhenFrozen_Withdraw_ShouldUnfreezeAccountAndCallback()
        {
            _account.VerifyHolder();
            _account.Freeze();
            _account.Withdraw(1);
            _account.IsFrozen.Should().BeFalse();

        }

        [Test]
        public void WhenFrozenButNotVerified_Freeze_ShouldNotUnfreezeAccount()
        {
            _account.Freeze();
            _account.IsFrozen.Should().BeFalse();
        }

        [Test]
        public void WhenClosed_Freeze_ShouldNotUnfreezeAccount()
        {
            _account.Close();
            _account.Freeze();
            _account.IsFrozen.Should().BeFalse();

        }

        [Test]
        public void WhenFrozen_Unfree_ShouldMakeIsFrozenFalse()
        {
            _account.Freeze();
            _account.Unfreeze();
            _account.IsFrozen.Should().BeFalse();

        }


        [Test]
        public void WhenFrozen_Withdraw_ShouldReduceBalance()
        {
            _account.VerifyHolder();
            _account.Freeze();
            _account.Withdraw(1);
            _account.IsFrozen.Should().BeFalse();
            }

        [Test]
        public void WhenActiveButNotVerified_Withdraw_ShouldNotReduceBalance()
        {
            _account.Withdraw(1);
            _account.Balance.Should().Be(0);
        }

        [Test]
        public void WhenFrozen_Unfreeze_ShouldMakeAccountActive()
        {
            _account.Freeze();
            _account.Unfreeze();
            _account.IsFrozen.Should().BeFalse();

        }

        [Test]
        public void WhenUnFrozen_Freeze_ShouldMakeIsFrozenTrue()
        {
            _account.VerifyHolder();
            _account.Freeze();
            _account.IsFrozen.Should().BeTrue();
        }


        [Test]
        public void WhenNotVerified_Withdraw_ShouldNotReduceBalance()
        {
            _account.Withdraw(1);
            _account.Balance.Should().Be(0);
        }

        [Test]
        public void WhenVerified_Withdraw_ShouldReduceBalance()
        {
            _account.VerifyHolder();
            _account.Withdraw(1);
            _account.Balance.Should().Be(-1);
        }

        [Test]
        public void WhenNotVerified_Verify_ShouldMakeIsVerifiedTrue()
        {
            _account.VerifyHolder();
            _account.IsVerified.Should().BeTrue();
        }

        [Test]
        public void WhenActive_Close_ShouldMakeIsClosedTrue()
        {
            _account.Close();
            _account.IsClosed.Should().BeTrue();
        }



    }
}
