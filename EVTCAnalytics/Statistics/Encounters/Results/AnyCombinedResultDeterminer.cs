using System;
using System.Collections.Generic;
using System.Linq;
using GW2Scratch.EVTCAnalytics.Events;

namespace GW2Scratch.EVTCAnalytics.Statistics.Encounters.Results
{
	/// <summary>
	/// Combines the result of multiple determiners, returning success if any succeeded, then unknown if any
	/// is unknown and failure otherwise.
	/// </summary>
	public class AnyCombinedResultDeterminer : IResultDeterminer
	{
		private readonly IResultDeterminer[] determiners;

		public AnyCombinedResultDeterminer(params IResultDeterminer[] determiners)
		{
			if (determiners.Length == 0)
			{
				throw new ArgumentException("At least one determiner has to be provided", nameof(determiners));
			}

			this.determiners = determiners;
		}

		public EncounterResult GetResult(IEnumerable<Event> events)
		{
			var e = events as Event[] ?? events.ToArray();
			var results = determiners.Select(x => x.GetResult(e)).ToArray();

			if (results.Any(x => x == EncounterResult.Success)) return EncounterResult.Success;
			if (results.Any(x => x == EncounterResult.Unknown)) return EncounterResult.Unknown;
			return EncounterResult.Failure;
		}
	}
}