using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float nextFrameTime;
    private int currentFrame;
    private float animationFrameRate = 0.1f;
    private BombSO bombData;
    private BombService bombService;
    private Vector2 currentFramePosition;
    private int spriteCount = 8;
    private int blockPosition;
    private Sprite[] currentFlameAnimation;
   // private float nextFrameTime;

    private Sprite[] startFlame;
    private Sprite[] midFlame;
    private Sprite[] endFlame;

    private void Start()
    {
        this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        Invoke(nameof(FadeOut), 1);
    }
    
    public void ConfigureFlame(BombService bombService,Vector2 position,Vector2 direction,FlameType flameType)
    {
        currentFramePosition = position;
        this.bombService = bombService;
        this.bombData = bombService.bombData;

        startFlame = bombData.StartFlameAnimationSprites;
        midFlame = bombData.MidFlameAnimationSprites;
        endFlame = bombData.EndFlameAnimationSprites;


        switch (flameType)
        {
            case FlameType.START:
                currentFlameAnimation = startFlame;
                break;
            case FlameType.MID:
                currentFlameAnimation = midFlame;
                break;
            case FlameType.END:
                currentFlameAnimation = endFlame;
                break;
        }

        // PlayFlamesFadeOutAnimation();

        this.gameObject.transform.position = currentFramePosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);
        // this.gameObject.transform.rotation()
        Invoke(nameof(FadeOut), 1);
    }
    private void Update()
    {
        if(this.gameObject)
        {
            PlayFlamesFadeOutAnimation();
        }
       
    }
    public void PlayFlamesFadeOutAnimation()
    {
        
        if (Time.time >= nextFrameTime)
        {
            spriteRenderer.sprite = currentFlameAnimation[currentFrame];
            currentFrame = (currentFrame + 1) % spriteCount;
            nextFrameTime = Time.time + animationFrameRate;
        }
    }
    public void FadeOut()
    {
        bombService.ReturnObjectToPool(this);
    }
}
