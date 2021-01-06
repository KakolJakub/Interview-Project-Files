using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPart
{
    Head,
    Chest,
    LeftArm,
    RightArm,
    LeftLeg,
    RightLeg   
}

[System.Serializable]
public class MySpriteSheet
{
    public Dictionary<Direction, Sprite> directionSprites;

    public BodyPart BodyPart { get {return bodyPart;} }
    [SerializeField] BodyPart bodyPart;

    [SerializeField] Sprite leftSprite;
    [SerializeField] Sprite rightSprite;
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    public MySpriteSheet(MySpriteSheet copiedSheet)
    {
        leftSprite = copiedSheet.leftSprite;
        rightSprite = copiedSheet.rightSprite;
        frontSprite = copiedSheet.frontSprite;
        backSprite = copiedSheet.backSprite;
    }

    public void ClearAndUpdateSheetDictionary()
    {
        directionSprites = new Dictionary<Direction, Sprite>();
        ClearSheetDictionary();
        UpdateSheetDictionary();
    }

    public void UpdateSheetDictionary()
    {
        directionSprites.Add(Direction.Left, leftSprite);
        directionSprites.Add(Direction.Right, rightSprite);
        directionSprites.Add(Direction.Up, backSprite);
        directionSprites.Add(Direction.Down, frontSprite);
    }

    public void ClearSheetDictionary()
    {
        directionSprites.Clear();
    }
    
    void OnEnable()
    {
        if(directionSprites == null)
        {
            directionSprites = new Dictionary<Direction, Sprite>();
            UpdateSheetDictionary();
            Debug.Log("reset direction sheets and added new parts");
        }
        else
        {
            directionSprites.Clear();
            UpdateSheetDictionary();
            
            Debug.Log("added new parts to direction sheets");

        }
    }
}
