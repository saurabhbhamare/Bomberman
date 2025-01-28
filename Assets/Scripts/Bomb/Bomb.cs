using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private BombService bombService;
    private float timer;

    public void ConfigureBomb(float explosionDelay,BombService bombService)
    {
        timer = explosionDelay;
        this.bombService = bombService;
        Invoke(nameof(Explode), 2);
    }
    public void Explode()
    {
        bombService.ReturnObjectToPool(this);
    }
}
