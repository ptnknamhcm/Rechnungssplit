using System;
using BillSplit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BillSplitTest
{
    [TestClass]
    public class ReceiptTest
    {
        [TestMethod]
        public void TestAddNewExpenseAndGetSum()
        {
            Receipt receipt = new Receipt();
            receipt.AddNewExpense(1.32);
            receipt.AddNewExpense(212.27);
            receipt.AddNewExpense(1.02);
            receipt.AddNewExpense(10.72);
            Assert.AreEqual(225.33, receipt.GetSum());
        }
    }
}
