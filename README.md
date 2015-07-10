[![][nuget-img]][nuget]

[nuget]:     http://badge.fury.io/nu/NamedFormat
[nuget-img]: https://badge.fury.io/nu/NamedFormat.png

[Haack's][haack], [Hanselman's][hanselman], [Henri's][henri], [James'][james] and [Oskar's][oskar] implementations of custom named placeholders string formatting (*[string.Format][string.Format] with names*).

[The original solution is from Phil Haack][original], I tweaked very few things and made a NuGet package for it.

```cs
Console.WriteLine("I like to {what}, {what}.".HaackFormat(new { what = "move it" }));
Console.WriteLine("I like to {what}, {what}.".HanselmanFormat(new { what = "move it" }));
Console.WriteLine("I like to {what}, {what}.".HenriFormat(new { what = "move it" }));
Console.WriteLine("I like to {what}, {what}.".JamesFormat(new { what = "move it" }));
Console.WriteLine("I like to {what}, {what}.".OskarFormat(new { what = "move it" }));
```

[haack]:     http://haacked.com/archive/2009/01/04/fun-with-named-formats-string-parsing-and-edge-cases.aspx
[hanselman]: http://hanselman.com/blog/ASmarterOrPureEvilToStringWithExtensionMethods.aspx
[henri]:     http://haacked.com/archive/2009/01/14/named-formats-redux.aspx
[james]:     http://james.newtonking.com/archive/2008/03/29/formatwith-2-0-string-formatting-with-named-variables
[oskar]:     http://mo.notono.us/2008/07/c-stringinject-format-strings-by-key.html

[string.Format]: https://msdn.microsoft.com/library/system.string.format.aspx
[original]:      http://haacked.com/archive/2009/01/14/named-formats-redux.aspx
