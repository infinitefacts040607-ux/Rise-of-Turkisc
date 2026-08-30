using UnityEngine;
using RiseOfTurkics.Core;

public class HexGridVisualizer : MonoBehaviour
{
    [SerializeField] private float hexSize = 1f;
    private HexMap hexMap;

    private void Start()
    {
        hexMap = FindObjectOfType<HexMap>();
        RenderHexGrid();
    }

    private void RenderHexGrid()
    {
        var gridObject = new GameObject("HexGrid");
        int renderLimit = 40;

        foreach (var hex in hexMap.AllHexes())
        {
            if (hex.Q >= renderLimit || hex.R >= renderLimit)
                continue;

            var pos = AxialToWorld(hex.Q, hex.R);
            var hexObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            hexObj.name = $"Hex_{hex.Q}_{hex.R}";
            hexObj.transform.position = pos;
            hexObj.transform.localScale = new Vector3(hexSize, 0.1f, hexSize);
            hexObj.transform.parent = gridObject.transform;

            var renderer = hexObj.GetComponent<Renderer>();
            renderer.material.color = GetBiomeColor(hex.Biome);

            DestroyImmediate(hexObj.GetComponent<Collider>());
        }

        Debug.Log("Hex grid rendered");
    }

    private Vector3 AxialToWorld(int q, int r)
    {
        float x = hexSize * (3f / 2f * q);
        float z = hexSize * (Mathf.Sqrt(3f) / 2f * q + Mathf.Sqrt(3f) * r);
        return new Vector3(x, 0, z);
    }

    private Color GetBiomeColor(Biome biome)
    {
        return biome switch
        {
            Biome.Steppe => new Color(0.8f, 0.7f, 0.3f),
            Biome.Mountain => new Color(0.5f, 0.5f, 0.5f),
            Biome.City => new Color(0.8f, 0.4f, 0.2f),
            Biome.Oasis => new Color(0.2f, 0.8f, 0.6f),
            Biome.Capital => new Color(1f, 0.2f, 0.2f),
            Biome.Desert => new Color(0.9f, 0.8f, 0.4f),
            Biome.Trade => new Color(0.3f, 0.3f, 0.8f),
            Biome.Culture => new Color(0.8f, 0.3f, 0.8f),
            _ => Color.white
        };
    }
}
