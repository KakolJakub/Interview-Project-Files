using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogueElement
{
    [TextArea(5,5)]
    public string characterLine;

    public DialogueResponse firstPlayerOption;
    public DialogueResponse secondPlayerOption;
}

[System.Serializable]
public class DialogueResponse
{
    public string text;

    public bool isPositive;

    public UnityEvent interaction;
}
