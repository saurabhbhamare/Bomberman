using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventService 
{
    public EventController<CharacterType>OnGameOver;

    public EventController<Vector2> OnRemovingDestructible;

    //powerups
    public EventController OnSpeedBoostPickUp;
    public EventController OnExtraBombPickUp;
    public EventController OnBlastRadiusPickUp;

    public EventService()
    {
        OnGameOver = new EventController<CharacterType>();
        OnRemovingDestructible = new EventController<Vector2>();
        OnBlastRadiusPickUp = new EventController();
    }
}
