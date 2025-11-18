using System.Text.RegularExpressions;

Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
String s = "johndoe@tempuri.org";
if (args.Length > 0) {
    s = args[0];
}
Match m = emailregex.Match(s);
if (m.Success)
{
    Console.WriteLine ("User: " + m.Groups["user"].Value);
    Console.WriteLine ("Host: " + m.Groups["host"].Value);
}
else
{
    Console.WriteLine (s + " is not a valid email address");
}
Console.WriteLine ();
System.Console.WriteLine("Press Enter to Continue...");
System.Console.ReadLine();
