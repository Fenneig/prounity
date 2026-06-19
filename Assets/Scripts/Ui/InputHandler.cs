using Modules;
using UnityEngine;
using Zenject;

namespace Ui
{
    public sealed class InputHandler : MonoBehaviour
    {
        private ISnake _snake;
    
        [Inject]
        public void Construct(ISnake snake) => 
            _snake = snake;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                _snake.Turn(SnakeDirection.UP);

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                _snake.Turn(SnakeDirection.DOWN);

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                _snake.Turn(SnakeDirection.LEFT);

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                _snake.Turn(SnakeDirection.RIGHT);
        }
    }
}