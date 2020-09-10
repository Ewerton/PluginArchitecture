# SimpleInjector-PluginArchitecture
A simple solution to demonstrate how to implement a "plugin-like" behavior in a .net assembly.

In a "plugin-like" mode, the assembly knows how to register your own dependencies (like [this](/Data/DependencyInjectionPackage.cs)  or [this](/Business/DependencyInjectionPackage.cs), so, you just need to compile and copy the assembly to the program folder without needing to update the whole program.

I explored this concept in [this blog post](https://dev.to/ewernet/where-and-how-register-our-dependencies-1g78-temp-slug-5502486?preview=be68a73aae4f7a41cf16c3c1bdd2f8f1980e2d9d4eba8f2bff7044aefd7ab74bc24038112eeb1af435b59b0625b0200e6b58401860cfc97c84cad6d4).

I Also provided two "Views", a [console view](/ConsoleView) and a [Asp.Net Core Mvc View](/AspNetCoreMvcWebView) to show how to use this concept in different projects
