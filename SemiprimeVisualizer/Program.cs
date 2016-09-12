using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemiprimeVisualizer
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;

			Application.Run(new MainForm());
		}

		private static string exceptionFilename = "FirstChanceException.log.txt";
		private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
		{
			File.AppendAllText(exceptionFilename, "Exception.Message:\t" + e.Exception.Message + Environment.NewLine);
			File.AppendAllText(exceptionFilename, "Exception.StackTrace:\t" + e.Exception.StackTrace + Environment.NewLine);
			File.AppendAllText(exceptionFilename, "Exception.Source:\t" + e.Exception.Source + Environment.NewLine);
			File.AppendAllText(exceptionFilename, "Exception.TargetSite:\t" + e.Exception.TargetSite+ Environment.NewLine);
			File.AppendAllText(exceptionFilename, "Exception.String:\t" + e.Exception.ToString() + Environment.NewLine);
			File.AppendAllText(exceptionFilename, Environment.NewLine);

			MessageBox.Show(e.Exception.Message + Environment.NewLine + Environment.NewLine + e.Exception.StackTrace);
		}
	}
}
