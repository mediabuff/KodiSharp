﻿using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using Smx.KodiInterop;
using Smx.KodiInterop.Messages;
using System.Collections.Generic;
using System;
using System.Threading;

using Smx.KodiInterop.Builtins;

namespace TestPlugin {
	public class TestPlugin
    {
		private static string PluginPath = null;
		[DllExport("PluginInit", CallingConvention = CallingConvention.Cdecl)]
		public static void PluginInit(string pluginPath) {
			PluginPath = pluginPath;
		}

		[DllExport("PluginMain", CallingConvention = CallingConvention.Cdecl)]
		public static int PluginMain() {
			PyConsole.WriteLine("Hello Python");

			PythonInterop.EvalToVar("sum", "1 + 2");
			string opResult = PythonInterop.GetVariable("sum");
			PythonInterop.DestroyVariable("sum");

			PyConsole.WriteLine("Result: " + opResult);
			UiBuiltins.Notification(
				header: "My Notification",
				message: "Hello World from C#",
				duration: TimeSpan.FromSeconds(10)
			);
			return 0;
		}
	}
}
