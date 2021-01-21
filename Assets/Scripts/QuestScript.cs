using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestScript
{
    public bool isActive;
    [TextArea(3, 10)]
    public string title;
    [TextArea(3, 10)]
    public string description;

    

}
