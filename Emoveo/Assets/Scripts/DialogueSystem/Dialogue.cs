using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    
    //minimum 3 lines, maximum - 10
    [TextArea(3, 10)]
    public string[] sentences;
}
