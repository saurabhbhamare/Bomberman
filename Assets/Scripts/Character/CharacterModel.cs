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
    }
    public void SetDirection(Vector2 newDirection)
    {
        this.direction = newDirection;
    }

}
