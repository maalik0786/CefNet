using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using CefNet;
using WinFormsCoreApp;

namespace WpfCoreApp
{
	/// <summary>
	///  Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private CefAppImpl app;
		private Timer messagePump;
		private readonly int messagePumpDelay = 10;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var cefPath = Path.Combine(Path.GetDirectoryName(GetProjectPath()), "cef");
			var externalMessagePump = e.Args.Contains("--external-message-pump");

			var settings = new CefSettings();
			settings.MultiThreadedMessageLoop = !externalMessagePump;
			settings.ExternalMessagePump = externalMessagePump;
			settings.NoSandbox = true;
			settings.WindowlessRenderingEnabled = true;
			settings.LocalesDirPath = Path.Combine(cefPath, "Resources", "locales");
			settings.ResourcesDirPath = Path.Combine(cefPath, "Resources");
			settings.LogSeverity = CefLogSeverity.Warning;
			settings.IgnoreCertificateErrors = true;
			settings.UncaughtExceptionStackSize = 8;

			app = new CefAppImpl();
			app.ScheduleMessagePumpWorkCallback = OnScheduleMessagePumpWork;
			app.Initialize(Path.Combine(cefPath, "Release"), settings);

			if (externalMessagePump)
				messagePump = new Timer(_ => Dispatcher.BeginInvoke(new Action(CefApi.DoMessageLoopWork)), null,
					messagePumpDelay, messagePumpDelay);
		}

		protected override void OnExit(ExitEventArgs e)
		{
			//Thread.Sleep(1000);
			GC.Collect();
			GC.WaitForPendingFinalizers();

			messagePump?.Dispose();
			app?.Shutdown();
			base.OnExit(e);
		}

		private async void OnScheduleMessagePumpWork(long delayMs)
		{
			await Task.Delay((int) delayMs);
			await Dispatcher.InvokeAsync(CefApi.DoMessageLoopWork);
		}

		private static string GetProjectPath()
		{
			var projectPath = Path.GetDirectoryName(typeof(App).Assembly.Location);
			var rootPath = Path.GetPathRoot(projectPath);
			while (Path.GetFileName(projectPath) != "WpfCoreApp")
			{
				if (projectPath == rootPath)
					throw new DirectoryNotFoundException("Could not find the project directory.");
				projectPath = Path.GetDirectoryName(projectPath);
			}

			return projectPath;
		}
	}
}