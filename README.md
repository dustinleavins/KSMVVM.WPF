# KSMVVM - Kinda Small MVVM Framework (WPF)

There are plenty of MVVM frameworks for WPF, and many of those are nano/micro frameworks. So, why make another?

This particular framework is designed for helping dev convert code-behind projects to MVVM. So it's a little different because of this.

Here are some bullet points.

* ViewModel-level navigation capability
* No messaging component (yet)
* UI-specific code can go in the ViewModel if wrapped using the Skippable.Do() method
* Two ICommand implementations (BasicCommand is easier for conversions, CustomCommand is better for new code)

This is very much a Work-In-Progress and is not up on NuGet.
