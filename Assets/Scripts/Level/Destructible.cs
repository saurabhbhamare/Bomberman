//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int currentFrame;
    private float nextFrameTime;
    private float animationFramRate;
    private float objectDuration;
    public Sprite[] animationSprites;
    private int totalSprites;
    private void Start()
    {
        //Object Data
        animationFramRate = 0.1f;
        objectDuration = 0.7f;
        totalSprites = 7; 

        this.spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke(nameof(DestroyObject), objectDuration); 
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
