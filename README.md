# KSMVVM - Kinda Small MVVM Framework (WPF)

There are plenty of MVVM frameworks for WPF, and many of those are nano/micro frameworks. So, why make another?

This particular framework is designed for helping devs convert code-behind projects to MVVM. So it's a little different because of this.

Here are some bullet points.

* ViewModel-level navigation capability
* Very lightweight messaging (pass an id and a single action to the Register method)
* Two ICommand implementations (BasicCommand is easier for conversions, CustomCommand is better for new code)

KSMVVM.WPF is a work-in-progress.

## Getting Started

[KSMVVM.WPF is on NuGet](https://www.nuget.org/packages/KSMVVM.WPF/) and should be compatible with .NET 4.0 and 4.5 solutions. Just add it to your WPF project; there is no additional setup.

If you want to build the KSMVVM.WPF solution, it uses Visual Studio's "NuGet Package Restore" feature so it should automatically pull NUnit (used for unit testing) for you.

## Example Project

[CIB Collection Manager](https://github.com/dustinleavins/LeavinsSoftware.CIB) is a fully-usable solution for managing comic/game/collectible collections that uses KSMVVM.WPF.

## License
MIT License. Please check LICENSE.txt for full details.

## Contact

Dustin Leavins created this toolkit. He can be reached on Github ([dustinleavins](https://github.com/dustinleavins)) and occasionally on Twitter at [@dustin_leavins](https://twitter.com/dustin_leavins).
