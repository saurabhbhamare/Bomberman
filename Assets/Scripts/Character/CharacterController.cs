using UnityEngine;
public class CharacterController
{
    public CharacterSO characterSO;
    public CharacterModel characterModel;
    public CharacterView characterView;
    public BombService bombService;
    public EventService eventService;
    public CharacterHUD characterHUD;
    public CharacterController(CharacterView characterView, CharacterSO characterSO, BombService bombService, EventService eventService,CharacterHUD characterHUD)
    {
        this.characterHUD = characterHUD;
        this.characterSO = characterSO;
        characterModel = new CharacterModel(this.characterSO);
        this.characterView = characterView;
        this.bombService = bombService;
        this.eventService = eventService;
    }
    public void HandleInput()
    {
        if (Input.GetKey(characterModel.keyUp))
        {
            characterModel.SetDirection(Vector2.up);
        }
        else if (Input.GetKey(characterModel.keyDown))
        {
            characterModel.SetDirection(Vector2.down);
        }
        else if (Input.GetKey(characterModel.keyLeft))
        {
            characterModel.SetDirection(Vector2.left);
        }
        else if (Input.GetKey(characterModel.keyRight))
        {
            characterModel.SetDirection(Vector2.right);
        }
        else
        {
            characterModel.SetDirection(Vector2.zero);
        }
        if (Input.GetKeyDown(characterModel.placeBomb))
        {

            if (characterModel.currentBombs > 0)
            {
                bombService.PlaceBomb(characterView.GetBombDropPosition(), characterModel.isBlastRadiusOn);
                this.characterModel.currentBombs--;
                Debug.Log("current bombs " + characterModel.currentBombs);
                characterHUD.UpdatePlayerBombs(characterModel.currentBombs);
            }
        }
    }
    public void HandleMovement()
    {
        Vector2 position = characterView.GetRigidBody().position;
        float currentSpeed = characterModel.isSpeedBoostOn ? characterModel.boostedSpeed : characterModel.defaultSpeed;
        Vector2 translation = characterModel.direction * currentSpeed * Time.fixedDeltaTime;
        characterView.GetRigidBody().MovePosition(position + translation);
    }

    public void OnPickingPowerUP(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.BLASTRADIUS:
                BlastRadiusPickUp();
               
                break;
            case ItemType.EXTRABOMB:
                ExtraBombPickUp();
                characterHUD.UpdatePlayerBombs(characterModel.currentBombs);
                break;
            case ItemType.SPEEDBOOST:
                SpeedBoostPickup();
                if(characterHUD == null)
                {
                    Debug.Log("characterHUD is null");
                    return;
                }
                characterHUD.ShowSpeedBoost();
                break;
        }
    }
    public void SpeedBoostPickup()
    {
        Debug.Log("SpeedBoost Pickup");
        characterModel.isSpeedBoostOn = true;
        characterModel.speedBoostStartTime = Time.time;
    }

    public void UpdateSpeedBoost()
    {
        if (characterModel.isSpeedBoostOn && Time.time - characterModel.speedBoostStartTime >= characterModel.speedBoostDuration)
        {
            characterModel.isSpeedBoostOn = false;
            characterHUD.HideSpeedBoost();
        }
    }
    public void UpdateBlastRadius()
    {
        if (characterModel.isBlastRadiusOn && Time.time - characterModel.blastRadiusStartTime >= characterModel.blastRadiusDuration)
        {
            characterModel.isBlastRadiusOn = false;
        }
    }
    public void ExtraBombPickUp()
    {
        if (characterModel.currentBombs < characterModel.maxBombs)
        {
            characterModel.currentBombs++;
        }
        Debug.Log("Current Bombs after ExtraBombPickup" + characterModel.currentBombs);
        characterHUD.UpdatePlayerBombs(characterModel.currentBombs);
    }
    public void BlastRadiusPickUp()
    {
        characterModel.isBlastRadiusOn = true;
        characterModel.blastRadiusStartTime = Time.time;
    }
    public void BombRefill()
    {
        if (Time.time - characterModel.lastBombRefillTime >= characterModel.bombRefillInterval)
        {
            if (characterModel.currentBombs < characterModel.maxBombs)
            {
                characterModel.currentBombs++;
                Debug.Log("Increased bomb counter" + characterModel.currentBombs);
                
            }
            characterModel.lastBombRefillTime = Time.time;
        }
        //characterHUD.UpdatePlayerBombs(characterModel.currentBombs);
    }
}
