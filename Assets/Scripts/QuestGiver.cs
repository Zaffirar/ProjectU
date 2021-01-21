using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{   
    private int thisquest1;
    private int thisquest2;
    public QuestScript quest;
    public EngineerScript eng;
    public Player player;
    public TMPro.TextMeshProUGUI titleText;
    public TMPro.TextMeshProUGUI descriptionText;
    public GameObject questwindow;
    //public GameObject thisone;

    public void Start()
    {

    }
    public void OpenQuestWindow()
    {
        questwindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
    }
    public void CloseQuestWIndow()
    {

        //quest.isActive = true;
        questwindow.SetActive(false);
        GameObject origin = eng.gameObject;
        EngineerScript end = origin.GetComponent<EngineerScript>();
        Debug.Log(gameObject);
        end.dialogueend = true;
    }
}
