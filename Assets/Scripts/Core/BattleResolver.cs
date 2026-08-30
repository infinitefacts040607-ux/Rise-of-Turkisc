using System;
using System.Linq;

namespace RiseOfTurkics.Core
{
    public static class BattleResolver
    {
        public static BattleResult Resolve(string attackerFaction, Unit[] attackers, string defenderFaction, Unit[] defenders, Biome terrain)
        {
            var atkStrength = attackers.Sum(u => u.Attack * u.Count);
            var defStrength = defenders.Sum(u => u.Defense * u.Count);

            if (terrain == Biome.Steppe)
                atkStrength = (int)(atkStrength * 1.2f);

            if (terrain == Biome.Mountain)
                defStrength = (int)(defStrength * 1.25f);

            var cavalryBonus = attackers.Where(u => u.Type == UnitType.HeavyCavalry).Sum(u => u.Count) * 2;
            if (terrain == Biome.Steppe)
                atkStrength += cavalryBonus;

            var ratio = (double)atkStrength / Math.Max(1, defStrength);

            var result = new BattleResult
            {
                WinnerFaction = ratio > 1.1 ? attackerFaction :
                    ratio < 0.9 ? defenderFaction :
                    (DateTime.Now.Ticks % 2 == 0 ? attackerFaction : defenderFaction),

                AttackerLosses = (int)(attackers.Sum(u => u.Count) * (ratio > 1.1 ? 0.2f : 0.6f)),
                DefenderLosses = (int)(defenders.Sum(u => u.Count) * (ratio < 0.9 ? 0.2f : 0.6f))
            };

            return result;
        }
    }
}
