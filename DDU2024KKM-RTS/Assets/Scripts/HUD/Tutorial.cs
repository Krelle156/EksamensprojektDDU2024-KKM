using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Turtorial : MonoBehaviour
{
    [SerializeField] private Player player;
    public RectTransform textMeshProUGUI;
    private Transform[] textMeshProUGUIArray = new Transform[4];
    public Transform panel;

    private int tutorialStage = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < textMeshProUGUIArray.Length; i++)
        {
            textMeshProUGUIArray[i] = Instantiate(textMeshProUGUI, panel.position + new Vector3(275f , -35f * (i * 2 + 1)), Quaternion.identity);
            //textMeshProUGUIArray[i].GetComponent<TextMeshProUGUI>().text = "bob";
            textMeshProUGUIArray[i].SetParent(panel, true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch(tutorialStage)
        {
            case 0:
                textMeshProUGUIArray[0].GetComponent<TextMeshProUGUI>().text = "WASD to move camera";
                break;

        }

        if (isMarked() == true)
        {
            //textMeshProUGUIArray[0].GetComponent<TextMeshProUGUI>().text = "WASD to move camera";
            Debug.Log("print");
        }
        Debug.Log(isMarked());
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
