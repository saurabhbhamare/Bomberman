using UnityEngine;
public class EventService 
{
    public EventController<CharacterType>OnGameOver;
    public EventController<Vector2> OnRemovingDestructible;
    public EventService()
    {
        OnGameOver = new EventController<CharacterType>();
        OnRemovingDestructible = new EventController<Vector2>();
    }
}
