using System.Collections.Generic;
using UnityEngine;

namespace RiseOfTurkics.Core
{
    public class GameController : MonoBehaviour
    {
        public HexMap Map;
        public TurnManager TurnManager;

        public Dictionary<string, int> Resources = new()
        {
            ["livestock"] = 450,
            ["trade"] = 250,
            ["culture"] = 180,
            ["technology"] = 80
        };

        public List<string> Factions = new()
        {
            "KazakhKhanate",
            "GoldenHorde",
            "Tang",
            "Sasanian"
        };

        private void Start()
        {
            if (Map == null)
                Map = FindObjectOfType<HexMap>();

            TurnManager = new TurnManager(Factions);
            TurnManager.TurnStarted += OnTurnStarted;
            TurnManager.TurnEnded += OnTurnEnded;

            TurnManager.StartTurn();
        }

        private void OnTurnStarted(object sender, TurnEventArgs e)
        {
            Debug.Log($"Turn {e.TurnNumber}: {e.Faction}");
        }

        private void OnTurnEnded(object sender, TurnEventArgs e)
        {
            Debug.Log($"Turn ended: {e.Faction}");
        }

        public void EndTurn()
        {
            TurnManager.EndTurn();
        }

        public BattleResult ResolveBattle(string attackerFaction, Unit[] attackers, string defenderFaction, Unit[] defenders, Biome terrain)
        {
            return BattleResolver.Resolve(attackerFaction, attackers, defenderFaction, defenders, terrain);
        }
    }
}
