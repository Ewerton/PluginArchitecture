# PluginArchitecture
A simple solution to demonstrate how to implement a "plugin-like" behavior in a .net assembly.

In a "plugin-like" mode, the assembly knows how to register your own dependencies (like <a href="https://github.com/Ewerton/PluginArchitecture/blob/master/Data/DependencyInjectionPackage.cs" target="_blank">this</a> or <a href="https://github.com/Ewerton/PluginArchitecture/blob/master/Business/DependencyInjectionPackage.cs" target="_blank">this</a>, so, you just need to compile and copy the assembly to the program folder without needing to update the whole program.

I explored this concept in <a href="https://dev.to/ewernet/where-and-how-register-our-dependencies-1g78-temp-slug-5502486?preview=be68a73aae4f7a41cf16c3c1bdd2f8f1980e2d9d4eba8f2bff7044aefd7ab74bc24038112eeb1af435b59b0625b0200e6b58401860cfc97c84cad6d4" target="_blank">this blog post</a>.

I Also provided three "Views", a <a href="https://github.com/Ewerton/SimpleInjector-PluginArchitecture/tree/master/ConsoleView" target="_blank">console view</a>, a <a href="https://github.com/Ewerton/PluginArchitecture/tree/master/AspNetCoreMvcWebView" target="_blank">Asp.Net Core Mvc View</a> and a <a href="https://github.com/Ewerton/PluginArchitecture/tree/master/AspNetMvcWebView" target="_blank">Asp.Net Mvc "Full Framework" View</a>
to show how to use this concept in different projects types.
