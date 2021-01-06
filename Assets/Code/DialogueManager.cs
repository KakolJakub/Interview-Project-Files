using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameSlot;
    [SerializeField] TextMeshProUGUI textSlot;

    [SerializeField] GameObject dialogueBox;

    [SerializeField] string generalPlayerName;

    [SerializeField] int decayTime;

    DialogueResponse currentPositiveResponse;
    DialogueResponse currentNegativeResponse;

    public void EnableMenu(bool isEnabled, bool clearDialogueBox = false)
    {
        dialogueBox.SetActive(isEnabled);

        if(clearDialogueBox)
        {
            ClearBox();
        }

        CancelInvoke();
    }

    public void TestDialogue(string name, string lines)
    {
        EnableMenu(true, true);
        nameSlot.text = name;
        textSlot.text = lines;
    }

    public void LoadDialogueElement(DialogueElement element, string name)
    {
        EnableMenu(true);
        StartCoroutine(LoadingDialogueElement(element, name));
    }

    public void LoadDialogueElement(DialogueElement element, string name, bool clearBox)
    {
        EnableMenu(true, clearBox);
        StartCoroutine(LoadingDialogueElement(element, name));
    }

    public void LoadJoke(string setUp, string punchLine, string name, int time = 4)
    {
        //tbd
    }

    //played via button
    public void PlayResponse(bool isPositive)
    {
        EnableMenu(true);
        nameSlot.text = generalPlayerName;

        if(isPositive)
        {
            if(currentPositiveResponse != null)
            {
                textSlot.text = currentPositiveResponse.text;
                
                StartCoroutine(PlayingInteraction(currentPositiveResponse));
                
                currentPositiveResponse = null;
            }
            else
            {
                EnableMenu(false, true);
                Debug.Log("the end1");
            }
            
        }
        else
        {
            if(currentNegativeResponse != null)
            {
                textSlot.text = currentNegativeResponse.text;
                
                StartCoroutine(PlayingInteraction(currentNegativeResponse));
                    
                Invoke("DisableMenu", decayTime);
                
                currentNegativeResponse = null;
            }
            else
            {
                EnableMenu(false, true);
                Debug.Log("the end2");
            }

        }
    }

    IEnumerator LoadingDialogueElement(DialogueElement element, string name)    
    {
        yield return new WaitForSecondsRealtime(decayTime);

        nameSlot.text = name;
        textSlot.text = element.characterLine;

        AdjustResponse(element);
    }

    IEnumerator PlayingInteraction(DialogueResponse response)
    {
        if(response.interaction != null)
        {
            yield return new WaitForSecondsRealtime(decayTime);
            response.interaction.Invoke();
        }
    }

    void AdjustResponse(DialogueElement element)
    {
        if(element.firstPlayerOption.isPositive)
        {
            currentPositiveResponse = element.firstPlayerOption;
        }
        else if(element.secondPlayerOption.isPositive)
        {
            currentPositiveResponse = element.secondPlayerOption;
        }
        
        if(!element.firstPlayerOption.isPositive)
        {
            currentNegativeResponse = element.firstPlayerOption;
        }
        else if(!element.secondPlayerOption.isPositive)
        {
            currentNegativeResponse = element.secondPlayerOption;
        }
    }

    void ClearBox()
    {
        nameSlot.text = string.Empty;
        textSlot.text = string.Empty;
    }

    void DisableMenu()
    {
        dialogueBox.SetActive(false);
    }

    void Start()
    {
        EnableMenu(false);
    }

}
