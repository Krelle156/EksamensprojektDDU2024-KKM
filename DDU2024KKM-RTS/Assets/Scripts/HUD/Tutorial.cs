using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Turtorial : MonoBehaviour
{
    [SerializeField] private Player player;
    public RectTransform textMeshProUGUI;
    public Transform panel;

    private int tutorialStage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        textMeshProUGUI = Instantiate(textMeshProUGUI, panel.position + new Vector3(275f , -150f), Quaternion.identity);
        //textMeshProUGUIArray[i].GetComponent<TextMeshProUGUI>().text = "bob";
        textMeshProUGUI.SetParent(panel, true);
        

    }

    // Update is called once per frame
    void Update()
    {
        switch(tutorialStage)
        {
            case 0:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "Press W, A, S, or D to move the camera!";
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    tutorialStage = 1;
                }
                break;
            case 1:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "Hold Shift to move faster!";
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    tutorialStage = 2;
                }
                break;
            case 2:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "Scroll the mouse wheel to zoom!";
                if (Input.mouseScrollDelta.y != 0)
                {
                    tutorialStage = 3;
                }
                break;
            case 3:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "Press Space to spawn units!";
                if (Input.GetKey(KeyCode.Space))
                {
                    tutorialStage = 4;
                }
                break;
            case 4:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "Hold The LMB, and drag to mark units!";
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    tutorialStage = 5;
                }
                break;
            case 5:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "Press the RMB to place waypoints!";
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    tutorialStage = 6;
                }
                break;
            case 6:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "If a unit is marked, press the RMB to shoot at enemies, when hovering over them!";
                for (int i = 0; i < player.units.Count; i++)
                {
                    if (player.units[i].target.TryGetComponent(out Unit bob))
                    {
                        if (bob.allegiance != player.units[i].allegiance && bob.allegiance != 0)
                        {
                            tutorialStage = 7;
                            panel.gameObject.SetActive(false);
                            break;
                        }
                    }
                }
                break;
            default:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "";
                break;

        }

        

        

        

        if (isMarked() == true)
        {
            //textMeshProUGUIArray[0].GetComponent<TextMeshProUGUI>().text = "WASD to move camera";
            //Debug.Log("print");
        }
        //Debug.Log(isMarked());
    }

    bool isMarked()
    {
        if (player.units.Count > 0)
        {
            return true;
        }
        return false;
    }
}
