    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3,10)]
    public string[] sentences0;
    [TextArea(3, 10)]
    public string[] sentences1;
    [TextArea(3, 10)]
    public string[] sentences2;
    [TextArea(3, 10)]
    public string[] sentences3;
    [TextArea(3, 10)]
    public string[] sentences4;
    [TextArea(3, 10)]
    public string[] sentences5;

}
