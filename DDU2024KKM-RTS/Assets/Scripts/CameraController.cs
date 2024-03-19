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
        //Moves the camera faster if shift is held down
        if(Input.GetKeyDown(KeyCode.LeftShift)) cameraMoveSpeed = cameraBaseSpeed * 3;
        if (Input.GetKeyUp(KeyCode.LeftShift)) cameraMoveSpeed = cameraBaseSpeed;

        //To control "zoom" through the arrow buttons
        if(Input.GetKey(KeyCode.UpArrow)) Camera.main.orthographicSize -= 1f * Time.deltaTime;
        if(Input.GetKey(KeyCode.DownArrow)) Camera.main.orthographicSize -= 1f * Time.deltaTime;

        //To control "zoom" through the scrollwheel
        Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize-Input.mouseScrollDelta.y,3);
        transform.position = Vector3.Lerp(transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition), Input.mouseScrollDelta.y*0.1f);

        //Movement keys (Incompatible with controllable units, should either be toggleable, changeable or the camera should be a "Unit", the player "controls")
        //(The above however *is* compatible with controllable units)
        if (Input.GetKey("w")) transform.position += new Vector3(0, cameraMoveSpeed*Time.deltaTime, 0);
        if (Input.GetKey("s")) transform.position += new Vector3(0, -cameraMoveSpeed * Time.deltaTime, 0);
        if (Input.GetKey("a")) transform.position += new Vector3(-cameraMoveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey("d")) transform.position += new Vector3(cameraMoveSpeed * Time.deltaTime, 0, 0);
    }
}
