# KSMVVM - Kinda Small MVVM Framework (WPF)

There are plenty of MVVM frameworks for WPF, and many of those are nano/micro frameworks. So, why make another?

This particular framework is designed for helping devs convert code-behind projects to MVVM. So it's a little different because of this.

Here are some bullet points.

* ViewModel-level navigation capability
* Very lightweight messaging (pass an id and a single action to the Register method)
* Two ICommand implementations (BasicCommand is easier for conversions, CustomCommand is better for new code)

KSMVVM.WPF is a work-in-progress.

## Getting Started

[KSMVVM.WPF is on NuGet](https://www.nuget.org/packages/KSMVVM.WPF/) and should be compatible with .NET 4.0 and 4.5 solutions.

If you want to build the KSMVVM.WPF solution, it uses Visual Studio's "NuGet Package Restore" feature so it should automatically pull NUnit (used for unit testing) for you.

## License
MIT License. Please check LICENSE.txt for full details.
