using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float cameraBaseSpeed = 10;
    float cameraMoveSpeed = 10;

    public Mobile playerUnit;
    // Start is called before the first frame update
    void Start()
    {
        cameraMoveSpeed = cameraBaseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) cameraMoveSpeed = cameraBaseSpeed * 3;
        if (Input.GetKeyUp(KeyCode.LeftShift)) cameraMoveSpeed = cameraBaseSpeed;


        Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize-Input.mouseScrollDelta.y,3);
        transform.position = Vector3.Lerp(transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition), Input.mouseScrollDelta.y*0.1f);


        if (Input.GetKey("w")) transform.position += new Vector3(0, cameraMoveSpeed*Time.deltaTime, 0);
        if (Input.GetKey("s")) transform.position += new Vector3(0, -cameraMoveSpeed * Time.deltaTime, 0);
        if (Input.GetKey("a")) transform.position += new Vector3(-cameraMoveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey("d")) transform.position += new Vector3(cameraMoveSpeed * Time.deltaTime, 0, 0);
    }
}
