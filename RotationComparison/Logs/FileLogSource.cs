using System.IO;
using GW2Scratch.EVTCAnalytics;
using GW2Scratch.EVTCAnalytics.Model;

namespace GW2Scratch.RotationComparison.Logs
{
	public class FileLogSource : ScratchParserLogSource
	{
		private readonly string filename;
		private Log processedLog;

		public FileLogSource(string filename)
		{
			this.filename = filename;
		}

		protected override Log GetLog()
		{
			if (processedLog == null)
			{
				var parser = new EVTCParser();
				var processor = new LogProcessor();
				var parsedLog = parser.ParseLog(filename);
				processedLog = processor.GetProcessedLog(parsedLog);
			}

			return processedLog;
		}

		public override string GetLogName()
		{
			return Path.GetFileName(filename);
		}
	}
}