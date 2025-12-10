using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Collections.Generic;

namespace LexicalAnalyzer {
  class Program {
    // Token Definition
    static HashSet<string> keywords = new HashSet<string> {
        "if", "else", "while", "for", "return", "int", "void", "string", "float", "double", "bool"
    };

    static HashSet<string> operators = new HashSet<string> {
      "+", "-", "*", "/", "=", "==", "!=", "<", ">", ",", "<=", ">=", "&&", "||", "!"  
    };

    static HashSet<string> separators = new HashSet<string> {
      "(", ")", "{", "}", "[", "]", ";", ","
    };
    // Comment Removal
    static string RemoveComments(string sean) {
          sean = Regex.Replace(sean, @"//.*", "");
          sean = Regex.Replace(sean, @"/\*.*?\*/", "", RegexOptions.Singleline);
          return sean;
        }

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
    static string ClassifyToken(string lexeme) {
      if (keywords.Contains(lexeme))
        return "keyword";
      
      else if (operators.Contains(lexeme))
        return "operator";
      
      else if (separators.Contains(lexeme))
        return "separators";
      
      else if (Regex.IsMatch(lexeme, @"^\d+$"))
        return "integer";
      
      else if (Regex.IsMatch(lexeme, @"^[a-zA-Z_]\w*$"))
        return "identifier";

      else
        return "unknown";
    }    

    // main function
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
