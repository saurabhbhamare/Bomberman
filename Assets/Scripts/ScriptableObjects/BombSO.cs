using UnityEngine;

[CreateAssetMenu(fileName = "ExplosionScriptableObject", menuName = "ScriptableObject/ExplosionScriptableObject")]

public class BombSO : ScriptableObject
{
    [Header("Bomb Properties")]
    public float ExplosionRadius;
    public float ExplosionDelay;
    public float BombAnimationFrameRate;

    public Sprite[] BombAnimationSprites;

    //[Header("Explosion Properties")]
    
    
}
