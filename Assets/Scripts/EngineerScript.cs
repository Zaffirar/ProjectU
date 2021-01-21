using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineerScript : MonoBehaviour
{
    public int quest1 = 0;//0 - nic, 1 odmowa, 2 przyjeto, 3 zakonczono
    public int quest2 = 0;
    public float distance;
    public bool dialogueend = true;
    public GameObject theplayer;
    public TMPro.TextMeshProUGUI interacttext;
    public QuestScript act;
    DialogueEnable scr;
    public Button accept;
    public Button sayno;
    QuestGiver qst;
    void Start()
    {
        scr = gameObject.GetComponent<DialogueEnable>();
        Button acc = accept.GetComponent<Button>();
        Button sno = sayno.GetComponent<Button>();
        acc.onClick.AddListener(AccOnClick);
        sno.onClick.AddListener(SnoOnClick);
        qst = gameObject.GetComponent<QuestGiver>();
    }
    void AccOnClick()
    {
        if (quest1 == 0)
        {
            quest1 = 1;
        }
        else
        {
            if (quest1 == 2)
            {
                quest1 = 1;
            }
            if (quest1 == 3)
            {
                quest2 = 1;
            }
        }
        qst.CloseQuestWIndow();
    }
    void SnoOnClick()
    {
        if (quest1 == 0)
        {
            quest1 = 2;
        }
        else
        {
            if (quest1 == 3)
            {
                quest2 = 1;
            }
        }
        qst.CloseQuestWIndow();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, theplayer.transform.position);
        if (distance <= 2f && dialogueend && act.isActive == false)
        {
            //Debug.Log(gameObject.name);
            interacttext.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueend = false;
                interacttext.enabled = false;
                if (quest1 == 3)
                {
                    if (quest2 == 0)
                    {
                        scr.TriggerDialogue(4,gameObject);
                    }
                    else
                    {
                        scr.TriggerDialogue(5,gameObject);
                    }
                }
                else
                {
                    if (quest1 == 0)
                    {
                        scr.TriggerDialogue(0,gameObject);
                    }
                    if (quest1 == 1)
                    {
                        scr.TriggerDialogue(1,gameObject);
                    }
                    if (quest1 == 2)
                    {
                        scr.TriggerDialogue(2,gameObject);
                    }
                    if (quest1 == 3)
                    {
                        scr.TriggerDialogue(3,gameObject);
                    } 
                }
            }
        }         
        if (distance > 2f)
        {
            interacttext.enabled = false;
        }
    }
}
