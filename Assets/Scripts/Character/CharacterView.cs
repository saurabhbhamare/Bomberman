using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{

    private CharacterController characterController;
    private new Rigidbody2D rigidbody;
    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        characterController.TakeMovementInput();
    }
    private void FixedUpdate()
    {
        characterController.MoveCharacter();
    }
    public void SetCharacterController(CharacterController characterController)
    {
        this.characterController = characterController;
    }
    public Rigidbody2D GetRigidBody()
    {
        return rigidbody;
    }
}
