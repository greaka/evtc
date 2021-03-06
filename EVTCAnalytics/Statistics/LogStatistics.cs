using System;
using System.Collections.Generic;
using System.Linq;
using GW2Scratch.EVTCAnalytics.Model.Agents;
using GW2Scratch.EVTCAnalytics.Model.Skills;
using GW2Scratch.EVTCAnalytics.Statistics.Buffs;
using GW2Scratch.EVTCAnalytics.Statistics.Encounters.Results;
using GW2Scratch.EVTCAnalytics.Statistics.PlayerDataParts;

namespace GW2Scratch.EVTCAnalytics.Statistics
{
	public class LogStatistics
	{
		public DateTimeOffset FightStart { get; }
		public Player LogAuthor { get; }

		public IEnumerable<PlayerData> PlayerData { get; }

		public IEnumerable<PhaseStats> PhaseStats { get; }
		public string EncounterName { get; }
		public EncounterResult EncounterResult { get; }

		public long FightTimeMs { get; }
		public string LogVersion { get; }

		public IReadOnlyDictionary<string, int> EventCounts { get; }
		public IEnumerable<Agent> Agents { get; }
		public IEnumerable<Skill> Skills { get; }

		public SquadDamageData FullFightSquadDamageData { get; }
		public BuffData BuffData { get; }
		public IEnumerable<TargetSquadDamageData> FullFightBossDamageData { get; }

		public LogStatistics(DateTimeOffset fightStart, Player logAuthor, IEnumerable<PlayerData> playerData,
			IEnumerable<PhaseStats> phaseStats, SquadDamageData fullFightSquadDamageData,
			IEnumerable<TargetSquadDamageData> fullFightTargetDamageData, BuffData buffData,
			EncounterResult encounterResult, string encounterName, string logVersion,
			IReadOnlyDictionary<string, int> eventCounts, IEnumerable<Agent> agents, IEnumerable<Skill> skills)
		{
			EncounterName = encounterName;
			LogVersion = logVersion;
			EncounterResult = encounterResult;
			EventCounts = eventCounts;
			FightStart = fightStart;
			LogAuthor = logAuthor;
			PlayerData = playerData.ToArray();
			FullFightSquadDamageData = fullFightSquadDamageData;
			BuffData = buffData;
			FullFightBossDamageData = fullFightTargetDamageData.ToArray();

			PhaseStats = phaseStats as PhaseStats[] ?? phaseStats.ToArray();
			FightTimeMs = PhaseStats.Sum(x => x.PhaseDuration);
			Agents = agents as Agent[] ?? agents.ToArray();
			Skills = skills as Skill[] ?? skills.ToArray();
		}
	}
}