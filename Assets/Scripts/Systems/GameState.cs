using System;
using Modules;

namespace Systems
{
    public sealed class GameState
    {
        private ISnake _snake;

        public event Action<bool> OnGameEnded; 

        public GameState(ISnake snake)
        {
            _snake = snake;
        }
        
        public void GameOver(bool win)
        {
            _snake.SetActive(false);
            OnGameEnded?.Invoke(win);
        }
    }
}