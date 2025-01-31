using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    private float nextFrameTime;
    private int currentFrame;
    private float animationFrameRate = 0.1f;
    private BombSO bombData;
    private BombService bombService;
    private Vector2 currentFramePosition;

    private void Start()
    {
        Invoke(nameof(FadeOut), 1);
    }
    public void ConfigureFlame(BombService bombService,Vector2 position)
    {
        currentFramePosition = position;
        this.bombService = bombService;
        this.bombData = bombService.bombData;
        this.gameObject.transform.position = currentFramePosition;
        Invoke(nameof(FadeOut), 1);
    }
    private void Update()
    {
        
    }
    public void PlayFlamesFadeOutAnimation()
    {

    }
    public void FadeOut()
    {
        bombService.ReturnObjectToPool(this);
    }
}
