using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Timer _timer;
   

    private void OnEnable()
    {
        _startScreen.StartButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.StartButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _enemyGenerator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        _healthBar.gameObject.transform.localPosition = new Vector3(-813.9678f, 472.0651f, 0f);
        _timer.Restart();
        Time.timeScale = 1;
        _healthBar.OnHealthChanged(3);
        _player.ResetPlayer();
    }

    public void OnGameOver()
    {
        _healthBar.gameObject.transform.localPosition=new Vector3(-813.9678f, 472.0651f,0.1f);
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
    
}
