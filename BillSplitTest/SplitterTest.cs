using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using BillSplit;

namespace BillSplitTest
{
    /// <summary>
    /// Summary description for SplitterTest
    /// </summary>
    [TestClass]
    public class SplitterTest
    {
        private String inputFileName = "";
        private String inputContent = "";
        private String outputContent = "";
        private String expectedOutputFilename = "";

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            inputFileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), milliseconds + ".txt");
            expectedOutputFilename = inputFileName + Splitter.OUTPUT_EXTENSION;
        }

        // Use TestCleanup to run code after each test has run.
        // Uncomment the below line if you don't want to have output files created.
        //[TestCleanup()]
        public void MyTestCleanup()
        {
            if(File.Exists(expectedOutputFilename))
            {
                File.Delete(expectedOutputFilename);
            }

            if (File.Exists(inputFileName))
            {
                File.Delete(inputFileName);
            }
        }

        private void CreateInputFile(String content)
        {
            System.IO.File.WriteAllText(inputFileName, content);
        }

        private void VerifyOutputFile()
        {
            CreateInputFile(inputContent);
            Splitter splitter = new Splitter(inputFileName);
            splitter.GenerateOutputFile();
            Assert.AreEqual(expectedOutputFilename, splitter.GetOutputFileName(inputFileName));
            Assert.IsTrue(File.Exists(expectedOutputFilename), "expected output file <" + expectedOutputFilename + "> does exist");
            Assert.AreEqual(outputContent, File.ReadAllText(expectedOutputFilename));
        }


        [TestMethod]
        public void TestGenerateOutputFile()
        {
            inputContent = TestDataSet.INPUT_1;
            outputContent = TestDataSet.OUTPUT_1;
            VerifyOutputFile();
        }

        [TestMethod]
        public void TestGenerateOutputFileWithSomeCampersHavingNoReceipts()
        {
            inputContent = TestDataSet.INPUT_2;
            outputContent = TestDataSet.OUTPUT_2;
            VerifyOutputFile();
        }
    }
}
