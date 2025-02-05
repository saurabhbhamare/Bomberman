using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpService
{

    private PowerUpSO powerUpData;
    private EventService eventService;


    public PowerUpService(PowerUpSO powerUpData,EventService eventService)
    {
        this.powerUpData = powerUpData;
        this.eventService = eventService;
        RegisterEventListeners();
    }
    public void SpawnPowerUp(Vector2 spawnPosition)
    {
        GameObject powerUp = GameObject.Instantiate(GetRandomPowerUp());
        powerUp.transform.position = spawnPosition;
    }
    public GameObject GetRandomPowerUp()
    {
        int randomPowerUpNumber = Random.Range(0, 2);
        return powerUpData.PowerUPs[randomPowerUpNumber];
    }
    private void RegisterEventListeners()
    {
        eventService.OnRemovingDestructible.AddListener(SpawnPowerUp);
    }

}
