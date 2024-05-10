using CodeSculpt.Extensions;

var a = "Marco";
var b = "marco";

if (a.EqualsIgnoreCase(b))
{
    Console.WriteLine("Sono uguali");
}
else
{
    Console.WriteLine("Sono diverse");
}

string? personId = null;

var name = personId ?? "(sconosciuto)";

//Console.WriteLine($"Priority is {priority.GetDescription()}");

var strings = new List<string>() { "VALORE1", "VALORE2" };

