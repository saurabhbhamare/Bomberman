using UnityEngine;

[CreateAssetMenu(fileName = "ExplosionScriptableObject", menuName = "ScriptableObject/ExplosionScriptableObject")]

public class BombSO : ScriptableObject
{
    [Header("Bomb Properties")]
    public int ExplosionRadius;
    public float ExplosionDelay;
    public float BombAnimationFrameRate;

    public Sprite[] BombAnimationSprites;

    [Header("Explosion Properties")]

    public Sprite[] StartFlameAnimationSprites;
    public Sprite[] MidFlameAnimationSprites;
    public Sprite[] EndFlameAnimationSprites;

}
