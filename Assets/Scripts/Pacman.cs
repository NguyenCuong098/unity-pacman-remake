using UnityEngine;
using UnityEngine.InputSystem;

public class Pacman : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector2Int inputDirection;
    private Vector3Int moveDirection;
    private Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        HandleInput();
        HandleGridMovement();
    }

    private void HandleInput()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            inputDirection = Vector2Int.up;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            inputDirection = Vector2Int.down;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            inputDirection = Vector2Int.left;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            inputDirection = Vector2Int.right;
        }
    }

    private void HandleGridMovement()
    {
        moveDirection = new Vector3Int(inputDirection.x, inputDirection.y, 0);

        if (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            targetPosition = transform.position + moveDirection;
        }
    }
}
