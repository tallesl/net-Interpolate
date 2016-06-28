# Interpolate

[![][build-img]][build]
[![][nuget-img]][nuget]

If you can't get your hands on [C# 6] yet, here's [Haack's], [Hanselman's], [Henri's], [James'] and [Oskar's]
implementations of string interpolation.

The [original solution] is from Phil Haack, I tweaked few things and made a NuGet package for it.

```cs
using InterpolateLibrary;

Console.WriteLine("I like to {what}, {what}".HaackFormat(new { what = "move it" }));
Console.WriteLine("I like to {what}, {what}".HanselmanFormat(new { what = "move it" }));
Console.WriteLine("I like to {what}, {what}".HenriFormat(new { what = "move it" }));
Console.WriteLine("I like to {what}, {what}".JamesFormat(new { what = "move it" }));
Console.WriteLine("I like to {what}, {what}".OskarFormat(new { what = "move it" }));
```

[build]:             https://ci.appveyor.com/project/TallesL/net-interpolate
[build-img]:         https://ci.appveyor.com/api/projects/status/github/tallesl/net-interpolate?svg=true
[nuget]:             https://www.nuget.org/packages/Interpolate
[nuget-img]:         https://badge.fury.io/nu/Interpolate.svg
[C# 6]:              https://msdn.microsoft.com/library/dn961160
[Haack's]:           http://haacked.com/archive/2009/01/04/fun-with-named-formats-string-parsing-and-edge-cases.aspx
[Hanselman's]:       http://hanselman.com/blog/ASmarterOrPureEvilToStringWithExtensionMethods.aspx
[Henri's]:           http://haacked.com/archive/2009/01/14/named-formats-redux.aspx
[James']:            http://james.newtonking.com/archive/2008/03/29/formatwith-2-0-string-formatting-with-named-variables
[Oskar's]:           http://mo.notono.us/2008/07/c-stringinject-format-strings-by-key.html
[original solution]: http://haacked.com/archive/2009/01/14/named-formats-redux.aspx
