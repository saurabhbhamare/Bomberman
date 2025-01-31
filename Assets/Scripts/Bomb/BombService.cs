using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombService
{
    public  BombSO bombData;
    private Bomb bomb;
    private Flame flame;
    private Vector2 bombPosition;

    private Transform bombParent;
    private Transform flameParent;

    private int bombPoolSize = 20;
    private int flamesPoolSize = 40;

    private ResourcePool<Bomb> bombPool;
    private ResourcePool<Flame> flamesPool;

    public BombService(BombSO bombData, Bomb bomb, Flame flame, Transform bombParent, Transform flameParent)
    {
        this.bombData = bombData;  
        this.bomb = bomb;
        this.bombParent = bombParent;
        this.flameParent = flameParent;

        bombPool = new ResourcePool<Bomb>(bomb, bombPoolSize, bombParent);
        flamesPool = new ResourcePool<Flame>(flame, flamesPoolSize, flameParent);
    }
    public void PlaceBomb(Vector2 position)
    {
        bombPosition = position;
        Bomb bomb = bombPool.GetObject();
        bomb.transform.position = position;
        bomb.ConfigureBomb(this);

    }
    public void ShowExplosionFlames(Vector2 position)
    {
        //Vector2 recentPos = position;
        Vector2 recentPos = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
        Flame centerFlame = flamesPool.GetObject();

        //centerFlame.transform.position = bombPosition;
        centerFlame.transform.position = recentPos;
        centerFlame.ConfigureFlame(this, recentPos, Vector2.zero, FlameType.START);

        for (int i = 1; i <= bombData.ExplosionRadius; i++)
        {
            {
                FlameType flameType = (i == bombData.ExplosionRadius) ? FlameType.END : FlameType.MID;
                //flamesPool.GetObject().transform.position = recentPos + Vector2.up * i;
                //flamesPool.GetObject().transform.position = recentPos + Vector2.down * i;
                //flamesPool.GetObject().transform.position = recentPos + Vector2.left * i;
                //flamesPool.GetObject().transform.position = recentPos + Vector2.right * i;

                flamesPool.GetObject().ConfigureFlame(this, recentPos + Vector2.up * i, Vector2.up, flameType);
                flamesPool.GetObject().ConfigureFlame(this, recentPos + Vector2.down * i, Vector2.down, flameType);
                flamesPool.GetObject().ConfigureFlame(this, recentPos + Vector2.left * i, Vector2.left, flameType);
                flamesPool.GetObject().ConfigureFlame(this, recentPos + Vector2.right * i, Vector2.right, flameType);
                //flamesPool.GetObject().transform.position = recentPos + Vector2.down * i;
                //flamesPool.GetObject().transform.position = recentPos + Vector2.left * i;
                //flamesPool.GetObject().transform.position = recentPos + Vector2.right * i;
            }
        }
    }
    //public void Explode()
    //{

    //}
    public void ReturnObjectToPool<T>(T obj) where T : MonoBehaviour
    {
        if (obj is Bomb)
        {
            bombPool.ReturnObject(obj as Bomb);
        }
        if(obj is Flame)
        {
            flamesPool.ReturnObject(obj as Flame);
        }
    }
}
