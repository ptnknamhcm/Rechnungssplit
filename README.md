# Rechnungssplit
Calculate outstanding amounts payable by every person in a trip, given that some of them have had stuffs, e.g. beverage or food, prepaid with receipts retained.

I. OVERVIEW

The solution is implemented using C# Windows Console Application on .NET Framework 4.6.1 / Visual Studio 2017 Express.
There are two source code packages:
1. BillSplit: main core of the application
2. BillSplitTest: test project


II. SETUP AND BUILD PROJECT

1. Open Git Bash (please download and install it if needed)
2. Change the current working directory to your local project folder.
3. Initialize the local directory as a Git repository:
   + $ git init
4. Add the URL for the remote repository where your local repository will be pushed.
   + $ git remote add origin https://github.com/ptnknamhcm/Rechnungssplit.git
5. Pull the whole remote source code repository into your local folder
   + $ git pull origin master
6. Start up Microsoft Visual Studio 2017
   + Click on File > Open > Projects/Solution 
   + Navigate to your local project folder > Choose BillSplit.sln
7. Right-click on project BillSplit > Rebuild
8. Open Command Window 
   + Navigate to [your local folder]/BillSplit/bin/Debug/ 
   + Run the following command:
   + $ BillSplit expense.txt
   + There should be an output file named expense.txt.out created in the same directory.
   
   
III. RUN TESTS

1. In menu bar of Visual Studio 2017, click on Test > Windows > Test Explorer
2. Click on Run All
  + All seven test scenarios should be run successfully.
