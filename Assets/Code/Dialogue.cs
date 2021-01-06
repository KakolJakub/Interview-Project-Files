using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] string characterName;

    [SerializeField] DialogueElement firstInteraction;
    [SerializeField] DialogueElement tradeInteraction;

    [TextArea(5,5)]
    [SerializeField] string jokeSetUp;
   
    [TextArea(5,5)]
    [SerializeField] string jokePunchLine;

    [SerializeField] DialogueManager dm;

    public void InteractWithManager()
    {
        dm.TestDialogue(characterName, firstInteraction.characterLine);
    }

    public void Talk()
    {
        dm.LoadDialogueElement(firstInteraction, characterName, true);
    }

    public void Trade()
    {
        dm.LoadDialogueElement(tradeInteraction, characterName);
    }

    public void TellJoke()
    {
        dm.LoadJoke(jokeSetUp, jokePunchLine, characterName);
    }

    
}
