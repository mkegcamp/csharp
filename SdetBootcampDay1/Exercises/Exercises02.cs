using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Exercises
{
    [TestFixture]
    public class Exercises02
    {
        [Test]
        public void FakeTest_DoesNothing()
        {
            //do nothing
        }

        /**
         * TODO: rewrite these three tests into a single, parameterized test.
         * You decide if you want to use [TestCase] or [TestCaseSource], but
         * I would like to know why you chose the option you chose afterwards.
         */
        [Test]
        public void CreateNewSavingsAccount_Deposit100Withdraw50_BalanceShouldBe50()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(100);
            account.Withdraw(50);

            Assert.That(account.Balance, Is.EqualTo(50));
        }

        [Test]
        public void CreateNewSavingsAccount_Deposit1000Withdraw1000_BalanceShouldBe0()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(1000);
            account.Withdraw(1000);

            Assert.That(account.Balance, Is.EqualTo(0));
        }

        [Test]
        public void CreateNewSavingsAccount_Deposit250Withdraw1_BalanceShouldBe249()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(250);
            account.Withdraw(1);

            Assert.That(account.Balance, Is.EqualTo(249));
        }

        [TestCase(100,50,50, TestName="Deposit 100, Withdraw 50, Balance 50")]
        [TestCase(1000,1000,0, TestName="Deposit 1000, Withdraw 1000, Balance 0")]
        [TestCase(250,1,249, TestName="Deposit 200, Withdraw 1, Balance 249")]
        public void GivenANewAccount_WhenIDepositAndWithdraw_BalanceShouldBe
            (int deposit, int withdraw, int equals)
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(deposit);
            account.Withdraw(withdraw);

            Assert.That(account.Balance, Is.EqualTo(equals));
        }

        [Test,TestCaseSource("DepositWithdrawBalance")]
        public void GivenANewAccount_WenIDepositAndWithdraw_BalanceShouldBe_UsingTestCaseSource
            (int deposit, int withdraw, int equals)
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(deposit);
            account.Withdraw(withdraw);

            Assert.That(account.Balance, Is.EqualTo(equals));
        }

        private static IEnumerable<TestCaseData> DepositWithdrawBalance()
        {
            yield return new TestCaseData(100,50,50).
                SetName("100 - 50 = 50");
            yield return new TestCaseData(1000,1000,0).
                SetName("1000 - 1000 = 0");
            yield return new TestCaseData(250, 1,249).
                SetName("250 - 1 = 249");
        }
    }
}
