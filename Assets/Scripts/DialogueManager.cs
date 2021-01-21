using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI dialogueText;
    public GameObject box;
    public GameObject thisone;

    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    public void StartDialogue(Dialogue dialogue, int number, GameObject act)
    {
        thisone = act;
        //Debug.Log(act);
        sentences.Clear();
        //Debug.Log(dialogue.name);

        box.SetActive(true);
        nameText.text = dialogue.name;
        string[] sent = dialogue.sentences0;
        switch(number)
        {
            case 0:
                sent = dialogue.sentences0;
                break;
            case 1:
                sent = dialogue.sentences1;
                break;
            case 2:
                sent = dialogue.sentences2;
                break;
            case 3:
                sent = dialogue.sentences3;
                break;
            case 4:
                sent = dialogue.sentences4;
                break;
            case 5:
                sent = dialogue.sentences5;
                break;
        }
        foreach(string sentence in sent)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        //Debug.Log(thisone);
        box.SetActive(false);
        EngineerScript end = thisone.GetComponent<EngineerScript>();
        QuestGiver qst = thisone.GetComponent<QuestGiver>();
        if(end.quest1 == 0 || end.quest1 == 2)
            qst.OpenQuestWindow();
        //end.dialogueend = true;
    }
}
