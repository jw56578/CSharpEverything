using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CoreDomain
{

    /// <summary>
    /// These are examples of Entities
    /// They could have a unique id
    /// they could be stored in a database
    /// you can compare one to another by way of some unique identifier field
    /// these objects are mutable, you can directly change its properties, is this good?
    /// Entities exist to be used by other parts of the system so can exists on their own
    /// you would want to use a SnackMachine object to send to the UI to display things about it to the User
    /// </summary>
    public class DumbSnackMachine
    {
        //define properties to hold the amount of money that is currently in the machine

        public int OneCentCount { get; set; }
        public int DollarCount { get; set; }
        public int TwentyFiveCentCount { get; set; }


        //define properties to hold the amount of money that the user has put into the machine

        public int TransactionOneCentCount { get; set; }
        public int TransactionDollarCount { get; set; }
        public int TransactionTwentyFiveCentCount { get; set; }

        //you can see a pattern here that can be modeled in another way
        //this could get ridiculous with how many different types of money there could be
        //put all these things into another class called money 

        
        /// <summary>
        /// you can see how ridiculous the signature of this method could get if there were more money types
        /// </summary>
  
        public void InsertMoney(int oneCent, int twentyFiveCent, int dollar)
        {
            OneCentCount = oneCent;
            DollarCount = dollar;
            TwentyFiveCentCount = twentyFiveCent;
        }
    }
    public partial class BetterSnackMachine
    {
        Money existingMoney = null;
        Money transMoney = null;

        public BetterSnackMachine()
        {
            existingMoney = new Money(10, 10, 10,1,1,1);
            transMoney = new Money(10, 10, 10, 1, 1, 1);

        }
        public void InsertMoney(Money m)
        {
            transMoney = transMoney + m;
        }

    }
    /// <summary>
    /// whatever is an aggregate class should inherit from aggregate
    /// </summary>
    public class SnackMachine : Aggregate
    {
        public virtual Money MoneyInside { get; protected set; }
        //having this property as decimal is a business decision
        //there is no reason to track what denomination was put into the machine
        //it doesn' matter what denominations they put in, if you return money, return the highest denomination possible
        //if they insert 4 quarters then return 1 dollar
        public virtual decimal MoneyInTransaction { get; protected set; }
        protected virtual IList<Slot> Slots { get; }

        public SnackMachine()
        {
            MoneyInside = Money.None;
            MoneyInTransaction = 0;
            Slots = new List<Slot>
            {
                new Slot(this, 1),
                new Slot(this, 2),
                new Slot(this, 3)
            };
        }

        public virtual SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }

        public virtual IReadOnlyList<SnackPile> GetAllSnackPiles()
        {
            return Slots
                .OrderBy(x => x.Position)
                .Select(x => x.SnackPile)
                .ToList();
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(x => x.Position == position);
        }

        public virtual void InsertMoney(Money money)
        {
            Money[] coinsAndNotes =
            {
                Money.Cent, Money.TenCent, Money.Quarter, Money.Dollar, Money.FiveDollar, Money.TwentyDollar
            };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money.Amount;
            MoneyInside += money;
        }

        public virtual void ReturnMoney()
        {
            Money moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
            MoneyInside -= moneyToReturn;
            MoneyInTransaction = 0;
        }

        public virtual string CanBuySnack(int position)
        {
            SnackPile snackPile = GetSnackPile(position);

            if (snackPile.Quantity == 0)
                return "The snack pile is empty";

            if (MoneyInTransaction < snackPile.Price)
                return "Not enough money";

            if (!MoneyInside.CanAllocate(MoneyInTransaction - snackPile.Price))
                return "Not enough change";

            return string.Empty;
        }
        /// <summary>
        /// this is exactly how end user would use a snack machine
        /// they would choose whatever slot they wanted, not specify that name of a snack or something like that
        /// </summary>
        /// <param name="position"></param>
        public virtual void BuySnack(int position)
        {
            if (CanBuySnack(position) != string.Empty)
                throw new InvalidOperationException();

            Slot slot = GetSlot(position);
            slot.SnackPile = slot.SnackPile.SubtractOne();

            Money change = MoneyInside.Allocate(MoneyInTransaction - slot.SnackPile.Price);
            MoneyInside -= change;
            MoneyInTransaction = 0;
        }

        public virtual void LoadSnacks(int position, SnackPile snackPile)
        {
            Slot slot = GetSlot(position);
            slot.SnackPile = snackPile;
        }

        public virtual void LoadMoney(Money money)
        {
            MoneyInside += money;
        }

        public virtual Money UnloadMoney()
        {
            if (MoneyInTransaction > 0)
                throw new InvalidOperationException();

            Money money = MoneyInside;
            MoneyInside = Money.None;
            return money;
        }
    }
}
