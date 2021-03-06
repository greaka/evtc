using System.Collections.Generic;
using System.Linq;
using GW2Scratch.EVTCAnalytics.Model.Agents;

namespace GW2Scratch.EVTCAnalytics.Model.Skills
{
	public class SkillData
	{
		public int Id { get; }
		public string Name { get; }
		public string IconUrl { get; }
		public SkillType Type { get; }
		public WeaponType WeaponType { get; }
		public IEnumerable<Profession> Professions { get; }
		public SkillSlot Slot { get; }
		public SkillAttunement Attunement { get; }

		/* TODO: This makes serialization significantly more difficult (although doable)
		public SkillData NextChain { get; internal set; }
		public SkillData PrevChain { get; internal set; }
		*/

		public SkillData(int id, string name, string iconUrl, SkillType type, WeaponType weaponType,
			IEnumerable<Profession> professions, SkillSlot slot, SkillAttunement attunement)
		{
			Id = id;
			Name = name;
			IconUrl = iconUrl;
			Type = type;
			WeaponType = weaponType;
			Professions = professions.ToArray();
			Slot = slot;
			Attunement = attunement;
		}
	}
}