using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform barrack;
    private CameraController controller;
    public Transform mainCamera;
    public Turtorial tutorial;
    // Start is called before the first frame update
    void Start()
    {
        controller = mainCamera.GetComponent<CameraController>();
        barrack = Instantiate(barrack, new Vector3(MapGenerator.getMapWidth() * 0.1f, MapGenerator.getMapHeight() / 2, -1f), Quaternion.identity);
        barrack.GetComponent<Barracks>().allegiance = 1;
        controller.SetCam(barrack.position, -10f);
        tutorial.allyBarracks = barrack.GetComponent<Barracks>();

        barrack = Instantiate(barrack, new Vector3(MapGenerator.getMapWidth() * 0.9f, MapGenerator.getMapHeight() / 2, -1f), Quaternion.identity);
        barrack.GetComponent<Barracks>().allegiance = 2;
        tutorial.enemyBarracks = barrack.GetComponent<Barracks>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
