using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombService
{
    private Bomb bomb;
    private Flame flame;

    private Transform bombParent;
    private Transform flameParent;

    private int bombPoolSize = 20;
    private int flamesPoolSize = 40;

    private ResourcePool<Bomb> bombPool;
    private ResourcePool<Flame> flamesPool;

    public BombService(Bomb bomb, Flame flame, Transform bombParent, Transform flameParent)
    {
        this.bomb = bomb;
        this.bombParent = bombParent;
        this.flameParent = flameParent;

        bombPool = new ResourcePool<Bomb>(bomb, bombPoolSize, bombParent);
        flamesPool = new ResourcePool<Flame>(flame, flamesPoolSize, flameParent);
    }
    public void PlaceBomb(Vector2 position)
    {
        Bomb bomb = bombPool.GetObject();
        bomb.transform.position = position;

    }
    public void Explode()
    {

    }
}
