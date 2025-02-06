using UnityEngine;
public class CharacterModel
{
    private CharacterSO characterData;
    public Vector2 direction;

    //Movement Keys
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;

    public KeyCode placeBomb;
    public int bombs=10;
    public float defaultSpeed;
    public float boostedSpeed;

    public float speedBoostStartTime;
    public float speedBoostDuration;

    public float blastRadiusStartTime;
    public float blastRadiusDuration;

    //public float 





    public bool isSpeedBoostOn;
    public bool isBlastRadiusOn;
    public bool isExtraBombOn;




    //Animation Data
    public Sprite[] upMoveSprites;
    public Sprite[] downMoveSprites;
    public Sprite[] leftMoveSprites;
    public Sprite[] rightMoveSprites;

    public CharacterModel(CharacterSO characterData)
    {
        this.characterData = characterData;
        SetCharacterData(characterData);
    }
    private void SetCharacterData(CharacterSO characterData)
    {
        this.defaultSpeed = characterData.DefaultSpeed;
        this.boostedSpeed = characterData.BoostedSpeed;




        this.speedBoostDuration = characterData.SpeedBoostDuration;
        this.blastRadiusDuration = 15f;

        this.keyUp = characterData.MoveUp;
        this.keyDown = characterData.MoveDown;
        this.keyLeft = characterData.MoveLeft;
        this.keyRight = characterData.MoveRight;
        this.placeBomb = characterData.PlaceBomb;

        this.upMoveSprites = characterData.MoveUpSprites;
        this.downMoveSprites = characterData.MoveDownSprites;
        this.leftMoveSprites = characterData.MoveLeftSprites;
        this.rightMoveSprites = characterData.MoveRightSprites;
        this.isSpeedBoostOn = false;
        this.isBlastRadiusOn = false;
    }
    public void SetDirection(Vector2 newDirection)
    {
        this.direction = newDirection;
    }

}
