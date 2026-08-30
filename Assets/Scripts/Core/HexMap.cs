using System.Collections.Generic;
using UnityEngine;

namespace RiseOfTurkics.Core
{
    public class HexMap : MonoBehaviour
    {
        public int Width = 256;
        public int Height = 256;

        private readonly Dictionary<string, Hex> _hexes = new();

        private void Awake()
        {
            Generate();
        }

        private void Generate()
        {
            _hexes.Clear();

            for (int q = 0; q < Width; q++)
            {
                for (int r = 0; r < Height; r++)
                {
                    var biome = (Biome)((q + r) % System.Enum.GetNames(typeof(Biome)).Length);
                    var hex = new Hex(q, r, biome);
                    _hexes[Key(q, r)] = hex;
                }
            }

            Debug.Log($"Generated {Width}x{Height} hex map ({_hexes.Count} hexes)");
        }

        public bool TryGetHex(int q, int r, out Hex hex)
        {
            return _hexes.TryGetValue(Key(q, r), out hex);
        }

        public void SetOwner(int q, int r, string owner)
        {
            var key = Key(q, r);
            if (_hexes.TryGetValue(key, out var hex))
            {
                hex.Owner = owner;
                _hexes[key] = hex;
            }
        }

        public IEnumerable<Hex> AllHexes()
        {
            return _hexes.Values;
        }

        public static string Key(int q, int r)
        {
            return q + "," + r;
        }
    }
}
