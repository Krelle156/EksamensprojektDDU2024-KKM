using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    static int width=400, height=200;

    //An attempt to make it possible to read terrainvalues ingame
    public Transform debuggingCanvasReference;
    public static Transform debuggingCanvas;
    public RectTransform debugText;
    Transform[,] terrainDebuggingText;
    bool terrainTextGenerated = false;

    public TileData bob;
    public static TileData [,]terraindata;
    public Tile tile;

    public Tilemap tileMap;

    public SpriteRenderer tree, tempTree;

    Vector3Int position;
    private void Awake()
    {
        debuggingCanvas = debuggingCanvasReference;
    }

    // Start is called before the first frame update
    void Start()
    {
        terrainDebuggingText = new Transform[width, height];
        bob = new TileData();
        terraindata = new TileData[width, height];
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l")) UpdateTerrainText();//if "L" is pressed, show the terrain values around the mouse
    }
    void GenerateMap()
    {
        

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                terraindata[i,j] = new TileData();
                //terraindata[i, j].UpdateTreeValue(i+j);

            }
        }


        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                float temp = Mathf.Min(Mathf.PerlinNoise(100 + i * 0.02f, 1000 + j * 0.02f)*0.7f,0.7f);
                tile.color = new Color(temp, 0.7f, temp);
                tileMap.SetTile(new Vector3Int(i,j,-1), tile);
            }
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                float temp = Mathf.PerlinNoise(100 + i * 0.02f, 1000 + j * 0.02f);

                if(Random.Range(0.15f, 10f)<temp) tempTree = Instantiate(tree, new Vector3(i+0.5f, j+0.5f, -1), Quaternion.identity);
            }
        }

    }

    void UpdateTerrainText()
    {
        //If there is no text objects, generate text objects.
        if(!terrainTextGenerated)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    terrainDebuggingText[i, j] = Instantiate(debugText, new Vector3(i, j,-9), Quaternion.identity);
                    terrainDebuggingText[i, j].GetComponent<Text>().text = "bob";
                    terrainDebuggingText[i, j].SetParent(debuggingCanvas, true);
                    terrainTextGenerated = true;

                }
            }
        }
        //Get the terrain-modifier and
        int tempMouseX = (int)Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        int tempMouseY = (int)Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                terrainDebuggingText[i, j].position = new Vector2(i-6f+tempMouseX, j - 6f + tempMouseY);
                if (i + tempMouseX - 6 >= 0 && j + tempMouseY - 6 >= 0 && i + tempMouseX - 6 < width && j + tempMouseY - 6 < height)
                {
                    terrainDebuggingText[i, j].GetComponent<Text>().text = terraindata[i + tempMouseX - 6, j + tempMouseY - 6].GetTerrainModifier().ToString();
                    Debug.Log(terraindata[i + tempMouseX - 6, j + tempMouseY - 6].GetTerrainModifier());
                }
                else terrainDebuggingText[i, j].GetComponent<Text>().text = "bob";

            }
        }

    }

    public static float getMapWidth()
    {
        return width;
    }
    public static float getMapHeight()
    {
        return height;
    }

}
