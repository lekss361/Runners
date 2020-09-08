using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected PlayerMover _mover;
    [SerializeField] private int _score;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Timer _timer;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        
        _mover = GetComponent<PlayerMover>();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
    public void ApplyDamage(int damage)
    {
        if (damage==damage)
        {
            _health -= damage;
            HealthChanged?.Invoke(_health);

            if (_health <= 0)
            {

                GameOver?.Invoke();
            }
        }
        
    }

    public void ResetPlayer()
    {

        _health = 3;
        _score = 0;
        _mover.ResetPlayer();       
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();              
    }
}
