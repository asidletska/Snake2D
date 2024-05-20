using System.Collections.Generic;
using UnityEngine;

public class Snake2 : MonoBehaviour
{
    private enum Direction { Up, Down, Left, Right }

    private List<Vector2Int> snakePositions = new List<Vector2Int>();
    private Direction currentDirection = Direction.Right;
    private bool isGameOver = false;

    [SerializeField] private float moveInterval = 0.1f;
    [SerializeField] private GameObject BodyPrefab;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Transform border;

    private float timer = 0f;

    private void Start()
    {
        // Initial snake position
        snakePositions.Add(new Vector2Int(0, 0));
        snakePositions.Add(new Vector2Int(-1, 0));
        snakePositions.Add(new Vector2Int(-2, 0));

        // Place food
        SpawnFood();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            timer += Time.deltaTime;
            if (timer >= moveInterval)
            {
                timer = 0f;
                MoveSnake();
            }
        }
    }

    private void MoveSnake()
    {
        // Move snake
        Vector2Int headPos = snakePositions[0];
        Vector2Int newHeadPos = headPos;

        switch (currentDirection)
        {
            case Direction.Up:
                newHeadPos += Vector2Int.up;
                break;
            case Direction.Down:
                newHeadPos += Vector2Int.down;
                break;
            case Direction.Left:
                newHeadPos += Vector2Int.left;
                break;
            case Direction.Right:
                newHeadPos += Vector2Int.right;
                break;
        }

        // Check for self-collision
        if (snakePositions.Contains(newHeadPos) || IsOutOfBounds(newHeadPos))
        {
            GameOver();
            return;
        }

        // Add new head position
        snakePositions.Insert(0, newHeadPos);

        // Remove tail
        snakePositions.RemoveAt(snakePositions.Count - 1);

        // Check for food
       /* if (newHeadPos == food.transform.position)
        {
            EatFood();
        }*/

        // Update snake visuals
       // UpdateSnakeBody();
    }

    private bool IsOutOfBounds(Vector2Int pos)
    {
        float minX = border.position.x - border.localScale.x / 2f;
        float maxX = border.position.x + border.localScale.x / 2f;
        float minY = border.position.y - border.localScale.y / 2f;
        float maxY = border.position.y + border.localScale.y / 2f;

        return pos.x < minX || pos.x > maxX || pos.y < minY || pos.y > maxY;
    }

  /*  private void UpdateSnakeBody()
    {
        for (int i = 0; i < snakePositions.Count; i++)
        {
         //   GameObject body = Body[i];
            body.transform.position = new Vector3(snakePositions[i].x, snakePositions[i].y, 0);
        }
    }
  */
    private void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
    }

    private void EatFood()
    {
        // Add new tail
        snakePositions.Add(snakePositions[snakePositions.Count - 1]);

        // Spawn new food
        SpawnFood();
    }

    private void SpawnFood()
    {
        Vector2Int foodPos = new Vector2Int(Random.Range(-9, 10), Random.Range(-4, 5));
        Instantiate(foodPrefab, new Vector3(foodPos.x, foodPos.y, 0), Quaternion.identity);
    }

    public void ChangeDirection(int newDirection)
    {
        if (!isGameOver)
        {
            Direction oppositeDir = (Direction)(((int)currentDirection + 2) % 4);
            if ((Direction)newDirection != oppositeDir)
            {
                currentDirection = (Direction)newDirection;
            }
        }
    }
}
