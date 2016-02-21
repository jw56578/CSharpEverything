using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CoreDomain
{
    /// <summary>
    /// this is an important abstraction to be aware of
    /// anytime there are properties that alway exist together anywhere they are used, you can abstract that into another type
    /// so you don't have to keep working with many seperate things
    /// 
    /// in this case there is a thing, Snack and you always want to know its price, but the snack itself cannot define its own price
    /// and in this case snacks are never different prices so there is no point to have multiple snack instances with the same price
    /// and the quantity is only known by the thing using a snack, not the snakc iteself
    /// </summary>
    public sealed class SnackPile : ValueObject<SnackPile>
    {
        //this is a technique for explicityt defining what the default of something is
        //giving a meaningful name and assigning the values that represent it
        //then it can be resused in many places
        public static readonly SnackPile Empty = new SnackPile(Snack.None, 0, 0m);

        public Snack Snack { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        private SnackPile()
        {
        }

        public SnackPile(Snack snack, int quantity, decimal price) : this()
        {
            if (quantity < 0)
                throw new InvalidOperationException();
            if (price < 0)
                throw new InvalidOperationException();
            if (price % 0.01m > 0)
                throw new InvalidOperationException();

            Snack = snack;
            Quantity = quantity;
            Price = price;
        }
        /// <summary>
        /// wherever possible don't allow mutability, if you need to change something, create a new object with that value
        /// </summary>
        /// <returns></returns>
        public SnackPile SubtractOne()
        {
            return new SnackPile(Snack, Quantity - 1, Price);
        }

        protected override bool EqualsCore(SnackPile other)
        {
            return Snack == other.Snack
                && Quantity == other.Quantity
                && Price == other.Price;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Snack.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity;
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                return hashCode;
            }
        }
    }
}
