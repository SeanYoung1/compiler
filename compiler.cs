using System.Text.RegularExpressions;
using System;


// C# Keywords
HashSet<string> keywords = new HashSet<string> { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue",
            "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern",
            "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface",
            "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override",
            "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short",
            "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try",
            "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };

// C# operators
HashSet<string> operators = new HashSet<string> { "+", "-", "*", "/", "$", "=", "+=", "-=", "*=", "/=", "==", "!=", ">", "<", ">=", "<=", "&&", "||", "!",
                                                  "++", "--", "&", "|", "~", "^", "<<", ">>", "??", "?", "is", "as", "typeof" }; 
// C# seperators
HashSet<string> seperators = new HashSet<string> { "(", ")", "{", "}", "[", "]", ";", ",", ".", ":", "::", "?", "=>"};

// C# identifiers
HashSet<string> identifiers = new HashSet<string> { "a", "b"};



// token specs: list of token rules
// if you see this regex pattern, classify it as this token type

// @ = verbatim string
// \d: digits 0-9
// + : how many times the digits repeat (1 or more)
// () : capture digits
// \. :  period
// * : 0 or more
// ? : 0 or 1

// operators : must handle multiple types of operators ++ += == and also is, as
// match longest opeartor before shorter one
// re.escape to characters in input are treated as plain text rather than meanings
// handle word operators: \b word boundary
// build the alternation string
// 

List<(string Name, string Pattern)> tokenSpecs;
tokenSpecs = [
    ("NUMBER", @"\d+(\.\d*)?"),
    ("INDENT",   @"[A-Za-z]\w*"),
    ("OPERATOR", @"|.join(re.escape)"),
    ('SEPARATOR', ''),
    ('STRING', ''),
    ('STRING', ''),
    ('NEWLINE', ''),
    ('SKIP', ''),
    ('MISMATCH', '')
]

//-------------------------------------------------------------------// 
Regex NUMBER = new Regex (@"\d+(\.\d*)?");
Regex INDENT = new Regex (@"[a-zA-Z_]\w*");
Regex OPERATOR = new Regex ();
Regex SEPERATOR = new Regex ();


namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");    
    }
      }
}
