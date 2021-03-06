using System.Threading.Tasks;
using GW2Scratch.EVTCAnalytics;

namespace GW2Scratch.RotationComparison.GW2Api
{
	public class FileApiDataSource : IApiDataSource
	{
		private readonly string filename;

		public FileApiDataSource(string filename)
		{
			this.filename = filename;
		}

		public Task<GW2ApiData> GetApiDataAsync()
		{
			return GW2ApiData.LoadFromFileAsync(filename);
		}
	}
}