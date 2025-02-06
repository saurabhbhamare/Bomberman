using UnityEngine;

public class CharacterController
{
    public CharacterSO characterSO;
    public CharacterModel characterModel;
    public CharacterView characterView;
    public BombService bombService;
    public EventService eventService;
    public CharacterController(CharacterView characterView, CharacterSO characterSO, BombService bombService,EventService eventService)
    {
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
            
            if(characterModel.bombs>0)
            {
                bombService.PlaceBomb(characterView.GetBombDropPosition(),characterModel.isBlastRadiusOn);
             //  bombService.PlaceBomb()
                characterModel.bombs--;
            }
          //  bombService.PlaceBomb(characterView.GetBombDropPosition());
        }
    }
    public void HandleMovement()
    {
        Vector2 position = characterView.GetRigidBody().position;
        float currentSpeed = characterModel.isSpeedBoostOn ? characterModel.boostedSpeed : characterModel.defaultSpeed;
      //  Vector2 translation = characterModel.direction * characterModel.defaultSpeed * Time.fixedDeltaTime;
        Vector2 translation = characterModel.direction * currentSpeed* Time.fixedDeltaTime;
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
                break;
            case ItemType.SPEEDBOOST:
                SpeedBoostPickup();
                break;
        }

    }
    public void SpeedBoostPickup()
    {
        Debug.Log("speed boost pickup");
        characterModel.isSpeedBoostOn = true;
        characterModel.speedBoostStartTime = Time.time;
    }

    public void UpdateSpeedBoost()
    {
        if(characterModel.isSpeedBoostOn && Time.time - characterModel.speedBoostStartTime>= characterModel.speedBoostDuration)
        {
            characterModel.isSpeedBoostOn = false;
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

    }
    public void BlastRadiusPickUp()
    {
        characterModel.isBlastRadiusOn = true;
        characterModel.blastRadiusStartTime = Time.time;
    }
    
    //private Vector2 GetBombDropPosition()
    //{
    //  Vector2 position = characterView.g
    //}
}
