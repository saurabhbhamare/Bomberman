using UnityEngine;
public class CharacterModel
{
    // Character Data
    private CharacterSO characterData;
    public CharacterType characterType;
    public Vector2 direction;
    // Handling Keys
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;
    public KeyCode placeBomb;
    // Properties
    public int currentBombs;
    public int maxBombs;
    public float defaultSpeed;
    public float boostedSpeed;

    public float bombRefillInterval;
    public float lastBombRefillTime;

    public float speedBoostStartTime;
    public float speedBoostDuration;

    public float blastRadiusStartTime;
    public float blastRadiusDuration;

    public bool isSpeedBoostOn;
    public bool isBlastRadiusOn;
    public bool isExtraBombOn;

    // Animation Data
    public int maxDirMovementFrames;
    public int idleMoveSpriteNumber;
    public float animationFrameRate;
    public float idleTimer;
    public float idleDelay;

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
        // Handling Keys
        this.keyUp = characterData.MoveUp;
        this.keyDown = characterData.MoveDown;
        this.keyLeft = characterData.MoveLeft;
        this.keyRight = characterData.MoveRight;
        this.placeBomb = characterData.PlaceBomb;
        // Animation Data
        this.upMoveSprites = characterData.MoveUpSprites;
        this.downMoveSprites = characterData.MoveDownSprites;
        this.leftMoveSprites = characterData.MoveLeftSprites;
        this.rightMoveSprites = characterData.MoveRightSprites;
        maxDirMovementFrames = characterData.MaxDirMovementFrames;
        idleMoveSpriteNumber = characterData.IdleMoveSpriteNumber;
        animationFrameRate = characterData.AnimationFrameRate;
        // Properties
        this.defaultSpeed = characterData.DefaultSpeed;
        this.boostedSpeed = characterData.BoostedSpeed;
        this.characterType = characterData.CharacterType;
        this.speedBoostDuration = characterData.SpeedBoostDuration;
        this.blastRadiusDuration = characterData.BlastRadiusDuration;
        this.bombRefillInterval = characterData.BombRefillInterval;
        this.currentBombs = 1;
        this.maxBombs = characterData.MaxBombs;
        this.isSpeedBoostOn = false;
        this.isBlastRadiusOn = false;
    }
    public void SetDirection(Vector2 newDirection)
    {
        this.direction = newDirection;
    }
}
