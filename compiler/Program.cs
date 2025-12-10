using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Collections.Generic;

namespace LexicalAnalyzer {
  class Program {
    // Token Definition
    // All keywords are put into this hashset
    static HashSet<string> keywords = new HashSet<string> {
        "if", "else", "while", "for", "return", "int", "void", "string", "float", "double", "bool"
    };
    // All operators are put into this hashset
    static HashSet<string> operators = new HashSet<string> {
      "+", "-", "*", "/", "=", "==", "!=", "<", ">", ",", "<=", ">=", "&&", "||", "!"  
    };
  // All separators are put into this hashset.
    static HashSet<string> separators = new HashSet<string> {
      "(", ")", "{", "}", "[", "]", ";", ","
    };
    // Comment Removal
    // This function removes comments to only contain the code
    static string RemoveComments(string input) {
          input = Regex.Replace(input, @"//.*", "");
          input = Regex.Replace(input, @"/\*.*?\*/", "", RegexOptions.Singleline);
          return input;
        }
//This function turns everything inside the input into separated tokens.
    static List<string> Tokenize(string input) {
          List<string> tokens = new List<string>();

            string pattern = @"[a-zA-Z_]\w*|\d+|==|!=|<=|>=|&&|\|\||[+\-*/=<>;,()\[\]{}]";

            foreach (Match match in Regex.Matches(input, pattern))
            {
                tokens.Add(match.Value);
            }

            return tokens;

            
        }
    // Classification
    // This function checks the lexeme to identify its kind of token
    static string ClassifyToken(string lexeme) {
      if (keywords.Contains(lexeme))
        return "keyword";
      
      else if (operators.Contains(lexeme))
        return "operator";
      
      else if (separators.Contains(lexeme))
        return "separators";
      
      else if (Regex.IsMatch(lexeme, @"^\d+(\.\d+)?$") || Regex.IsMatch(lexeme, "^\".*\"$") || lexeme == "true" || lexeme == "false")
        return "literals";
      
      else if (Regex.IsMatch(lexeme, @"^[a-zA-Z_]\w*$"))
        return "identifier";

      else
        return "unknown";
    }    

    // Main function
    // The main function takes in the input.txt, removes all comments, and then turns it into tokens. It then identifies which tokens it is.
    static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");

            input = RemoveComments(input);

            List<string> lexemes = Tokenize(input);

            foreach (string lexeme in lexemes)
            {
                Console.WriteLine($"\"{lexeme}\" = {ClassifyToken(lexeme)}");
            }
        }
  }
}
