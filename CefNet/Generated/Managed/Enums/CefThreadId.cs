﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/internal/cef_types.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

namespace CefNet
{
	/// <summary>
	///  Existing thread IDs.
	/// </summary>
	public enum CefThreadId
	{
		/// <summary>
		///  The main thread in the browser. This will be the same as the main
		///  application thread if CefInitialize() is called with a
		///  CefSettings.multi_threaded_message_loop value of false. Do not perform
		///  blocking tasks on this thread. All tasks posted after
		///  CefBrowserProcessHandler::OnContextInitialized() and before CefShutdown()
		///  are guaranteed to run. This thread will outlive all other CEF threads.
		/// </summary>
		UI = 0,

		/// <summary>
		///  Used for blocking tasks (e.g. file system access) where the user won&apos;t
		///  notice if the task takes an arbitrarily long time to complete. All tasks
		///  posted after CefBrowserProcessHandler::OnContextInitialized() and before
		///  CefShutdown() are guaranteed to run.
		/// </summary>
		FileBackground = 1,

		/// <summary>
		///  Used for blocking tasks (e.g. file system access) where the user won&apos;t
		///  notice if the task takes an arbitrarily long time to complete. All tasks
		///  posted after CefBrowserProcessHandler::OnContextInitialized() and before
		///  CefShutdown() are guaranteed to run.
		/// </summary>
		File = FileBackground,

		/// <summary>
		///  Used for blocking tasks (e.g. file system access) that affect UI or
		///  responsiveness of future user interactions. Do not use if an immediate
		///  response to a user interaction is expected. All tasks posted after
		///  CefBrowserProcessHandler::OnContextInitialized() and before CefShutdown()
		///  are guaranteed to run.
		///  Examples:
		///  - Updating the UI to reflect progress on a long task.
		///  - Loading data that might be shown in the UI after a future user
		///  interaction.
		/// </summary>
		FileUserVisible = 2,

		/// <summary>
		///  Used for blocking tasks (e.g. file system access) that affect UI
		///  immediately after a user interaction. All tasks posted after
		///  CefBrowserProcessHandler::OnContextInitialized() and before CefShutdown()
		///  are guaranteed to run.
		///  Example: Generating data shown in the UI immediately after a click.
		/// </summary>
		FileUserBlocking = 3,

		/// <summary>
		///  Used to launch and terminate browser processes.
		/// </summary>
		ProcessLauncher = 4,

		/// <summary>
		///  Used to process IPC and network messages. Do not perform blocking tasks on
		///  this thread. All tasks posted after
		///  CefBrowserProcessHandler::OnContextInitialized() and before CefShutdown()
		///  are guaranteed to run.
		/// </summary>
		IO = 5,

		/// <summary>
		///  The main thread in the renderer. Used for all WebKit and V8 interaction.
		///  Tasks may be posted to this thread after
		///  CefRenderProcessHandler::OnWebKitInitialized but are not guaranteed to
		///  run before sub-process termination (sub-processes may be killed at any time
		///  without warning).
		/// </summary>
		Renderer = 6
	}
}