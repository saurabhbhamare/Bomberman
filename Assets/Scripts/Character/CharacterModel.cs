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
    public float moveSpeed;

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
        this.moveSpeed = characterData.moveSpeed;

        this.keyUp = characterData.MoveUp;
        this.keyDown = characterData.MoveDown;
        this.keyLeft = characterData.MoveLeft;
        this.keyRight = characterData.MoveRight;

        this.upMoveSprites = characterData.MoveUpSprites;
        this.downMoveSprites = characterData.MoveDownSprites;
        this.leftMoveSprites = characterData.MoveLeftSprites;
        this.rightMoveSprites = characterData.MoveRightSprites;
    }
    public void SetDirection(Vector2 newDirection)
    {
        this.direction = newDirection;
    }

}
