using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int currentFrame;
    private float nextFrameTime;
    private float animationFramRate=0.1f;
    public Sprite[] animationSprites;
    private int totalSprites = 7;

    private void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke(nameof(DestroyObject), 0.7f);
        
    }
    private void Update()
    {
        PlayFadeOutAnimation();
    }
    private void PlayFadeOutAnimation()
    {
        if (Time.time >= nextFrameTime)
        {
            spriteRenderer.sprite = animationSprites[currentFrame];
            currentFrame = (currentFrame + 1) % totalSprites;
            nextFrameTime = Time.time + animationFramRate;
        }
    }
    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
