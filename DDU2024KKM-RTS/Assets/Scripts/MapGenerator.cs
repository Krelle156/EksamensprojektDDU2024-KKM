using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{

    public Tile tile;

    public Tilemap tileMap;

    public SpriteRenderer tree;

    Vector3Int position;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateMap()
    {
        for (int i = -200; i < 200; i++)
        {
            for (int j = -100; j < 100; j++)
            {
                float temp = Mathf.Min(Mathf.PerlinNoise(100 + i * 0.02f, 1000 + j * 0.02f)*0.7f,0.7f);
                tile.color = new Color(temp, 0.7f, temp);
                tileMap.SetTile(new Vector3Int(i,j,-1), tile);
            }
        }

        for (int i = -200; i < 200; i++)
        {
            for (int j = -100; j < 100; j++)
            {
                float temp = Mathf.PerlinNoise(100 + i * 0.02f, 1000 + j * 0.02f);

                if(Random.Range(0.15f, 10f)<temp) Instantiate(tree, new Vector3(i+0.5f, j+0.5f, -1), Quaternion.identity);
            }
        }

    }
}
