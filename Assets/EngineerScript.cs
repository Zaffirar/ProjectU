using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineerScript : MonoBehaviour
{
    public int quest1done = 0;
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
        if(quest1done == 0 && distance <= 2f && dialogueend)
        {
            interacttext.enabled = true;
            if(Input.GetKeyDown(KeyCode.E))
            {
                dialogueend = false;
                interacttext.enabled = false;
                scr.TriggerDialogue();
            }
        }
        if(quest1done == 1 && distance <= 2f)
        {

        }
        if(distance > 2f)
        {
            interacttext.enabled = false;
        }
    }
}
