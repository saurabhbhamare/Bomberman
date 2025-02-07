using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObject/CharacterScriptableObject")]
public class CharacterSO : ScriptableObject
{
    [Header("Character Properties")]
    public CharacterType CharacterType;
    public float DefaultSpeed;
    public float BoostedSpeed;
    public int MaxBombs;

    public float SpeedBoostDuration;

    [Header("Handling Keys")]
    public KeyCode MoveUp;
    public KeyCode MoveLeft;
    public KeyCode MoveDown;
    public KeyCode MoveRight;

    public KeyCode PlaceBomb;

    [Header("Animation Properties")]

    public Sprite[] MoveUpSprites;
    public Sprite[] MoveDownSprites;
    public Sprite[] MoveLeftSprites;
    public Sprite[] MoveRightSprites;

    public float IdleDelay;

}
