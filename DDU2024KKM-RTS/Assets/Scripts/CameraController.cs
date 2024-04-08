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

    [SerializeField] protected ExplosionEffect testExplosion;
    public static ExplosionEffect boomTempTest; //must be moved to particle controller later

    public Transform spawnerOfThings;
    private Barracks barracks;

    private void Awake()
    {
        boomTempTest = Instantiate(testExplosion, transform.position, Quaternion.identity);
    }
    void Start()
    {
        cameraMoveSpeed = cameraBaseSpeed;
        //testGuyReference = Instantiate(testGuy, transform.position-new Vector3(0,0,-9), Quaternion.identity);
        //playerUnit = testGuyReference;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) cameraMoveSpeed = cameraBaseSpeed * 2;
        if (Input.GetKeyUp(KeyCode.LeftShift)) cameraMoveSpeed = cameraBaseSpeed;


        Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize-Input.mouseScrollDelta.y,3);
        transform.position = Vector3.Lerp(transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition), Input.mouseScrollDelta.y*0.1f);


        if (Input.GetKey(KeyCode.W) && isControllingUnit == false) transform.position += new Vector3(0, cameraMoveSpeed*Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.S) && isControllingUnit == false) transform.position += new Vector3(0, -cameraMoveSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.A) && isControllingUnit == false) transform.position += new Vector3(-cameraMoveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D) && isControllingUnit == false) transform.position += new Vector3(cameraMoveSpeed * Time.deltaTime, 0, 0);

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

    public void SetCam(Vector2 start, float bob) { 
        transform.position = new Vector3(start.x, start.y, bob);
    }
}
