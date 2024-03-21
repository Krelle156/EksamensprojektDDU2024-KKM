using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float cameraBaseSpeed = 10;
    float cameraMoveSpeed = 10;

    [SerializeField] protected Infantry testGuy;
    public static Infantry testGuyReference;

    public Mobile playerUnit;
    bool isControllingUnit = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraMoveSpeed = cameraBaseSpeed;
        //testGuyReference = Instantiate(testGuy, transform.position-new Vector3(0,0,-9), Quaternion.identity);
        //playerUnit = testGuyReference;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) cameraMoveSpeed = cameraBaseSpeed * 3;
        if (Input.GetKeyUp(KeyCode.LeftShift)) cameraMoveSpeed = cameraBaseSpeed;


        Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize-Input.mouseScrollDelta.y,3);
        transform.position = Vector3.Lerp(transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition), Input.mouseScrollDelta.y*0.1f);


        if (Input.GetKey("w") && isControllingUnit == false) transform.position += new Vector3(0, cameraMoveSpeed*Time.deltaTime, 0);
        if (Input.GetKey("s") && isControllingUnit == false) transform.position += new Vector3(0, -cameraMoveSpeed * Time.deltaTime, 0);
        if (Input.GetKey("a") && isControllingUnit == false) transform.position += new Vector3(-cameraMoveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey("d") && isControllingUnit == false) transform.position += new Vector3(cameraMoveSpeed * Time.deltaTime, 0, 0);

        if(isControllingUnit == false && Input.GetKey("u"))
        {
            isControllingUnit = true;
            Debug.Log("stops controlling the camera");
        } else if(isControllingUnit == true && Input.GetKey("u"))
        {
            isControllingUnit = false;
            Debug.Log("starts controlling the camera");
        }
    }
}
