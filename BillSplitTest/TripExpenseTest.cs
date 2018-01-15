using System;
using BillSplit;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace BillSplitTest
{
   [TestClass]
    public class TripExpenseTest
    {
        
        [TestMethod]
        public void TestRoundAmountToNearestCent()
        {
            TripExpense tripExp = new TripExpense();
            Assert.AreEqual(1.18, tripExp.RoundAmountToNearestCent(1.175));
            Assert.AreEqual(0.98, tripExp.RoundAmountToNearestCent(29.95 / 2 - 14));
        }

        [TestMethod]
        public void TestGetOwedAmountsWithEveryonePaying()
        {
            TripExpense tripExp = new TripExpense();
            tripExp.AddNewExpense(51.27);
            tripExp.AddNewExpense(101.35);
            tripExp.AddNewExpense(16.01);
            // total expense is $168.63 and everyone has to pay $56.21
            ArrayList owedAmounts = tripExp.GetOwedAmounts();
            Assert.AreEqual(4.94, owedAmounts[0]);
            Assert.AreEqual(-45.14, owedAmounts[1]);
            Assert.AreEqual(40.2, owedAmounts[2]);
        }

        [TestMethod]
        public void TestGetOwedAmountsWithOnlyOnePaying()
        {
            TripExpense tripExp = new TripExpense();
            tripExp.AddNewExpense(0);
            tripExp.AddNewExpense(113);
            tripExp.AddNewExpense(0);
            // total expense is $113 and everyone has to pay $37.67
            ArrayList owedAmounts = tripExp.GetOwedAmounts();
            Assert.AreEqual(37.67, owedAmounts[0]);
            Assert.AreEqual(-75.33, owedAmounts[1]);
            Assert.AreEqual(37.67, owedAmounts[2]);
        }

        [TestMethod]
        public void TestGetOwedAmountsWithTwoPaying()
        {
            TripExpense tripExp = new TripExpense();
            tripExp.AddNewExpense(14);
            tripExp.AddNewExpense(15.95);
            // total expense is $29.95 and everyone has to pay $14.98
            ArrayList owedAmounts = tripExp.GetOwedAmounts();
            Assert.AreEqual(0.98, owedAmounts[0]);
            Assert.AreEqual(-0.98, owedAmounts[1]);
        }
    }
}
