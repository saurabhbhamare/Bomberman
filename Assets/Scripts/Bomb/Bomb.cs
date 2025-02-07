using UnityEngine;
public class Bomb : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    private SpriteRenderer spriteRenderer;
    private BombService bombService;
    private BombSO bombData;
    private Sprite[] scaleSprites;
    private float bombRadius;
    private float explosionDelay;
    private int spriteCount;
    private float timer;
    private float nextFrameTime;
    private int currentFrame;
    private float animationFrameRate;
    private bool isBlastRadiusOn;
    public void ConfigureBomb(BombService bombService, bool isBlastRadiusOn)
    {
        animationFrameRate = 0.15f;
        spriteCount = 4;
        this.circleCollider = this.gameObject.GetComponent<CircleCollider2D>();
        this.circleCollider.isTrigger = true;
        this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        this.bombService = bombService;
        bombData = bombService.bombData;
        this.isBlastRadiusOn = isBlastRadiusOn;
        SetBombData(this.bombData);
        Invoke(nameof(Explode), timer);
    }
    private void Update()
    {
        PlayScalingAnimation();
    }
    public void SetBombData(BombSO bombSO)
    {
        timer = bombData.ExplosionDelay;
        if (isBlastRadiusOn)
        {
            bombRadius = bombSO.BoostedBlastRadius;
        }
        else
        {
            bombRadius = bombSO.DefaultExplosionRadius;
        }
        scaleSprites = bombData.BombAnimationSprites;
        nextFrameTime = Time.time + bombData.BombAnimationFrameRate;
    }
    public void PlayScalingAnimation()
    {
        if (Time.time >= nextFrameTime)
        {
            spriteRenderer.sprite = scaleSprites[currentFrame];
            currentFrame = (currentFrame + 1) % spriteCount;
            nextFrameTime = Time.time + animationFrameRate;
        }
    }
    public void Explode()
    {
        bombService.ShowExplosionFlames(this.transform.position, this.isBlastRadiusOn);
        bombService.ReturnObjectToPool(this);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CharacterView>())
        {
            this.circleCollider.isTrigger = false;
        }
    }

}
