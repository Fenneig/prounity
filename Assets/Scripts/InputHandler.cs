using Modules;
using UnityEngine;
using Zenject;

public class InputHandler : MonoBehaviour
{
    [Inject] private ISnake _snake;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            _snake.Turn(SnakeDirection.UP);

        if (Input.GetKeyDown(KeyCode.S))
            _snake.Turn(SnakeDirection.DOWN);

        if (Input.GetKeyDown(KeyCode.A))
            _snake.Turn(SnakeDirection.LEFT);

        if (Input.GetKeyDown(KeyCode.D))
            _snake.Turn(SnakeDirection.RIGHT);
    }
}