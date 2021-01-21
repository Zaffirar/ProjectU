using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineerScript : MonoBehaviour
{
    public int quest1 = 0;//0 - nic, 1 odmowa, 2 przyjeto, 3 zakonczono
    public int quest2 = 0;
    public float distance;
    public bool dialogueend;
    public GameObject theplayer;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject current;
    public TMPro.TextMeshProUGUI interacttext;
    public QuestScript act;
    DialogueEnable scr;
    public Button accept;
    public Button sayno;
    QuestGiver qst;
    void Start()
    {
        dialogueend = true;
        Button acc = accept.GetComponent<Button>();
        Button sno = sayno.GetComponent<Button>();
        acc.onClick.AddListener(AccOnClick);
        sno.onClick.AddListener(SnoOnClick);
        qst = gameObject.GetComponent<QuestGiver>();
    }
    void AccOnClick()
    {
        EngineerScript k = current.GetComponent<EngineerScript>();
        if (k.quest1 == 0)
        {
            k.quest1 = 1;
        }
        else
        {
            if (k.quest1 == 2)
            {
                k.quest1 = 1;
            }
            if (k.quest1 == 3)
            {
                k.quest2 = 1;
            }
        }
        qst.CloseQuestWIndow();
    }
    void SnoOnClick()
    {
        EngineerScript k = current.GetComponent<EngineerScript>();
        if (k.quest1 == 0)
        {
            k.quest1 = 2;
        }
        else
        {
            if (k.quest1 == 3)
            {
                k.quest2 = 1;
            }
        }
        qst.CloseQuestWIndow();
    }

    // Update is called once per frame
    void Update()
    {
        float dist1 = Vector3.Distance(p1.transform.position, theplayer.transform.position);
        float dist2 = Vector3.Distance(p2.transform.position, theplayer.transform.position);
        float dist3 = Vector3.Distance(p3.transform.position, theplayer.transform.position);
        float quickdist = Mathf.Min(dist1, Mathf.Min(dist2, dist3));
        if (quickdist == dist1)
        {
            current = p1;
        }
        else
        {
            if (quickdist == dist2)
            { 
                current = p2;
            }
            else
            {
                if (quickdist == dist3)
                    current = p3;
            }
        }
        //Debug.Log(quickdist);
        //Debug.Log(current.name);
        distance = Vector3.Distance(current.transform.position, theplayer.transform.position);
        EngineerScript k = current.GetComponent<EngineerScript>();
        scr = current.GetComponent<DialogueEnable>();
        //Debug.Log(quickdist);
        if (quickdist <= 2f && k.dialogueend && k.act.isActive == false)
        {
            //Debug.Log(gameObject.name);
            k.interacttext.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                k.dialogueend = false;
                k.interacttext.enabled = false;
                if (k.quest1 == 3)
                {
                    if (k.quest2 == 0)
                    {
                        scr.TriggerDialogue(4,current);
                    }
                    else
                    {
                        scr.TriggerDialogue(5,current);
                    }
                }
                else
                {
                    if (k.quest1 == 0)
                    {
                        scr.TriggerDialogue(0,current);
                    }
                    if (k.quest1 == 1)
                    {
                        scr.TriggerDialogue(1,current);
                    }
                    if (k.quest1 == 2)
                    {
                        scr.TriggerDialogue(2,current);
                    }
                    if (k.quest1 == 3)
                    {
                        scr.TriggerDialogue(3,current);
                    } 
                }
            }
        }         
        if (distance > 2f)
        {
            k.interacttext.enabled = false;
        }
    }
}
