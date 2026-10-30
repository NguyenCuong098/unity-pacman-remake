using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Pacman : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Tilemap wallTileMap;

    private Vector2Int inputDirection;
    private Vector3Int currectMoveDirection;
    private Vector3Int nextMoveDirection;
    private Vector3Int targetPosition;

    private void Awake()
    {
        targetPosition = Vector3Int.RoundToInt(transform.position);
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
        if (transform.position == targetPosition)
        {
            nextMoveDirection = new Vector3Int(inputDirection.x, inputDirection.y, 0);
            Vector3 nextPosition = transform.position + nextMoveDirection;

            if (IsTileWalkable(nextPosition))
            {
                targetPosition = Vector3Int.RoundToInt(nextPosition);
                currectMoveDirection = nextMoveDirection;
            }
            else
            {
                nextPosition = transform.position + currectMoveDirection;

                if (!IsTileWalkable(nextPosition))
                {
                    nextPosition = Vector3Int.RoundToInt(transform.position);
                }

                targetPosition = Vector3Int.RoundToInt(nextPosition);
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private bool IsTileWalkable(Vector3 tilePosition)
    {
        Vector3Int cellPosition = wallTileMap.WorldToCell(tilePosition);
        TileBase tile = wallTileMap.GetTile(cellPosition);
        if (tile == null)
        {
            Debug.Log(tile);
            return true;
        }
        return false;
    }
}
