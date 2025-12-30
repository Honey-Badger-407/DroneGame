using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class PerlinTerrainGenerator : MonoBehaviour
{
    public int terrainWidth = 256;
    public int terrainHeight = 256;
    public int terrainDepth = 20;

    public float scale = 20f;
    public float offsetX = 0f;
    public float offsetY = 0f;

    private Terrain terrain;

    void Start()
    {
        terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = terrainWidth + 1;
        terrainData.size = new Vector3(terrainWidth, terrainDepth, terrainHeight);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[terrainWidth, terrainHeight];

        for (int x = 0; x < terrainWidth; x++)
        {
            for (int y = 0; y < terrainHeight; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / terrainWidth * scale + offsetX;
        float yCoord = (float)y / terrainHeight * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
