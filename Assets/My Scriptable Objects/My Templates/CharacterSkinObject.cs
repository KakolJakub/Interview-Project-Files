using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterSkinObject : ScriptableObject
{
    public MySpriteSheet head;
    public MySpriteSheet chest;
    public MySpriteSheet leftArm;
    public MySpriteSheet rightArm;
    public MySpriteSheet leftLeg;
    public MySpriteSheet rightLeg;

    public Dictionary<BodyPart, MySpriteSheet> bodySpriteSheets;
    
    
    public MySpriteSheet GetBodySheet(BodyPart bodyPart)
    {
        MySpriteSheet bodySheet;

        switch(bodyPart)
        {
            case BodyPart.Head:
                bodySheet = this.head;
                break;
            case BodyPart.Chest:
                bodySheet = this.chest;
                break;
            case BodyPart.LeftArm:
                bodySheet = this.leftArm;
                break;
            case BodyPart.RightArm:
                bodySheet = this.rightArm;
                break;
            case BodyPart.LeftLeg:
                bodySheet = this.leftLeg;
                break;
            case BodyPart.RightLeg:
                bodySheet = this.rightLeg;
                break;
            default:
                bodySheet = this.head;
                Debug.Log("Wrong BodyPart");
                break;
        }

        return bodySheet;      
    }

    public static void ChangeSkin(CharacterSkinObject skinObject, MySpriteSheet newSkin)
    {
        //BodyPart match = newSkin.BodyPart;
        //skinObject.bodySpriteSheets[match] = newSkin;
        //UpdateSkinObjectSheets(skinObject);

        UpdateSkinForBodyPart(skinObject, newSkin);
        Debug.Log("Skin changed! " + newSkin);
    }

    public static void CopySkin(CharacterSkinObject skinToCopy, CharacterSkinObject oldSkin)
    {
        oldSkin.head = skinToCopy.head;
        oldSkin.chest = skinToCopy.chest;
        oldSkin.leftArm = skinToCopy.leftArm;
        oldSkin.rightArm = skinToCopy.rightArm;
        oldSkin.leftLeg = skinToCopy.leftLeg;
        oldSkin.rightLeg = skinToCopy.rightLeg;
    }
    
    public static void UpdateSkinObjectSheets(CharacterSkinObject skinObject)
    {
        skinObject.head = skinObject.bodySpriteSheets[BodyPart.Head];
        skinObject.chest = skinObject.bodySpriteSheets[BodyPart.Chest];
        skinObject.leftArm = skinObject.bodySpriteSheets[BodyPart.LeftArm];
        skinObject.rightArm = skinObject.bodySpriteSheets[BodyPart.RightArm];
        skinObject.leftLeg = skinObject.bodySpriteSheets[BodyPart.LeftLeg];
        skinObject.rightLeg = skinObject.bodySpriteSheets[BodyPart.RightLeg];
    }

    public static void UpdateSkinForBodyPart(CharacterSkinObject skinObject, MySpriteSheet newSkin)
    {
        BodyPart bodyPart = newSkin.BodyPart;

        switch(bodyPart)
        {
            case BodyPart.Head:
                skinObject.head = newSkin;
                break;
            case BodyPart.Chest:
                skinObject.chest = newSkin;
                break;
            case BodyPart.LeftArm:
                skinObject.leftArm = newSkin;
                break;
            case BodyPart.RightArm:
                skinObject.rightArm = newSkin;
                break;
            case BodyPart.LeftLeg:
                skinObject.leftLeg = newSkin;
                break;
            case BodyPart.RightLeg:
                skinObject.rightLeg = newSkin;
                break;
            default:
                Debug.Log("Wrong BodyPart");
                break;
        }
    }
    
    void SetupDictionary()
    {
        bodySpriteSheets.Add(BodyPart.Head, head);
        bodySpriteSheets.Add(BodyPart.Chest, chest);
        bodySpriteSheets.Add(BodyPart.LeftArm, leftArm);
        bodySpriteSheets.Add(BodyPart.RightArm, rightArm);
        bodySpriteSheets.Add(BodyPart.LeftLeg, leftLeg);
        bodySpriteSheets.Add(BodyPart.RightLeg, rightLeg);
    }

    void Awake()
    {
        if(bodySpriteSheets == null)
        {
            bodySpriteSheets = new Dictionary<BodyPart, MySpriteSheet>();
        }
    }

    void OnEnable()
    {
        if(bodySpriteSheets == null)
        {
            bodySpriteSheets = new Dictionary<BodyPart, MySpriteSheet>();
            SetupDictionary();
            Debug.Log("reset body sheets and added new parts");
        }
        else
        {
            bodySpriteSheets.Clear();
            SetupDictionary();

        Debug.Log("added new parts to body sheets");

        }

       
    }

}
