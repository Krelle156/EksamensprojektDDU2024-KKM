using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Turtorial : MonoBehaviour
{
    [SerializeField] private Player player;
    public RectTransform textMeshProUGUI, unitCounter;
    public Transform panel;
    public Transform canvas;

    public List<Unit> enemyList;
    public Barracks enemyBarracks, allyBarracks;
    //Kommentar!

    private int tutorialStage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        textMeshProUGUI = Instantiate(textMeshProUGUI, panel.position + new Vector3(15f , -10f), Quaternion.identity);
        unitCounter = Instantiate(textMeshProUGUI, panel.position + new Vector3(15f, -300f * canvas.GetComponent<RectTransform>().localScale.y), Quaternion.identity);
        textMeshProUGUI.localScale = canvas.GetComponent<RectTransform>().localScale;
        unitCounter.localScale = canvas.GetComponent<RectTransform>().localScale;

        textMeshProUGUI.SetParent(panel, true);
        unitCounter.SetParent(panel, true);
        enemyBarracks.spawnEnemies(40, enemyList);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialStage >= 3) unitCounter.GetComponent<TextMeshProUGUI>().text = "Active footsoldiers: " + Barracks.GetNumberOfAllies() + "/20";
        switch (tutorialStage)
        {
            case 0:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "Press W, A, S, or D to move the camera!";
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    tutorialStage = 1;
                }
                break;
            case 1:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "Hold Shift to move the camera faster!";
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
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "Press Space to spawn units! High command will only allow 20 units on the battlefield at once!";
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
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "Press the RMB to place waypoints! There enemies are to the right! ->";
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    tutorialStage = 6;
                }
                break;
            case 6:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "If a unit is marked, press the RMB to shoot at enemies, when hovering over them! There enemies are to the right! ->";
                for (int i = 0; i < player.units.Count; i++)
                {
                    if (player.units[i].target != null)
                    {
                        if (player.units[i].target.TryGetComponent(out Unit bob))
                        {
                            if (bob.allegiance != player.units[i].allegiance && bob.allegiance != 0)
                            {
                                tutorialStage = 7;
                                break;
                            }
                        }
                    }
                }
                break;
            case 7:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "Eleminate the enemies (Hint: hiding in trees reduce enemy accuracy) Enemise left:" + enemyList.Count;
                if (enemyList.Count == 0)
                {
                    tutorialStage = 8;
                    enemyBarracks.spawnEnemies(100, enemyList, allyBarracks.transform.position);
                    allyBarracks.spawnTonk();
                    break;
                }
                else enemyList.RemoveAll(y => y == null);
                break;
            case 8:
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "Oh no! They are responding in force!!! luckily high command has sent you a tonk, blow them all to smithereens!!!!!";
                
                if (enemyList.Count == 0)
                {
                    tutorialStage = 9;
                    break;
                }
                else enemyList.RemoveAll(y => y == null);
                break;
            case 9:
                int scaleX = 3; int scaleY = 3;
                panel.transform.localScale = new Vector2(panel.transform.localScale.x * scaleX, panel.transform.localScale.y * scaleY);
                panel.transform.position = new Vector2((Screen.width / 2) - (800f * canvas.GetComponent<RectTransform>().localScale.x * scaleX / 2), (Screen.height / 2) + (400f * canvas.GetComponent<RectTransform>().localScale.y * scaleY / 2));
                textMeshProUGUI.GetComponent<TextMeshProUGUI>().text = "You won the battle! High command is pleased! Unfortunately you have been dishonorably discharged, by the infallible supreme leader of our glorious Democratic Peoples Republic of People (Democratic), fearing a military coup!";
                tutorialStage = 10;
                break;
            default:
                unitCounter.GetComponent<TextMeshProUGUI>().text = "Casualties: " + Mobile.casualties;
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
