//-----------------------------------------------------------------------
// <copyright file="CATaclysm.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace CSharpPart2Exam
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for the solution of the task Cataclysm in the CSharp Part 2 Exam in TA 2015
    /// </summary>
    public class CATaclysm
    {
        /// <summary>
        /// Primitive data types
        /// </summary>
        private static string[] primitiveDataTypes =
            new string[] 
            { 
                "sbyte", "byte", "short", "ushort", "int", "uint", "long", 
                           "ulong", "float", "double", "decimal", "bool", "char", "string" 
            };

        /// <summary>
        /// List of method variables found
        /// </summary>
        private static List<string> methodVariables = new List<string>();

        /// <summary>
        /// List of conditional statements variables found
        /// </summary>
        private static List<string> conditionalStatementsVariables = new List<string>();

        /// <summary>
        /// List of loops variables found
        /// </summary>
        private static List<string> loopsVariables = new List<string>();

        /// <summary>
        /// Entry point for the solution
        /// </summary>
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            int openBrackets = 0;
            bool doNotAddScope = false;

            List<string> scopes = new List<string>();

            // Process each line separately
            for (int i = 0; i < lines; i++)
            {
                var currentLineTokens = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < currentLineTokens.Length; j++)
                {
                    var currentToken = currentLineTokens[j];
                    if (currentToken == "namespace")
                    {
                        openBrackets--;
                    }

                    if (currentToken.IndexOf("{") > -1)
                    {
                        openBrackets++;
                        if (openBrackets == 1 || openBrackets == 2)
                        {
                            scopes.Add("Method");
                        }
                        else
                        {
                            if (doNotAddScope)
                            {
                                doNotAddScope = false;
                            }
                            else
                            {
                                scopes.Add(string.Empty);
                            }
                        }
                    }

                    if (currentToken.IndexOf("}") > -1)
                    {
                        openBrackets--;
                        scopes.RemoveAt(scopes.Count - 1);
                    }

                    var checkForNewLatestScope = CalculateLatestScope(currentToken);
                    if (!string.IsNullOrEmpty(checkForNewLatestScope))
                    {
                        scopes.Add(checkForNewLatestScope);
                        doNotAddScope = true;
                    }

                    foreach (var dataType in primitiveDataTypes)
                    {
                        var indexOfDataType = currentToken.IndexOf(dataType);
                        if (indexOfDataType > -1 && CheckValidityOfToken(currentToken, indexOfDataType - 1, indexOfDataType + dataType.Length))
                        {
                            if (j + 1 < currentLineTokens.Length)
                            {
                                var nextTokenFirstSymbol = currentLineTokens[j + 1][0];

                                if (indexOfDataType + dataType.Length < currentToken.Length)
                                {
                                    if (!CheckSymbolForSpecialCases(currentToken[indexOfDataType + dataType.Length]))
                                    {
                                        continue;
                                    }
                                }

                                if (j - 1 >= 0)
                                {
                                    if (currentLineTokens[j - 1] == "static")
                                    {
                                        continue;
                                    }
                                }

                                if (CheckSymbolForSpecialCases(nextTokenFirstSymbol))
                                {
                                    string variableName;
                                    if (nextTokenFirstSymbol != '?')
                                    {
                                        variableName = currentLineTokens[j + 1];
                                    }
                                    else
                                    {
                                        variableName = currentLineTokens[j + 2];
                                    }

                                    for (int k = 0; k < variableName.Length; k++)
                                    {
                                        if (!char.IsLetter(variableName[k]))
                                        {
                                            variableName = variableName.Substring(0, k);
                                        }
                                    }

                                    for (int index = scopes.Count - 1; index >= 0; index--)
                                    {
                                        if (scopes[index] != string.Empty)
                                        {
                                            if (!string.IsNullOrWhiteSpace(variableName))
                                            {
                                                AddFoundVariable(variableName, scopes[index]);
                                            }

                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.Write("Methods -> ");
            Console.WriteLine(methodVariables.Count > 0 ? string.Join(", ", methodVariables) : "None");
            Console.Write("Loops -> ");
            Console.WriteLine(loopsVariables.Count > 0 ? string.Join(", ", loopsVariables) : "None");
            Console.Write("Conditional Statements -> ");
            Console.WriteLine(conditionalStatementsVariables.Count > 0 ? string.Join(", ", conditionalStatementsVariables) : "None");
        }

        /// <summary>
        /// Checks if the current token is valid
        /// </summary>
        /// <param name="token">Token to check</param>
        /// <param name="beforeIndex">Before which index</param>
        /// <param name="afterIndex">After which index</param>
        /// <returns>True or false</returns>
        private static bool CheckValidityOfToken(string token, int beforeIndex, int afterIndex)
        {
            if (beforeIndex < 0 && afterIndex >= token.Length)
            {
                return true;
            }

            if (beforeIndex < 0 && (!char.IsLetter(token[afterIndex]) || token[afterIndex] == '?' || token[afterIndex] == ','))
            {
                return true;
            }

            if (afterIndex >= token.Length && (!char.IsLetter(token[beforeIndex]) || token[beforeIndex] == '('))
            {
                return true;
            }

            if ((!char.IsLetter(token[beforeIndex]) || token[beforeIndex] == '(') && (!char.IsLetter(token[afterIndex]) || token[afterIndex] == '?' || token[afterIndex] == ','))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines the scope of the current variable
        /// </summary>
        /// <param name="currentToken">Current token</param>
        /// <returns>Scope of the variable as string</returns>
        private static string CalculateLatestScope(string currentToken)
        {
            var forKeywordIndex = currentToken.IndexOf("for");
            if (forKeywordIndex > -1 && currentToken.IndexOf("foreach") < 0 && CheckValidityOfToken(currentToken, forKeywordIndex - 1, forKeywordIndex + 3))
            {
                return "Loop";
            }

            var whileKeywordIndex = currentToken.IndexOf("while");
            if (whileKeywordIndex > -1 && CheckValidityOfToken(currentToken, whileKeywordIndex - 1, whileKeywordIndex + 5))
            {
                return "Loop";
            }

            var foreachKeywordIndex = currentToken.IndexOf("foreach");
            if (foreachKeywordIndex > -1 && CheckValidityOfToken(currentToken, foreachKeywordIndex - 1, foreachKeywordIndex + 7))
            {
                return "Loop";
            }

            var ifKeywordIndex = currentToken.IndexOf("if");
            if (ifKeywordIndex > -1 && CheckValidityOfToken(currentToken, ifKeywordIndex - 1, ifKeywordIndex + 2))
            {
                return "Conditional Statement";
            }

            var elseKeywordIndex = currentToken.IndexOf("else");
            if (elseKeywordIndex > -1 && CheckValidityOfToken(currentToken, elseKeywordIndex - 1, elseKeywordIndex + 4))
            {
                return "Conditional Statement";
            }

            return null;
        }

        /// <summary>
        /// Adds a found variable to the specified collection of variables determined by its scope
        /// </summary>
        /// <param name="variable">Variable to add</param>
        /// <param name="scope">Scope of the variable to add</param>
        private static void AddFoundVariable(string variable, string scope)
        {
            switch (scope)
            {
                case "Loop":
                    loopsVariables.Add(variable);
                    return;
                case "Conditional Statement":
                    conditionalStatementsVariables.Add(variable);
                    return;
                default:
                    methodVariables.Add(variable);
                    return;
            }
        }

        /// <summary>
        /// Check if a character matches any special character described in the assignment
        /// </summary>
        /// <param name="character">Character to check</param>
        /// <returns>True or false</returns>
        private static bool CheckSymbolForSpecialCases(char character)
        {
            if ((!(character == '>' || character == ')' || character == '(' || character == '[' || character == '.')) ||
                character == '?')
            {
                return true;
            }

            return false;
        }
    }
}