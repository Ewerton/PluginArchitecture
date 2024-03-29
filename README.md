# Plugin Architecture
A simple solution to demonstrate how to implement a "plugin-like" behavior in a .net assembly.

In a "plugin-like" mode, the assembly knows how to register your own dependencies (like <a href="https://github.com/Ewerton/PluginArchitecture/blob/master/Data/DependencyInjectionPackage.cs" target="_blank">this</a> or <a href="https://github.com/Ewerton/PluginArchitecture/blob/master/Business/DependencyInjectionPackage.cs" target="_blank">this</a>, so, you just need to compile and copy the assembly to the program folder without needing to update the whole program.

I explored this concept in <a href="http://ewer.com.br/plugin-architecture-with-di-containers/" target="_blank">this blog post</a>.

I Also provided three "Views", a <a href="https://github.com/Ewerton/SimpleInjector-PluginArchitecture/tree/master/ConsoleView" target="_blank">console view</a>, a <a href="https://github.com/Ewerton/PluginArchitecture/tree/master/AspNetCoreMvcWebView" target="_blank">Asp.Net Core Mvc View</a> and a <a href="https://github.com/Ewerton/PluginArchitecture/tree/master/AspNetMvcWebView" target="_blank">Asp.Net Mvc "Full Framework" View</a>
to show how to use this concept in different projects types.
