using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    private static int width = 100, height;

    //References to enable the debugging text for terrain values
    public Transform debuggingCanvas; //Reference to the canvas
    public RectTransform debugText; //Template for generating text
    Transform[,] terrainDebuggingText; //The actual text
    bool terrainTextGenerated = false;



    public static TileData [,]terraindata; //Grid of information relating to tiles

    public Tile tile; //Template for Unity's tileMap
    public Tilemap tileMap; //The tileMap in the scene

    public SpriteRenderer tree, tempTree;

    Vector3Int position;



    private void Awake()
    {
        int temp = (int) (width * 9f / 16f);
        height = temp;
    }

    void Start()
    {
        terrainDebuggingText = new Transform[width, height];
        terraindata = new TileData[width, height];
        GenerateMap();
    }

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

        float tempX = Random.Range(-100, 100);
        float tempY = Random.Range(-100, 100);
        double scaleFactor = 0.02;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                //83, 30 works
                float temp = Mathf.Min(Mathf.PerlinNoise((83 + i * (float) scaleFactor), (30 + j * (float) scaleFactor)), 0.7f);
                tile.color = new Color(temp, 0.7f, temp);
                tileMap.SetTile(new Vector3Int(i, j, -1), tile);
            }
        }
        //Debug.Log(tempX + "; " + tempY);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                float temp = Mathf.PerlinNoise(tempX + i * 0.02f, tempY + j * 0.02f);

                if(Random.Range(0.3f, 10f)<temp) tempTree = Instantiate(tree, new Vector3(i+0.5f, j+0.5f, 0.9f), Quaternion.identity);
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
                    terrainDebuggingText[i, j].GetComponent<TextMeshProUGUI>().text = "bob";
                    terrainDebuggingText[i, j].SetParent(debuggingCanvas, true);
                    terrainTextGenerated = true;

                }
            }
        }
        //Temp mouse veriables for slightly more readability
        int tempMouseX = (int)Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        int tempMouseY = (int)Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                terrainDebuggingText[i, j].position = new Vector2(i-5f+tempMouseX, j - 6f + tempMouseY);
                if (i + tempMouseX - 6 >= 0 && j + tempMouseY - 6 >= 0 && i + tempMouseX - 6 < width && j + tempMouseY - 6 < height)
                {
                    terrainDebuggingText[i, j].GetComponent<TextMeshProUGUI>().text = terraindata[i + tempMouseX - 6, j + tempMouseY - 6].GetTerrainModifier().ToString();
                    //Debug.Log(terraindata[i + tempMouseX - 6, j + tempMouseY - 6].GetTerrainModifier());
                }
                else terrainDebuggingText[i, j].GetComponent<TextMeshProUGUI>().text = "bob";

            }
        }

    }

    //As the dimensions of the map should'nt be changed from the outside there are only getter-functions
    public static int getMapWidth() 
    {
        return width;
    }
    public static int getMapHeight()
    {
        return height;
    }

}
