using System;
using System.Collections.Generic;

namespace RiseOfTurkics.Core
{
    public class TurnEventArgs : EventArgs
    {
        public int TurnNumber { get; set; }
        public string Faction { get; set; }
    }

    public class TurnManager
    {
        public int CurrentTurn { get; private set; } = 1;
        public string CurrentFaction { get; private set; }

        public event EventHandler<TurnEventArgs> TurnStarted;
        public event EventHandler<TurnEventArgs> TurnEnded;

        private readonly Queue<string> _order;

        public TurnManager(IEnumerable<string> factions)
        {
            _order = new Queue<string>(factions);
            CurrentFaction = _order.Peek();
        }

        public void StartTurn()
        {
            TurnStarted?.Invoke(this, new TurnEventArgs
            {
                TurnNumber = CurrentTurn,
                Faction = CurrentFaction
            });
        }

        public void EndTurn()
        {
            TurnEnded?.Invoke(this, new TurnEventArgs
            {
                TurnNumber = CurrentTurn,
                Faction = CurrentFaction
            });

            var first = _order.Dequeue();
            _order.Enqueue(first);
            CurrentFaction = _order.Peek();
            CurrentTurn++;
            StartTurn();
        }
    }
}
