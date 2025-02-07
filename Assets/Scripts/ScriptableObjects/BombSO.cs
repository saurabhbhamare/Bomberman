using UnityEngine;

[CreateAssetMenu(fileName = "ExplosionScriptableObject", menuName = "ScriptableObject/ExplosionScriptableObject")]
public class BombSO : ScriptableObject
{
    [Header("Pool Properties")]
    public int BombPoolSize;
    public int FlamesPoolSize;

    [Header("Bomb Properties")]
    public int DefaultExplosionRadius;
    public int BoostedBlastRadius;
    public float ExplosionDelay;
    public float BombAnimationFrameRate;

    [Header("Bomb Animation Data")]
    public Sprite[] BombAnimationSprites;

    [Header("Explosion Properties/Flames")]
    public Sprite[] StartFlameAnimationSprites;
    public Sprite[] MidFlameAnimationSprites;
    public Sprite[] EndFlameAnimationSprites;

    public int FlameSpriteCount;
    public float FlameAnimationFrameRate;



}
