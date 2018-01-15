using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplit
{
    /// <summary>
    /// A TripExpense consists of multiple receipts, each of which belongs to a participant of the trip.
    /// </summary>
    public class TripExpense : Receipt
    {
        public TripExpense()
        {
            // DO NOTHING
        }

        /// <summary>
        /// <para>Calculate outstanding amounts owed by each participant and return them in the form of an ArrayList.</para>
        /// <para>The amount will be rounded to the nearest cent. For example:</para>
        /// <para>$21.285 is rounded to 21.29</para>
        /// <para>$-1.175 is rounded to -1.18</para>
        /// <para>$1.174 is rounded to 1.17</para>
        /// </summary>
        /// <returns>An Arraylist containing all outstanding amounts of each participant in the trip</returns>
        public ArrayList GetOwedAmounts()
        {
            ArrayList owedAmounts = new ArrayList();

            foreach (double exp in allExpenses)
            {
                if(GetSum() >= (exp * allExpenses.Count))
                {
                    owedAmounts.Add(RoundAmountToNearestCent(GetSum() / allExpenses.Count - exp));
                }else
                {
                    owedAmounts.Add(-1 * RoundAmountToNearestCent(exp - GetSum() / allExpenses.Count));
                }
                
            }
            return owedAmounts;
        }

        /// <summary>
        /// <para>Round an amount to the nearest cent. For example:</para>
        /// <para>$1.175 is rounded to $1.18</para>
        /// <para>$1.174 is rounded to $1.17</para>
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public double RoundAmountToNearestCent(double amount)
        {
            double amt = Math.Truncate(amount * 100000) / 100000;
            amt = Math.Round(amt, 4, MidpointRounding.AwayFromZero);
            return Math.Round(amt, 2, MidpointRounding.AwayFromZero);
        }
    }
}
