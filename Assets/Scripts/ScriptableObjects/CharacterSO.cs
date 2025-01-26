using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObject/CharacterScriptableObject")]
public class CharacterSO : ScriptableObject
{
    [Header("Character Properties")]
    public float moveSpeed;

    [Header("Handling Keys")]
    public KeyCode MoveUp;
    public KeyCode MoveLeft;
    public KeyCode MoveDown;
    public KeyCode MoveRight;

    [Header("Animation Sprites")]
    public Sprite[] MoveUpSprites;
    public Sprite[] MoveDownSprites;
    public Sprite[] MoveLeftSprites;
    public Sprite[] MoveRightSprites;
}
