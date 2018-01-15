using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplit
{
    /// <summary>
    /// <para>Splitter will parse the input file into separate trip expenses and calculate the outstanding amounts owed by each participant in each trip.</para>
    /// <para>The input follows the format as below:</para>
    /// <para>Standard input will contain the information for several camping trips. The information for each trip consists of a line </para>
    /// <para>containing a positive integer, n, the number of peopling participating in the camping trip, followed by n groups of inputs, one</para>
    /// <para>for each camping participant.  Each groups consists of a line containing a positive integer, p, the number of receipts/charges </para>
    /// <para>for that participant, followed by p lines of input, each containing the amount, in dollars and cents, for each charge by that camping </para>
    /// <para>participant.  A single line containing 0 follows the information for the last camping trip.</para>
    /// </summary>
    public class Splitter
    {
        /// <summary>
        /// This is bills ledger of all trip expenses.
        /// </summary>
        private ArrayList allTripBills = new ArrayList();

        private const String OPEN_BRACKET = "(";
        private const String CLOSE_BRACKET = ")";
        private const String EMPTY = "";
        private const String DOLLAR_SIGN = "$";
        public const String OUTPUT_EXTENSION = ".out";
        private String OuputFilePath = String.Empty;

        public Splitter(String inputPath)
        {
            ParseInputFile(inputPath);
        }

        public String GetOutputFileName(String inputPath)
        {
            return inputPath + OUTPUT_EXTENSION;
        }

        /// <summary>
        /// <para>This is to generate an output file at the same location with the input, whose name is inputFileName + ".out" </para>
        /// <para>This output file will contain all outstanding amounts of participants in each trips.</para>
        /// <para>In particular, for each camping trip, output one line per participant indicating how much he/she must pay or be paid rounded to the nearest cent.  If the participant owes money to the group, then the amount is positive.  If the participant should collect money from the group, then the amount is negative.  Negative amounts should be denoted by enclosing the amount in brackets.  Each trip should be separated by a blank line.</para>
        /// </summary>
        public void GenerateOutputFile()
        {
            System.IO.File.WriteAllText(OuputFilePath, GetSplittedAmounts());
        }

        /// <summary>
        /// Parse input file into separate trip expenses and generate filename of output
        /// </summary>
        /// <param name="inputPath"></param>
        private void ParseInputFile(String inputPath)
        {
            OuputFilePath = GetOutputFileName(inputPath);
            string[] lines = System.IO.File.ReadAllLines(inputPath);
            int cur = 0;
            int numberOfPurchasingRecordsInOneReceipt = 0;
            
            // headCount is the number of participants in each trip.
            int headCount = Int32.Parse(lines[cur++]);

            TripExpense tripExpense = new TripExpense();
            while(headCount>0)
            {
                numberOfPurchasingRecordsInOneReceipt = Int32.Parse(lines[cur++]);
                Receipt receipt = new Receipt();
                while (numberOfPurchasingRecordsInOneReceipt > 0)
                {
                    numberOfPurchasingRecordsInOneReceipt--;
                    receipt.AddNewExpense(double.Parse(lines[cur++], System.Globalization.CultureInfo.InvariantCulture));
                }
                // Add total amount paid by this participant into trip's ledger.
                // Then, move to the next participant's receipt.
                headCount--;
                tripExpense.AddNewExpense(receipt.GetSum());

                if (headCount == 0)
                {
                    // All receipts of a particular trip have been consolidated, so add this trip's expense into the main bill's ledger.
                    // Then, move to the next trip's expense.
                    headCount = Int32.Parse(lines[cur++]);
                    allTripBills.Add(tripExpense);
                    tripExpense = new TripExpense();
                }
            }
        }

        /// <summary>
        /// Add a new trip expense into bills ledger. A trip expense consists of amounts owed by each participant.
        /// </summary>
        /// <param name="tripExp"></param>
        private void AddNewTripExpense(TripExpense tripExp)
        {
            allTripBills.Add(tripExp);
        }

        /// <summary>
        /// <para>Return all outstanding amounts each participant need to pay in every trip.</para>
        /// <para>Different trip amounts are separted by an empty line.</para>
        /// </summary>
        /// <returns></returns>
        public String GetSplittedAmounts()
        {
            StringBuilder builder = new StringBuilder();
            int tripCount = 0, receiptCount=0;
            foreach(TripExpense trip in allTripBills) {

                tripCount++;
                receiptCount = trip.GetOwedAmounts().Count;
                foreach (double amount in trip.GetOwedAmounts())
                {
                    receiptCount--;
                    builder.Append(GetOpenBracket(amount < 0))
                       .Append(DOLLAR_SIGN)
                       .Append(Math.Abs(amount))
                       .Append(GetCloseBracket(amount < 0));

                    if (tripCount < allTripBills.Count || receiptCount>0) {
                        builder.Append(Environment.NewLine);
                    }
                }
                if (tripCount < allTripBills.Count)
                {
                    builder.Append(Environment.NewLine);
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// <para>return OPEN_BRACKET if isNegative is TRUE. </para>
        /// <para>Otherwise, return EMPTY.</para>
        /// </summary>
        /// <param name="isNegative"></param>
        /// <returns></returns>
        private String GetOpenBracket(bool isNegative)
        {
            return (isNegative) ? OPEN_BRACKET : EMPTY;
        }

        /// <summary>
        /// <para>return CLOSE_BRACKET if isNegative is TRUE.</para>
        /// <para>Otherwise, return EMPTY.</para>
        /// </summary>
        /// <param name="isNegative"></param>
        /// <returns>nam</returns>
        private String GetCloseBracket(bool isNegative)
        {
            return (isNegative) ? CLOSE_BRACKET : EMPTY;
        }
    }
}
