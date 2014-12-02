﻿#region These are the using statements, which function like the import statements for the Java programming language
using System;
using System.IO; // This is required for File I/O
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace ProgrammingAssignment1_SpecialTopics
{
    /// <summary>
    /// Pranav Krishnamurthy
    /// Programming Assignment 1
    /// CSCI-860-W01: Biometrics and its Applications in a Networked Society
    /// Instructor: Dr. Kiran Balagani
    ///  
    /// 1st December 2014
    /// * Got the method of extracting test samples working
    /// * Have to finish off this project and code the genuine score and impostor score methods
    /// * Finally have to code the method to calculate the Impostor Pass Rate and False Reject Rates 
    /// given a Threshold T. 
    /// </summary>
    class Program
    {
        #region Static 2D double arrays which correspond to their respective data files and these are used for training
        static double[,] s002; // User 1 - s002.csv
        static double[,] s003; // User 2 - s003.csv
        static double[,] s004; // User 3 - s004.csv
        static double[,] s005; // User 4 - s005.csv
        static double[,] s007; // User 5 - s007.csv
        static double[,] s008; // User 6 - s008.csv
        static double[,] s010; // User 7 - s010.csv
        static double[,] s011; // User 8 - s011.csv
        static double[,] s012; // User 9 - s012.csv
        static double[,] s013; // User 10 - s013.csv
        static double[,] s015; // User 11 - s015.csv
        static double[,] s016; // User 12 - s016.csv
        static double[,] s017; // User 13 - s017.csv
        static double[,] s018; // User 14 - s018.csv
        static double[,] s019; // User 15 - s019.csv
        static double[,] s020; // User 16 - s020.csv
        static double[,] s021; // User 17 - s021.csv
        static double[,] s022; // User 18 - s022.csv
        static double[,] s024; // User 19 - s024.csv
        static double[,] s025; // User 20 - s025.csv
        static double[,] s026; // User 21 - s026.csv
        static double[,] s027; // User 22 - s027.csv
        static double[,] s028; // User 23 - s028.csv
        static double[,] s029; // User 24 - s029.csv
        static double[,] s030; // User 25 - s030.csv
        static double[,] s031; // User 26 - s031.csv
        static double[,] s032; // User 27 - s032.csv
        static double[,] s033; // User 28 - s033.csv
        static double[,] s034; // User 29 - s034.csv
        static double[,] s035; // User 30 - s035.csv
        static double[,] s036; // User 31 - s036.csv
        static double[,] s037; // User 32 - s037.csv
        static double[,] s038; // User 33 - s038.csv
        static double[,] s039; // User 34 - s039.csv
        static double[,] s040; // User 35 - s040.csv
        static double[,] s041; // User 36 - s041.csv
        static double[,] s042; // User 37 - s042.csv
        static double[,] s043; // User 38 - s043.csv
        static double[,] s044; // User 39 - s044.csv
        static double[,] s046; // User 40 - s046.csv
        static double[,] s047; // User 41 - s047.csv
        static double[,] s048; // User 42 - s048.csv
        static double[,] s049; // User 43 - s049.csv
        static double[,] s050; // User 44 - s050.csv
        static double[,] s051; // User 45 - s051.csv
        static double[,] s052; // User 46 - s052.csv
        static double[,] s053; // User 47 - s053.csv
        static double[,] s054; // User 48 - s054.csv
        static double[,] s055; // User 49 - s055.csv
        static double[,] s056; // User 50 - s056.csv
        static double[,] s057; // User 51 - s057.csv
        #endregion

        #region Static double arrays that represent the mean vectors of each user which will be used for genuine and impostor calculations
        static double[] mu_s002; // User 1
        static double[] mu_s003; // User 2
        static double[] mu_s004; // User 3
        static double[] mu_s005; // User 4
        static double[] mu_s007; // User 5
        static double[] mu_s008; // User 6
        static double[] mu_s010; // User 7
        static double[] mu_s011; // User 8
        static double[] mu_s012; // User 9
        static double[] mu_s013; // User 10
        static double[] mu_s015; // User 11
        static double[] mu_s016; // User 12
        static double[] mu_s017; // User 13
        static double[] mu_s018; // User 14
        static double[] mu_s019; // User 15
        static double[] mu_s020; // User 16
        static double[] mu_s021; // User 17
        static double[] mu_s022; // User 18
        static double[] mu_s024; // User 19
        static double[] mu_s025; // User 20
        static double[] mu_s026; // User 21
        static double[] mu_s027; // User 22
        static double[] mu_s028; // User 23
        static double[] mu_s029; // User 24
        static double[] mu_s030; // User 25
        static double[] mu_s031; // User 26
        static double[] mu_s032; // User 27
        static double[] mu_s033; // User 28
        static double[] mu_s034; // User 29
        static double[] mu_s035; // User 30
        static double[] mu_s036; // User 31
        static double[] mu_s037; // User 32
        static double[] mu_s038; // User 33
        static double[] mu_s039; // User 34
        static double[] mu_s040; // User 35
        static double[] mu_s041; // User 36
        static double[] mu_s042; // User 37
        static double[] mu_s043; // User 38
        static double[] mu_s044; // User 39
        static double[] mu_s046; // User 40
        static double[] mu_s047; // User 41
        static double[] mu_s048; // User 42
        static double[] mu_s049; // User 43
        static double[] mu_s050; // User 44
        static double[] mu_s051; // User 45
        static double[] mu_s052; // User 46
        static double[] mu_s053; // User 47
        static double[] mu_s054; // User 48
        static double[] mu_s055; // User 49
        static double[] mu_s056; // User 50
        static double[] mu_s057; // User 51
        #endregion

        #region Static 2D double arrays that will be used for genuine and impostor score calculations
        static double[,] s002_Test; // User 1
        static double[,] s003_Test; // User 2
        static double[,] s004_Test; // User 3
        static double[,] s005_Test; // User 4
        static double[,] s007_Test; // User 5
        static double[,] s008_Test; // User 6
        static double[,] s010_Test; // User 7
        static double[,] s011_Test; // User 8
        static double[,] s012_Test; // User 9
        static double[,] s013_Test; // User 10
        static double[,] s015_Test; // User 11
        static double[,] s016_Test; // User 12
        static double[,] s017_Test; // User 13
        static double[,] s018_Test; // User 14
        static double[,] s019_Test; // User 15
        static double[,] s020_Test; // User 16
        static double[,] s021_Test; // User 17
        static double[,] s022_Test; // User 18
        static double[,] s024_Test; // User 19
        static double[,] s025_Test; // User 20
        static double[,] s026_Test; // User 21
        #endregion

        static void Main()
        {
            #region Header
            // Overall header for the Console
            Console.Write("===Programming Assignment 1===" + Environment.NewLine);

            // Adding a separation at the end of the header. 
            Console.Write("Pranav S. Krishnamurthy" + Environment.NewLine + "CSCI-860-W01: Biometrics and its Applications in a Networked Society" + Environment.NewLine);

            // Providing the instructions in the program when executing it. 
            Console.WriteLine("We will now be starting to take data from various users and begin to calculate various rates. Now, begin by selecting the user to analyze.  Keep in mind that the subject ID's will not be entered in.  Every user number that is between 1 and 51 and that the user number will be tied to the appropriate subject ID.");
            #endregion

            // This is the string for which the end user will determine which user will have the samples retrieved.
            string userNumber = Console.ReadLine();

            #region For user 1
            if (userNumber == "1")
            {
                // Initialization of the 2D array called s002.  
                s002 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s002.csv");

                // Prompting the user to now enter in the number of samples to be analyzed
                Console.Write("Enter N:  The number of samples. The value of N can be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine(); 
                
                // Extracting either 100, 200, or 300 samples from the specified user
                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    // N represents the number of training samples
                    int N = int.Parse(inputN);
                    int M = 400 - N; 

                    // Creating a new array called s002_Samples which denotes the double 2D array that will be used for the calculations of genuine and impostor scores
                    // which becomes populated with a method call as well. 
                    double[,] s002_Samples = ExtractTrainingSamples(s002, N);

                    Console.WriteLine("==================================Training Vector========================================"); 

                    // Printing out the first N samples which will be used for the template vectors
                    for (int m = 0; m < s002_Samples.GetLength(0); m++)
                    {
                        for  (int n = 0; n < s002_Samples.GetLength(1); n++)
                        {
                            Console.Write(string.Format("{0} ", s002_Samples[m, n]));
                        }
                        Console.Write(Environment.NewLine); 
                    }

                    // Useing the following line of code to be able to pause the output in order to verify all the steps that are going on. 
                    Console.ReadLine(); 

                    // Calculates the templates now and stores it in an array which can be used later on. 
                    mu_s002 = CalculateTemplateVectors(s002_Samples, N); 

                    // Printing out the template calculations
                    for (int i = 0; i < mu_s002.Length; i++)
                    {
                        Console.WriteLine(mu_s002[i]); 
                    }

                    Console.ReadLine(); 

                    // This is the trouble spot for me - but now done!
                    s002_Test = ExtractTestingSamples(s002, N);

                    // Printing out the test vectors
                    for (int i = 0; i < s002_Test.GetLength(0); i++)
                    {
                        for (int j = 0; j < s002_Test.GetLength(1); j++)
                        {
                            Console.Write(string.Format("{0} ", s002_Test[i, j]));
                        }
                        Console.Write(Environment.NewLine);
                    }

                    Console.ReadLine(); 
                }

                // If the user enters in a number that is not equal to either the three options listed
                else if (inputN != "100" || inputN != "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will quit");
                    Console.ReadKey(); 
                }
            }
            #endregion

            #region For user 2
            if (userNumber == "2")
            {
                // Referring to the second user
                s003 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s003.csv");

                // Prompting the user to enter in the number of samples to be analyzed. 
                Console.Write("Enter N: The number of samples. The value of N can be either 100, 200, or 300." + Environment.NewLine+ "N = ");
                string inputN = Console.ReadLine(); 

                if (inputN == "100"|| inputN == "200" || inputN == "300")
                {
                    // Creating the integer N, which is the sample size variable
                    int N = int.Parse(inputN);

                    // Again initializing an array of samples, again used through a method call. 
                    double[,] s003_Samples = ExtractTrainingSamples(s003, N); 

                    // Calling to the method which will calculate the Template Vectors. 
                    mu_s003 = CalculateTemplateVectors(s003_Samples, N); 

                    Console.ReadLine(); // Pausing the output here

                    s003_Test = ExtractTestingSamples(s003, N);
                }

                else if (inputN != "100" || inputN != "200" || inputN !="300")
                {
                    Console.Write("The sample size that you requested is too large, the program will now quit");
                    Console.ReadKey(); 
                }
            }
            #endregion

            #region For user 3
            if (userNumber == "3")
            {
                // Creating the 2D Double array3
                s004 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s004.csv");

                // Prompting the user       
                Console.Write("Enter N: The number of samples.  Value of N can be 100, 200 or 300." + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine(); 

                // Switching up the input in the if statement
                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    // The integer will be parsed from the string
                    int N = int.Parse(inputN);

                    // Populating the 2D double array via method call. 
                    double[,] s004_Samples = ExtractTrainingSamples(s004, N); 

                    // Method call to calculate the template vectors
                    mu_s004 = CalculateTemplateVectors(s004_Samples, N); 

                    Console.ReadLine(); // Serving as a pausing mechanism

                    double[,] s004_Test = ExtractTestingSamples(s004, N); 
                }

                else if (inputN != "100" || inputN != "200" || inputN != "300")
                {
                    Console.Write("Your input sampling is too large, and the program will now quit");
                    Console.ReadKey();  
                }
            }
            #endregion

            #region For user 4
            if(userNumber == "4")
            {
                s005 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s005.csv");

                // Prompting the user to enter in the sample size
                Console.Write("Enter N: The number of samples.  Value of N can be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine(); 

                // If the inputN string which is the number of samples (initially parsed as a string) is either the values mentioned in the conditional
                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    // The local variable will have the extracted data
                    double[,] s005_Samples = ExtractTrainingSamples(s005, N); 

                    // Making the call to calculate the template vectors
                    mu_s005 = CalculateTemplateVectors(s005_Samples, N);
 
                    for(int i = 0; i < mu_s005.Length; i++)
                    {
                        Console.WriteLine(mu_s005[i]); 
                    }

                    double[,] s005_Test = ExtractTestingSamples(s005, N); 
                }

                else if (inputN != "100" || inputN != "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey(); 
                }
            }
            #endregion

            #region For user 5
            if (userNumber == "5")
            {
                s007 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s007.csv");

                // Prompting the user to enter in the number of samples
                Console.Write("Enter N: The number of samples.  Value of N can either be 100, 200, or 300." + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine(); 

                // The code to execute when the number of samples equals one of the three options
                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s007_Samples = ExtractTrainingSamples(s007, N);  

                    mu_s007 = CalculateTemplateVectors(s007_Samples, N); 

                    for (int i = 0; i < mu_s007.Length; i++)
                    {
                        Console.WriteLine(mu_s007[i]); 
                    }

                    Console.ReadLine(); 


                }

                else if (inputN != "100" || inputN != "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey(); 
                }
            }
            #endregion

            #region For user 6
            if (userNumber == "6")
            {
                s008 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s008.csv");

                // Prompting the user to enter the number of samples
                Console.Write("Enter N:  The number of samples. Value of N can be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine(); 

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s008_Samples = ExtractTrainingSamples(s008, N);

                    mu_s008 = CalculateTemplateVectors(s008_Samples, N); 

                    for (int i = 0; i < mu_s008.Length; i++)
                    {
                        Console.WriteLine(mu_s008[i]); 
                    }
                }

                else if (inputN != "100" || inputN != "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey(); 
                }
            }
            #endregion

            #region For user 7
            if (userNumber == "7")
            {
                s010 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s010.csv");

                Console.Write("Enter N: The number of samples.  Value of N can be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine(); 

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s010_Samples = ExtractTrainingSamples(s010, N);

                    mu_s010 = CalculateTemplateVectors(s010_Samples, N); 

                    for (int i = 0; i < mu_s010.Length; i++)
                    {
                        Console.WriteLine(mu_s010[i]); 
                    }
                }

                else if (inputN != "100" || inputN != "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey(); 
                }
            }
            #endregion

            #region For user 8
            if (userNumber == "8")
            {
                s011 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s011.csv");

                Console.Write("Enter N: The number of samples.  Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine(); 

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s011_Samples = ExtractTrainingSamples(s011, N);

                    mu_s011 = CalculateTemplateVectors(s011_Samples, N); 

                    for (int i = 0; i < mu_s011.Length; i++)
                    {
                        Console.WriteLine(mu_s011[i]); 
                    }
                }

                else if (inputN != "100" || inputN != "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey(); 
                }
            }
            #endregion

            #region For user 9
            if (userNumber == "9")
            {
                s012 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s012.csv");

                Console.Write("Enter N: The number of samples.  Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine(); 

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s012_Samples = ExtractTrainingSamples(s012, N);

                    mu_s012 = CalculateTemplateVectors(s012_Samples, N); 

                    for (int i = 0; i < mu_s012.Length; i++)
                    {
                        Console.WriteLine(mu_s012[i]); 
                    }
                }

                else if (inputN != "100" || inputN != "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey(); 
                }
            }
            #endregion

            #region For user 10
            if (userNumber == "10")
            {
                s013 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s013.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine(); 

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s013_Samples = ExtractTrainingSamples(s013, N);

                    mu_s013 = CalculateTemplateVectors(s013_Samples, N); 

                    for (int i = 0; i < mu_s013.Length; i++)
                    {
                        Console.WriteLine(mu_s013[i]); 
                    }
                }

                else if (inputN != "100" || inputN != "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey(); 
                }
            }
            #endregion

            #region For user 11
            if (userNumber == "11")
            {
                s015 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s015.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine(); 

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s015_Samples = ExtractTrainingSamples(s015, N);

                    mu_s015 = CalculateTemplateVectors(s015_Samples, N); 

                    for (int i = 0; i < mu_s015.Length; i++)
                    {
                        Console.WriteLine(mu_s015[i]); 
                    }
                }

                else if (inputN != "100" || inputN != "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey(); 
                }
            }
            #endregion

            #region For user 12
            if (userNumber == "12")
            {
                s016 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s016.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine(); 

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s016_Samples = ExtractTrainingSamples(s016, N);

                    mu_s016 = CalculateTemplateVectors(s016_Samples, N); 

                    for (int i = 0; i < mu_s016.Length; i++)
                    {
                        Console.WriteLine(mu_s016[i]); 
                    }
                }

                else if (inputN != "100" || inputN != "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 13
            if (userNumber == "13")
            {
                s017 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s017.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine(); 

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s017_Samples = ExtractTrainingSamples(s017, N);

                    mu_s017 = CalculateTemplateVectors(s017_Samples, N); 

                    for (int i = 0; i < mu_s017.Length; i++)
                    {
                        Console.WriteLine(mu_s017[i]); 
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey(); 
                }
            }
            #endregion

            #region For user 14
            if (userNumber == "14")
            {
                s018 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s018.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s018_Samples = ExtractTrainingSamples(s018, N);

                    mu_s018 = CalculateTemplateVectors(s018_Samples, N);

                    for (int i = 0; i < mu_s018.Length; i++)
                    {
                        Console.WriteLine(mu_s018[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 15
            if (userNumber == "15")
            {
                s019 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s019.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s019_Samples = ExtractTrainingSamples(s019, N);

                    mu_s019 = CalculateTemplateVectors(s019_Samples, N);

                    for (int i = 0; i < mu_s019.Length; i++)
                    {
                        Console.WriteLine(mu_s019[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 16
            if (userNumber == "16")
            {
                s020 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s020.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s020_Samples = ExtractTrainingSamples(s020, N);

                    mu_s020 = CalculateTemplateVectors(s020_Samples, N);

                    for (int i = 0; i < mu_s020.Length; i++)
                    {
                        Console.WriteLine(mu_s020[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 17
            if (userNumber == "17")
            {
                s021 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s021.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s021_Samples = ExtractTrainingSamples(s021, N);

                    mu_s021 = CalculateTemplateVectors(s021_Samples, N);

                    for (int i = 0; i < mu_s021.Length; i++)
                    {
                        Console.WriteLine(mu_s021[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 18
            if (userNumber == "18")
            {
                s022 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s022.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s022_Samples = ExtractTrainingSamples(s022, N);

                    mu_s022 = CalculateTemplateVectors(s022_Samples, N);

                    for (int i = 0; i < mu_s022.Length; i++)
                    {
                        Console.WriteLine(mu_s022[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 19
            if (userNumber == "19")
            {
                s024 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s024.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s024_Samples = ExtractTrainingSamples(s024, N);

                    mu_s024 = CalculateTemplateVectors(s024_Samples, N);

                    for (int i = 0; i < mu_s024.Length; i++)
                    {
                        Console.WriteLine(mu_s024[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 20
            if (userNumber == "20")
            {
                s025 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s025.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s025_Samples = ExtractTrainingSamples(s025, N);

                    mu_s025 = CalculateTemplateVectors(s025_Samples, N);

                    for (int i = 0; i < mu_s025.Length; i++)
                    {
                        Console.WriteLine(mu_s025[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 21
            if (userNumber == "21")
            {
                s026 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s026.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s026_Samples = ExtractTrainingSamples(s026, N);

                    mu_s026 = CalculateTemplateVectors(s026_Samples, N);

                    for (int i = 0; i < mu_s026.Length; i++)
                    {
                        Console.WriteLine(mu_s026[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 22
            if (userNumber == "22")
            {
                s027 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s027.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s027_Samples = ExtractTrainingSamples(s027, N);

                    mu_s027 = CalculateTemplateVectors(s027_Samples, N);

                    for (int i = 0; i < mu_s027.Length; i++)
                    {
                        Console.WriteLine(mu_s027[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 23
            if (userNumber == "23")
            {
                s028 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s028.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s028_Samples = ExtractTrainingSamples(s028, N);

                    mu_s028 = CalculateTemplateVectors(s028_Samples, N);

                    for (int i = 0; i < mu_s028.Length; i++)
                    {
                        Console.WriteLine(mu_s028[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 24
            if (userNumber == "24")
            {
                s029 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s029.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s029_Samples = ExtractTrainingSamples(s029, N);

                    mu_s029 = CalculateTemplateVectors(s029_Samples, N);

                    for (int i = 0; i < mu_s029.Length; i++)
                    {
                        Console.WriteLine(mu_s029[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 25
            if (userNumber == "25")
            {
                s030 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s030.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s030_Samples = ExtractTrainingSamples(s030, N);

                    mu_s030 = CalculateTemplateVectors(s030_Samples, N);

                    for (int i = 0; i < mu_s030.Length; i++)
                    {
                        Console.WriteLine(mu_s030[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 26
            if (userNumber == "26")
            {
                s031 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s031.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s031_Samples = ExtractTrainingSamples(s031, N);

                    mu_s031 = CalculateTemplateVectors(s031_Samples, N);

                    for (int i = 0; i < mu_s031.Length; i++)
                    {
                        Console.WriteLine(mu_s031[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 27
            if (userNumber == "27")
            {
                s032 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s032.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s032_Samples = ExtractTrainingSamples(s032, N);

                    mu_s032 = CalculateTemplateVectors(s032_Samples, N);

                    for (int i = 0; i < mu_s032.Length; i++)
                    {
                        Console.WriteLine(mu_s032[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 28
            if (userNumber == "28")
            {
                s033 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s033.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s033_Samples = ExtractTrainingSamples(s033, N);

                    mu_s033 = CalculateTemplateVectors(s033_Samples, N);

                    for (int i = 0; i < mu_s033.Length; i++)
                    {
                        Console.WriteLine(mu_s033[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 29
            if (userNumber == "29")
            {
                s034 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s034.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s034_Samples = ExtractTrainingSamples(s034, N);

                    mu_s034 = CalculateTemplateVectors(s034_Samples, N);

                    for (int i = 0; i < mu_s034.Length; i++)
                    {
                        Console.WriteLine(mu_s034[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 30
            if (userNumber == "30")
            {
                s035 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s035.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s035_Samples = ExtractTrainingSamples(s035, N);

                    mu_s035 = CalculateTemplateVectors(s035_Samples, N);

                    for (int i = 0; i < mu_s035.Length; i++)
                    {
                        Console.WriteLine(mu_s035[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 31
            if (userNumber == "31")
            {
                s036 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s036.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s036_Samples = ExtractTrainingSamples(s036, N);

                    mu_s036 = CalculateTemplateVectors(s036_Samples, N);

                    for (int i = 0; i < mu_s036.Length; i++)
                    {
                        Console.WriteLine(mu_s036[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 32
            if (userNumber == "32")
            {
                s037 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s037.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s037_Samples = ExtractTrainingSamples(s037, N);

                    mu_s037 = CalculateTemplateVectors(s037_Samples, N);

                    for (int i = 0; i < mu_s037.Length; i++)
                    {
                        Console.WriteLine(mu_s037[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 33
            if (userNumber == "33")
            {
                s038 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s038.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s038_Samples = ExtractTrainingSamples(s038, N);

                    mu_s038 = CalculateTemplateVectors(s038_Samples, N);

                    for (int i = 0; i < mu_s038.Length; i++)
                    {
                        Console.WriteLine(mu_s038[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 34
            if (userNumber == "34")
            {
                s039 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s039.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s039_Samples = ExtractTrainingSamples(s039, N);

                    mu_s039 = CalculateTemplateVectors(s039_Samples, N);

                    for (int i = 0; i < mu_s039.Length; i++)
                    {
                        Console.WriteLine(mu_s039[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 35
            if (userNumber == "35")
            {
                s040 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s040.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s040_Samples = ExtractTrainingSamples(s040, N);

                    mu_s040 = CalculateTemplateVectors(s040_Samples, N);

                    for (int i = 0; i < mu_s040.Length; i++)
                    {
                        Console.WriteLine(mu_s040[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }            
            #endregion

            #region For user 36
            if (userNumber == "36")
            {
                s041 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s041.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s041_Samples = ExtractTrainingSamples(s041, N);

                    mu_s041 = CalculateTemplateVectors(s041_Samples, N);

                    for (int i = 0; i < mu_s041.Length; i++)
                    {
                        Console.WriteLine(mu_s041[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 37
            if (userNumber == "37")
            {
                s042 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s042.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s042_Samples = ExtractTrainingSamples(s042, N);

                    mu_s042 = CalculateTemplateVectors(s042_Samples, N);

                    for (int i = 0; i < mu_s042.Length; i++)
                    {
                        Console.WriteLine(mu_s042[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 38
            if (userNumber == "38")
            {
                s043 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s042.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s043_Samples = ExtractTrainingSamples(s043, N);

                    mu_s043 = CalculateTemplateVectors(s043_Samples, N);

                    for (int i = 0; i < mu_s043.Length; i++)
                    {
                        Console.WriteLine(mu_s043[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 39
            if (userNumber == "39")
            {
                s044 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s044.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s044_Samples = ExtractTrainingSamples(s044, N);

                    mu_s044 = CalculateTemplateVectors(s044_Samples, N);

                    for (int i = 0; i < mu_s044.Length; i++)
                    {
                        Console.WriteLine(mu_s044[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 40
            if (userNumber == "40")
            {
                s046 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s046.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s046_Samples = ExtractTrainingSamples(s046, N);

                    mu_s046 = CalculateTemplateVectors(s046_Samples, N);

                    for (int i = 0; i < mu_s046.Length; i++)
                    {
                        Console.WriteLine(mu_s046[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 41
            if (userNumber == "41")
            {
                s047 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s047.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s047_Samples = ExtractTrainingSamples(s047, N);

                    mu_s047 = CalculateTemplateVectors(s047_Samples, N);

                    for (int i = 0; i < mu_s047.Length; i++)
                    {
                        Console.WriteLine(mu_s047[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 42
            if (userNumber == "42")
            {
                s048 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s042.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s048_Samples = ExtractTrainingSamples(s048, N);

                    mu_s048 = CalculateTemplateVectors(s048_Samples, N);

                    for (int i = 0; i < mu_s048.Length; i++)
                    {
                        Console.WriteLine(mu_s048[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 43
            if (userNumber == "43")
            {
                s049 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s049.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s049_Samples = ExtractTrainingSamples(s049, N);

                    mu_s049 = CalculateTemplateVectors(s049_Samples, N);

                    for (int i = 0; i < mu_s049.Length; i++)
                    {
                        Console.WriteLine(mu_s049[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 44
            if (userNumber == "44")
            {
                s050 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s050.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s050_Samples = ExtractTrainingSamples(s050, N);

                    mu_s050 = CalculateTemplateVectors(s050_Samples, N);

                    for (int i = 0; i < mu_s050.Length; i++)
                    {
                        Console.WriteLine(mu_s050[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 45
            if (userNumber == "45")
            {
                s051 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s051.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s051_Samples = ExtractTrainingSamples(s051, N);

                    mu_s051 = CalculateTemplateVectors(s051_Samples, N);

                    for (int i = 0; i < mu_s051.Length; i++)
                    {
                        Console.WriteLine(mu_s051[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 46
            if (userNumber == "46")
            {
                s052 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s052.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s052_Samples = ExtractTrainingSamples(s052, N);

                    mu_s052 = CalculateTemplateVectors(s052_Samples, N);

                    for (int i = 0; i < mu_s049.Length; i++)
                    {
                        Console.WriteLine(mu_s049[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 47
            if (userNumber == "47")
            {
                s053 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s053.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s053_Samples = ExtractTrainingSamples(s053, N);

                    mu_s053 = CalculateTemplateVectors(s053_Samples, N);

                    for (int i = 0; i < mu_s047.Length; i++)
                    {
                        Console.WriteLine(mu_s047[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 48
            if (userNumber == "48")
            {
                s054 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s054.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s054_Samples = ExtractTrainingSamples(s054, N);

                    mu_s054 = CalculateTemplateVectors(s054_Samples, N);

                    for (int i = 0; i < mu_s054.Length; i++)
                    {
                        Console.WriteLine(mu_s054[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 49
            if (userNumber == "49")
            {
                s055 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s055.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s055_Samples = ExtractTrainingSamples(s055, N);

                    mu_s055 = CalculateTemplateVectors(s055_Samples, N);

                    for (int i = 0; i < mu_s055.Length; i++)
                    {
                        Console.WriteLine(mu_s055[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 50
            if (userNumber == "50")
            {
                s056 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s056.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s056_Samples = ExtractTrainingSamples(s056, N);

                    mu_s056 = CalculateTemplateVectors(s056_Samples, N);

                    for (int i = 0; i < mu_s056.Length; i++)
                    {
                        Console.WriteLine(mu_s056[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            #region For user 51
            if (userNumber == "51")
            {
                s057 = ParseData(@"C:\Users\Pranav\Documents\GitHub\PranavK_ProgrammingAssignment1_CSCI860_Fall2014\ProgrammingAssignment1_SpecialTopics\Data Files\s057.csv");

                Console.Write("Enter N: The number of samples. Value of N could be either 100, 200, or 300" + Environment.NewLine + "N = ");
                string inputN = Console.ReadLine();

                if (inputN == "100" || inputN == "200" || inputN == "300")
                {
                    int N = int.Parse(inputN);

                    double[,] s057_Samples = ExtractTrainingSamples(s057, N);

                    mu_s057 = CalculateTemplateVectors(s057_Samples, N);

                    for (int i = 0; i < mu_s057.Length; i++)
                    {
                        Console.WriteLine(mu_s057[i]);
                    }
                }

                else if (inputN != "100" || inputN == "200" || inputN != "300")
                {
                    Console.WriteLine("Your input sampling is too large, the program will now quit");
                    Console.ReadKey();
                }
            }
            #endregion

            Console.ReadKey(); // Default program termination
        }

        #region The Test Sample extraction, got that done
        /// <summary>
        /// This method should be able to take the existing 2D double array
        /// and extract the test samples.  However, I am unable to do so
        /// </summary>
        /// <param name="s002">The input array</param>
        /// <param name="M">The value which is calculated from 400 - N</param>
        /// <returns>The 2D array known as testSamples</returns>
        static double[,] ExtractTestingSamples(double[,] s002, int N)
        {
            if (N == 100)
            {
                double[,] test100 = new double[300, 21];

                for (int i = 0; i < 299; i++)
                {
                    for (int j = 0; j < test100.GetLength(1); j++)
                    {
                        // i = M;
                        test100[i, j] = s002[100 + i, j];
                    }
                }
                return test100; 
            }

            else if (N == 200)
            {
                double[,] test200 = new double[200, 21];

                for (int i = 0; i < 199; i++)
                {
                    for (int j = 0; j < test200.GetLength(1); j++)
                    {
                        // i = M;
                        test200[i, j] = s002[200 + i, j];
                    }
                }
                return test200; 
            }

            else if (N == 300)
            {
                double[,] test300 = new double[100, 21];

                for (int i = 0; i < 99; i++)
                {
                    for (int j = 0; j < test300.GetLength(1); j++)
                    {
                        // i = M;
                        test300[i, j] = s002[300 + i, j];
                    }
                }
                return test300; 
            }

            return s002; // Default return statement
        }
        #endregion

        #region Extraction of training samples based on the value of N
        /// <summary>
        /// This method will be used to extract the samples given the parameter of the sampling size.  
        /// </summary>
        /// <param name="s002">The data that is extracted or converted from the CSV file</param>
        /// <param name="N">Sample size</param>
        /// <returns>samples - 2D double array which contains the samples from the original data</returns>
        static double[,] ExtractTrainingSamples(double[,] s002, int N)
        {
            // Initialize the 2D double array
            double[,] samples = new double[N, 21]; 

            // Iterating over a nested for loop.
            for (int n = 0; n <= N - 1; n++)
            {
                for (int j = 0; j < s002.GetLength(1); j++)
                {
                    // Having the 2D double array being populated. 
                    samples[n, j] = s002[n, j]; 
                }
            }

            // This is what will be returned and this variable will automatically undergo polymorphism
            return samples; 
        }
        #endregion

        #region Template vector creation
        /// <summary>
        /// This method will calculate the template vectors using the user data
        /// </summary>
        /// <param name="s002_Samples">This is the array that has N samples extracted</param>
        /// <param name="N">Variable N, representing the sample size.  This value of N is used to generate the template data.</param>
        /// <returns>The average array that is called as mean</returns>
        static double[] CalculateTemplateVectors(double[,] s002_Samples, int N)
        {
            #region Creating two regular double arrays
            double[] sum = new double[s002_Samples.GetLength(1)];
            double[] mean = new double[s002_Samples.GetLength(1)];
            #endregion

            // Iterating over the 2D array in its entirety
            // Iterate over the rows of the 2D double array
            for (int i = 0; i < s002_Samples.GetLength(0); i++)
            {
                // Iterate over the columns of the 2D double array
                for (int j = 0; j < s002_Samples.GetLength(1); j++)
                {
                    // The sum array (one dimensional), in which each element is the 
                    // sum of each column in the samples array
                    sum[j] += s002_Samples[i, j]; 
                }
            }

            // Iterating over the mean array to
            for (int k = 0; k < mean.Length; k++)
            {
                mean[k] = sum[k] / N; 
            }

            return mean; 
        }
        #endregion

        #region CSV to 2D double array conversion
        /// <summary>
        /// This method will now convert the CSV files into 
        /// 2D double arrays
        /// </summary>
        /// <param name="filePath">The location of the CSV file</param>
        /// <returns>2D Double array with dimensions of 400 rows and 21 columns</returns>
        static double[,] ParseData(string filePath)
        {
            // I am using the String class, and will now be able to begin to convert the CSV file
            // into a 2D double array
            String input = File.ReadAllText(filePath); 

            // Initialize the counters
            int i = 0, j = 0;

            // Initialize the new 2D double array which has 400 rows and 21 columns
            double[,] values = new double[400, 21]; 

            // Using a nested foreach loop so that way I can be able to use the new line delimeter to break up the rows and the comma delimiter to remove the 
            // commas which separates each element. 
            foreach (var row in input.Split('\n'))
            {
                j = 0; 
                
                // Again using the nested foreach loop in order to remove the comma which separates the various values. 
                foreach (var col in row.Trim().Split(','))
                {
                    // Populating the double array with the data parsed from the CSV file
                    values[i, j] = double.Parse(col.Trim());
                    j++; // Increment the column
                }
                i++; // Increment the row
            }

            // Outputs the 2D double array called values, which in turn becomes the 
            // 2D double that is automatically named due to polymorphism. 
            return values;
        }
        #endregion
    }
}