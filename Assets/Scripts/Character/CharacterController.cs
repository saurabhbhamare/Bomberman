using UnityEngine;

public class CharacterController
{
    public CharacterSO characterSO;
    public CharacterModel characterModel;
    public CharacterView characterView;
    public CharacterController(CharacterView characterView, CharacterSO characterSO)
    {
        this.characterSO = characterSO;
        characterModel = new CharacterModel(this.characterSO);
        this.characterView = characterView;
    }

    public void TakeMovementInput()
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
    }
    public void MoveCharacter()
    {
        Vector2 position = characterView.GetRigidBody().position;
        Vector2 translation = characterModel.direction * characterModel.moveSpeed * Time.fixedDeltaTime;
        characterView.GetRigidBody().MovePosition(position + translation);
    }

}
