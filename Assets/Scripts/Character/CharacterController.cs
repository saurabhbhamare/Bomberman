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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if(characterModel.bombs>0)
            {
                bombService.PlaceBomb(characterView.GetBombDropPosition());
                characterModel.bombs--;
            }
           // bombService.PlaceBomb(characterView.GetBombDropPosition());
        }
    }
    public void HandleMovement()
    {
        Vector2 position = characterView.GetRigidBody().position;
        Vector2 translation = characterModel.direction * characterModel.moveSpeed * Time.fixedDeltaTime;
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
                break;
        }

    }
    public void SpeedBoostPickup()
    {

    }
    public void ExtraBombPickUp()
    {

    }
    public void BlastRadiusPickUp()
    {
        Debug.Log("Blast radius pickup");
        if(eventService == null)
        {
            Debug.Log("event service is null");
        }
        eventService.OnBlastRadiusPickUp.Invoke();
    }
    
    //private Vector2 GetBombDropPosition()
    //{
    //  Vector2 position = characterView.g
    //}
}
