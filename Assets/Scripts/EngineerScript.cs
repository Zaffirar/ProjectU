using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineerScript : MonoBehaviour
{
    public int quest1 = 0;//0 - nic, 1 odmowa, 2 przyjeto, 3 zakonczono
    public int quest2 = 0;
    public float distance;
    public bool dialogueend = true;
    public GameObject theplayer;
    public TMPro.TextMeshProUGUI interacttext;
    DialogueEnable scr;
    void Start()
    {
        scr = gameObject.GetComponent<DialogueEnable>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, theplayer.transform.position);
        if (distance <= 2f && dialogueend)
        {
            interacttext.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueend = false;
                interacttext.enabled = false;
                if (quest1 == 3)
                {
                    if (quest2 == 0)
                    {
                        scr.TriggerDialogue(4);
                    }
                    else
                    {
                        scr.TriggerDialogue(5);
                    }
                }
                else
                {
                    if (quest1 == 0)
                    {
                        scr.TriggerDialogue(0);
                    }
                    if (quest1 == 1)
                    {
                        scr.TriggerDialogue(1);
                    }
                    if (quest1 == 2)
                    {
                        scr.TriggerDialogue(2);
                    }
                    if (quest1 == 3)
                    {
                        scr.TriggerDialogue(3);
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
