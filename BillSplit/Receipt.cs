using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplit
{
    /// <summary>
    /// A receipt consists of multiple records of purchasing expenses. Presumably, each receipt belongs to only one person.
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// This is expense ledger, containing all expense amounts.
        /// </summary>
        protected ArrayList allExpenses = new ArrayList();
        public Receipt()
        {
            // DO NOTHING
        }

        /// <summary>
        /// Add an expense amount into the expense ledger.
        /// </summary>
        /// <param name="amount"></param>
        public void AddNewExpense(double amount)
        {
            allExpenses.Add(amount);
        }

        /// <summary>
        /// Return total sum of all expense amounts stored in the ledger.
        /// </summary>
        /// <returns></returns>
        public double GetSum()
        {
            double sum = 0;
            foreach(double exp in allExpenses)
            {
                sum += exp;
            }
            return sum;
        }
    }
}
