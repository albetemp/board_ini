using System;
using System.Runtime.InteropServices;

namespace AlbeFly.BoardControl
{
	/// <summary>
	/// Активирует окно.
	/// </summary>
	public static class WindowActivator
	{
		#region CmdShow enum
		public enum CmdShow
		{
			ShowNoActivate = 4,
			ShowMinNoActive = 7,
			ShowNA = 8,
			Restore = 9,
		}
		#endregion

		[DllImport("User32.dll")]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("User32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("User32.dll")]
		private static extern bool IsIconic(IntPtr hWnd);

		[DllImport("User32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, CmdShow cmdShow);

		public static void ActivateWindow(string windowTitle)
		{
			var hWnd = FindWindow(null, windowTitle);

			if (IsIconic(hWnd))
				ShowWindow(hWnd, CmdShow.Restore);

			SetForegroundWindow(hWnd);
		}
	}
}