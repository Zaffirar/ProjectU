using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEnable : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(int dialogue_number)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue,dialogue_number);
    }
}
