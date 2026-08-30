using System;
using System.Collections.Generic;

namespace RiseOfTurkics.Core
{
    public enum UnitType
    {
        TurkicInfantry,
        HeavyCavalry,
        Archer,
        Siege,
        Dragoon
    }

    public enum Biome
    {
        Steppe,
        Oasis,
        Mountain,
        City,
        Capital,
        Desert,
        Trade,
        Culture
    }

    [Serializable]
    public class Unit
    {
        public string Id = Guid.NewGuid().ToString();
        public UnitType Type;
        public int Count;
        public int Attack;
        public int Defense;
        public int Movement;
        public int TechLevel;

        public Unit(UnitType type, int count, int techLevel)
        {
            Type = type;
            Count = count;
            TechLevel = techLevel;

            switch (type)
            {
                case UnitType.TurkicInfantry:
                    Attack = 5; Defense = 3; Movement = 2; break;
                case UnitType.HeavyCavalry:
                    Attack = 8; Defense = 1; Movement = 4; break;
                case UnitType.Archer:
                    Attack = 3; Defense = 4; Movement = 2; break;
                case UnitType.Siege:
                    Attack = 12; Defense = 6; Movement = 1; break;
                case UnitType.Dragoon:
                    Attack = 4; Defense = 2; Movement = 5; break;
            }
        }
    }

    [Serializable]
    public struct Hex
    {
        public int Q;
        public int R;
        public Biome Biome;
        public string Owner;
        public List<Unit> Garrison;

        public Hex(int q, int r, Biome biome)
        {
            Q = q;
            R = r;
            Biome = biome;
            Owner = string.Empty;
            Garrison = new List<Unit>();
        }
    }

    [Serializable]
    public class BattleResult
    {
        public string WinnerFaction;
        public int AttackerLosses;
        public int DefenderLosses;
    }

    [Serializable]
    public class SaveData
    {
        public string SaveName;
        public string Campaign;
        public int CurrentBattle;
        public string PlayerFaction;
        public int GameYear;
        public int Livestock;
        public int Trade;
        public int Culture;
        public int Technology;
    }
}
