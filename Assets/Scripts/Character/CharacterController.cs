using UnityEngine;

public class CharacterController
{
    public CharacterSO characterSO;
    public CharacterModel characterModel;
    public CharacterView characterView;
    public BombService bombService;
    public CharacterController(CharacterView characterView, CharacterSO characterSO,BombService bombService)
    {
        this.characterSO = characterSO;
        characterModel = new CharacterModel(this.characterSO);
        this.characterView = characterView;
        this.bombService = bombService;
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bombService.PlaceBomb(characterView.transform.position);
        }
    }
    public void HandleMovement()
    {
        Vector2 position = characterView.GetRigidBody().position;
        Vector2 translation = characterModel.direction * characterModel.moveSpeed * Time.fixedDeltaTime;
        characterView.GetRigidBody().MovePosition(position + translation);
    }
    
}
