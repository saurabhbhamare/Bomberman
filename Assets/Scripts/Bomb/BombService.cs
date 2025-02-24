using UnityEngine;
using UnityEngine.Tilemaps;
public class BombService
{
    //Explosion Data
    private EventService eventService;
    public BombSO bombData;
    private Bomb bomb;
    private Flame flame;
    private Vector2 bombPosition;
    private Destructible destructible;
    private GameObject destructibleObj;

    private int defaultExplosionRadius;
    private int boostedBlastRadius;

    //PoolData
    private Transform bombParent;
    private Transform flameParent;
    private int bombPoolSize;
    private int flamesPoolSize;
    private ResourcePool<Bomb> bombPool;
    private ResourcePool<Flame> flamesPool;

    //Level Data
    private LayerMask obstacleLayerMask;
    public Tilemap destructibleTilemap;
    public BombService(BombSO bombData, Bomb bomb, Flame flame, Transform bombParent, Transform flameParent, LayerMask obstacleLayerMask, Tilemap destructibleTilemap, Destructible destructible, GameObject destructibleObj, EventService eventService)
    {
        this.eventService = eventService;
        this.bombData = bombData;
        this.bomb = bomb;

        //Pool Data
        this.bombParent = bombParent;
        this.flameParent = flameParent;
        this.bombPoolSize = bombData.BombPoolSize;
        this.flamesPoolSize = bombData.FlamesPoolSize;
        bombPool = new ResourcePool<Bomb>(bomb, bombPoolSize, bombParent);
        flamesPool = new ResourcePool<Flame>(flame, flamesPoolSize, flameParent);

        //Level Destructibles & Flame Data
        this.obstacleLayerMask = obstacleLayerMask;
        this.destructibleTilemap = destructibleTilemap;
        this.destructible = destructible;
        this.destructibleObj = destructibleObj;
        this.defaultExplosionRadius = bombData.DefaultExplosionRadius;
        this.boostedBlastRadius = bombData.BoostedBlastRadius;
    }
    public void PlaceBomb(Vector2 position, bool isBlastRadiusOn)
    {
        bombPosition = position;
        Bomb bomb = bombPool.GetObject();
        bomb.transform.position = position;
        bomb.ConfigureBomb(this, isBlastRadiusOn);
    }
    public void ShowExplosionFlames(Vector2 position, bool isBlastRadius)
    {
        //Position
        Vector2 recentPos = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));

        // Center flame (start animation)
        Flame centerFlame = flamesPool.GetObject();
        centerFlame.ConfigureFlame(this, recentPos, Vector2.zero, FlameType.START);

        // Directional flames
        PlaceDirectionalFlames(recentPos, Vector2.up, FlameType.MID, FlameType.END, isBlastRadius);
        PlaceDirectionalFlames(recentPos, Vector2.down, FlameType.MID, FlameType.END, isBlastRadius);
        PlaceDirectionalFlames(recentPos, Vector2.left, FlameType.MID, FlameType.END, isBlastRadius);
        PlaceDirectionalFlames(recentPos, Vector2.right, FlameType.MID, FlameType.END, isBlastRadius);
    }
    private void PlaceDirectionalFlames(Vector2 origin, Vector2 direction, FlameType midFlameType, FlameType endFlameType, bool isBlastRadius)
    {
        int currentExplosionRadius = isBlastRadius ? this.boostedBlastRadius : defaultExplosionRadius;
        for (int i = 1; i <= currentExplosionRadius; i++)
        {
            FlameType flameType = (i == currentExplosionRadius) ? endFlameType : midFlameType;
            Vector2 offset = direction * i;
            Vector2 checkPosition = origin + offset;
            Vector2 boxSize = new Vector2(0.5f, 0.5f);
            Collider2D hit = Physics2D.OverlapBox(checkPosition, boxSize, 0f, obstacleLayerMask);
            if (hit == null)
            {
                Flame flame = flamesPool.GetObject();
                flame.ConfigureFlame(this, checkPosition, direction, flameType);
            }
            else
            {
                RemoveDestructible(checkPosition);
                break;
            }
        }
    }
    public void ReturnObjectToPool<T>(T obj) where T : MonoBehaviour
    {
        if (obj is Bomb)
        {
            bombPool.ReturnObject(obj as Bomb);
        }
        if (obj is Flame)
        {
            flamesPool.ReturnObject(obj as Flame);
        }
    }
    private void RemoveDestructible(Vector2 position)
    {
        Vector3Int cell = destructibleTilemap.WorldToCell(position);
        TileBase tile = destructibleTilemap.GetTile(cell);

        if (tile != null)
        {
            GameObject.Instantiate(destructible, position, Quaternion.identity);
            destructibleTilemap.SetTile(cell, null);
            eventService.OnRemovingDestructible.Invoke(position);
        }
    }
}
