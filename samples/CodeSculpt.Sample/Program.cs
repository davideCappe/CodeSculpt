using System.ComponentModel.DataAnnotations;
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

var priority = Priority.Low;

Console.WriteLine($"Priority is {priority.GetDescription()}");

var strings = new List<string>() { "VALORE1", "VALORE2" };

foreach (var item in strings.WithIndex())
{
    Console.WriteLine(item.Index + " " + item.Value);
}

public enum Priority
{
    [Display(Name = "Bassa")]
    Low,
    Medium,
    High
}

