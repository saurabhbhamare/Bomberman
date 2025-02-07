using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private CharacterController characterController;
    private new Rigidbody2D rigidbody;
    private CircleCollider2D circleCollider;
    private SpriteRenderer spriteRenderer;

    private int idleMoveSprite = 0;
    private int maxDirMovementFrames = 4;

    private float frameTimer;
    private int currentFrame;
    public float frameRate = 0.1f;

    public float idleTimer;
    public float idleDelay = 0.2f;

    public Vector2 lastDirection;
    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        characterController.HandleInput();
        characterController.UpdateSpeedBoost();
        characterController.UpdateBlastRadius();
        characterController.BombRefill();
        PlayAnimation();
    }
    private void FixedUpdate()
    {
        characterController.HandleMovement();
    }
    public void SetCharacterController(CharacterController characterController)
    {
        this.characterController = characterController;
    }
    public Rigidbody2D GetRigidBody()
    {
        return rigidbody;
    }
    public CircleCollider2D GetCircleCollider()
    {
        return this.circleCollider;
    }
    public Vector2 GetBombDropPosition()
    {
        Vector2 position = new Vector2(Mathf.Round(circleCollider.bounds.center.x), Mathf.Round(circleCollider.bounds.center.y));
        return position;
    }
    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }
    public void PlayAnimation()
    {
        Vector2 direction = characterController.characterModel.direction;
        if (direction != Vector2.zero)
        {
            lastDirection = direction;
            frameTimer += Time.deltaTime;
            if (frameTimer >= frameRate)
            {
                frameTimer = 0f;
                currentFrame = (currentFrame + 1) % maxDirMovementFrames;
                if (direction == Vector2.up)
                {
                    spriteRenderer.sprite = characterController.characterModel.upMoveSprites[currentFrame];
                }
                else if (direction == Vector2.down)
                {
                    spriteRenderer.sprite = characterController.characterModel.downMoveSprites[currentFrame];
                }
                else if (direction == Vector2.left)
                {
                    spriteRenderer.sprite = characterController.characterModel.leftMoveSprites[currentFrame];
                }
                else if (direction == Vector2.right)
                {
                    spriteRenderer.sprite = characterController.characterModel.rightMoveSprites[currentFrame];
                }
            }
        }
        else
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleDelay)
            {
                DisplayIdleSprite();
            }
        }
    }
    public void DisplayIdleSprite()
    {
        if (lastDirection == Vector2.up)
        {
            spriteRenderer.sprite = characterController.characterModel.upMoveSprites[idleMoveSprite];
        }
        else if (lastDirection == Vector2.down)
        {
            spriteRenderer.sprite = characterController.characterModel.downMoveSprites[idleMoveSprite];
        }
        else if (lastDirection == Vector2.left)
        {
            spriteRenderer.sprite = characterController.characterModel.leftMoveSprites[idleMoveSprite];
        }
        else if (lastDirection == Vector2.right)
        {
            spriteRenderer.sprite = characterController.characterModel.rightMoveSprites[idleMoveSprite];
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Flame>())
        {
            characterController.eventService.OnGameOver.Invoke(characterController.characterModel.characterType);
        }
        if (other.gameObject.GetComponent<PowerUP>())
        {
            ItemType itemType = other.gameObject.GetComponent<PowerUP>().itemType;
            characterController.OnPickingPowerUP(itemType);
        }
    }
}
