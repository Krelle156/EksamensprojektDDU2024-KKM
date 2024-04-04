using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform barrack;
    private CameraController controller;
    public Transform mainCamera;
    // Start is called before the first frame update
    void Awake()
    {
        controller = mainCamera.GetComponent<CameraController>();
        barrack = Instantiate(barrack, new Vector3(10f, 25f, -1f), Quaternion.identity);
        barrack.GetComponent<Barracks>().allegiance = 1;
        controller.SetCam(barrack.position, -10f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
