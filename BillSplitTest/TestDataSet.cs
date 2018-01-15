using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplitTest
{
    public class TestDataSet
    {
        public static String INPUT_1 = (new StringBuilder()).Append("3").Append(Environment.NewLine)
                                                            .Append("2").Append(Environment.NewLine)
                                                            .Append("10.00").Append(Environment.NewLine)
                                                            .Append("20.00").Append(Environment.NewLine)
                                                            .Append("4").Append(Environment.NewLine)
                                                            .Append("15.00").Append(Environment.NewLine)
                                                            .Append("15.01").Append(Environment.NewLine)
                                                            .Append("3.00").Append(Environment.NewLine)
                                                            .Append("3.01").Append(Environment.NewLine)
                                                            .Append("3").Append(Environment.NewLine)
                                                            .Append("5.00").Append(Environment.NewLine)
                                                            .Append("9.00").Append(Environment.NewLine)
                                                            .Append("4.00").Append(Environment.NewLine)
                                                            .Append("2").Append(Environment.NewLine)
                                                            .Append("2").Append(Environment.NewLine)
                                                            .Append("8.00").Append(Environment.NewLine)
                                                            .Append("6.00").Append(Environment.NewLine)
                                                            .Append("2").Append(Environment.NewLine)
                                                            .Append("9.20").Append(Environment.NewLine)
                                                            .Append("6.75").Append(Environment.NewLine)
                                                            .Append("0").ToString();

        public static String OUTPUT_1 = (new StringBuilder()).Append("($1.99)").Append(Environment.NewLine)
                                                             .Append("($8.01)").Append(Environment.NewLine)
                                                             .Append("$10.01").Append(Environment.NewLine)
                                                             .Append(Environment.NewLine)
                                                             .Append("$0.98").Append(Environment.NewLine)
                                                             .Append("($0.98)").ToString();

        public static String INPUT_2 = (new StringBuilder()).Append("5").Append(Environment.NewLine)
                                                            .Append("0").Append(Environment.NewLine)
                                                            .Append("0").Append(Environment.NewLine)
                                                            .Append("4").Append(Environment.NewLine)
                                                            .Append("1.20").Append(Environment.NewLine)
                                                            .Append("3.50").Append(Environment.NewLine)
                                                            .Append("8.60").Append(Environment.NewLine)
                                                            .Append("4.17").Append(Environment.NewLine)
                                                            .Append("3").Append(Environment.NewLine)
                                                            .Append("1.01").Append(Environment.NewLine)
                                                            .Append("3.20").Append(Environment.NewLine)
                                                            .Append("7.70").Append(Environment.NewLine)
                                                            .Append("0").Append(Environment.NewLine)
                                                            .Append("0").ToString();
        public static String OUTPUT_2 = (new StringBuilder()).Append("$5.88").Append(Environment.NewLine)
                                                            .Append("$5.88").Append(Environment.NewLine)
                                                            .Append("($11.59)").Append(Environment.NewLine)
                                                            .Append("($6.03)").Append(Environment.NewLine)
                                                            .Append("$5.88").ToString();
    }
}
