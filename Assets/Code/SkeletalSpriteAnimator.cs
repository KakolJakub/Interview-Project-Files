using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletalSpriteAnimator : MonoBehaviour
{
    [SerializeField] CharacterSkinObject currentSkin;
    [SerializeField] PlayerMovement movementScript;
    [SerializeField] Direction currentDirection;

    [SerializeField] Transform head;
    [SerializeField] Transform chest;
    [SerializeField] Transform leftArm;
    [SerializeField] Transform rightArm;
    [SerializeField] Transform leftLeg;
    [SerializeField] Transform rightLeg;

    MySpriteSheet headSpriteSheet;
    MySpriteSheet chestSpriteSheet;
    MySpriteSheet leftArmSpriteSheet;
    MySpriteSheet rightArmSpriteSheet;
    MySpriteSheet leftLegSpriteSheet;
    MySpriteSheet rightLegSpriteSheet;

    SpriteRenderer headSprite;
    SpriteRenderer chestSprite;
    SpriteRenderer leftArmSprite;
    SpriteRenderer rightArmSprite;
    SpriteRenderer leftLegSprite;
    SpriteRenderer rightLegSprite;

    void Start()
    {
        ClearSpriteSheets();

        headSprite = head.GetComponent<SpriteRenderer>();
        chestSprite = chest.GetComponent<SpriteRenderer>();
        leftArmSprite = leftArm.GetComponent<SpriteRenderer>();
        rightArmSprite = rightArm.GetComponent<SpriteRenderer>();
        leftLegSprite = leftLeg.GetComponent<SpriteRenderer>();
        rightLegSprite = rightLeg.GetComponent<SpriteRenderer>();

        UpdateSprites();
    }
    
    void Update()
    {
        GetPlayerDirection();
    }

    public void UpdateSheets()
    {
        headSpriteSheet = currentSkin.head;
        chestSpriteSheet = currentSkin.chest;
        leftArmSpriteSheet = currentSkin.leftArm;
        rightArmSpriteSheet = currentSkin.rightArm;
        leftLegSpriteSheet = currentSkin.leftLeg;
        rightLegSpriteSheet = currentSkin.rightLeg;
        UpdateSheetDictionaries();
    }

    public void UpdateSprites() 
    {
        //headSprite = headSpriteSheet.Item[currentDirection];
        UpdateSheets();
        headSprite.sprite = headSpriteSheet.directionSprites[currentDirection];
        chestSprite.sprite = chestSpriteSheet.directionSprites[currentDirection];
        leftArmSprite.sprite = leftArmSpriteSheet.directionSprites[currentDirection];
        rightArmSprite.sprite = rightArmSpriteSheet.directionSprites[currentDirection];
        leftLegSprite.sprite = leftLegSpriteSheet.directionSprites[currentDirection];
        rightLegSprite.sprite = rightLegSpriteSheet.directionSprites[currentDirection];
        
        //headSprite = headSpriteSheet.Dictionary<Direction, Sprite>
    }

    void UpdateSheetDictionaries()
    {
        headSpriteSheet.ClearAndUpdateSheetDictionary();
        chestSpriteSheet.ClearAndUpdateSheetDictionary();
        leftArmSpriteSheet.ClearAndUpdateSheetDictionary();
        rightArmSpriteSheet.ClearAndUpdateSheetDictionary();
        leftLegSpriteSheet.ClearAndUpdateSheetDictionary();
        rightLegSpriteSheet.ClearAndUpdateSheetDictionary();
    }

    void ClearSpriteSheets()
    {
        headSpriteSheet = null;
        chestSpriteSheet = null;
        leftArmSpriteSheet = null;
        rightArmSpriteSheet = null;
        leftLegSpriteSheet = null;
        rightLegSpriteSheet = null;
    }

    void GetPlayerDirection()
    {
        if(movementScript.PlayerDirection != currentDirection)
        {
            currentDirection = movementScript.PlayerDirection;
            UpdateSprites();
            Debug.Log("Checking");
        }
    }
}
