using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    private SpriteRenderer spriteRenderer;
    private BombService bombService;
    private BombSO bombData;
    private Sprite[] scaleSprites;
    private float bombRadius;
    private int spriteCount = 4;
    private float timer;
    private float nextFrameTime;
    private int currentFrame;
    private float animationFrameRate = 0.15f;
    public void ConfigureBomb(BombService bombService)
    {
        this.circleCollider = this.gameObject.GetComponent<CircleCollider2D>();
        this.circleCollider.isTrigger = true;
        this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        this.bombService = bombService;
        bombData = bombService.bombData;
        SetBombData(this.bombData);
        Invoke(nameof(Explode), bombData.ExplosionDelay);
    }
    private void Update()
    {
        PlayScalingAnimation();
    }
    public void SetBombData(BombSO bombSO)
    {
        timer = bombData.ExplosionDelay;
        bombRadius = bombData.ExplosionRadius;
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
        if (bombService == null)
        {
            Debug.Log("bomservice null");
        }
        bombService.ShowExplosionFlames(this.transform.position);
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
