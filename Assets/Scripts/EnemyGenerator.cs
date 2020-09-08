using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class EnemyGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondBetweenSpawn;
    [SerializeField] private float _upSpawnPositionY;
    [SerializeField] private float _downSpawnPositionY;

    private float _elapsedTime = 0;   
    private float spawnPointY;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime> _secondBetweenSpawn)
        {
            if (TryGetObject(out GameObject Enemy))
            {
                _elapsedTime = 0;
                
                if (Random.Range(0,2)==1)
                {
                    spawnPointY = _upSpawnPositionY;
                }
                else
                {
                    spawnPointY = _downSpawnPositionY;
                }
                
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPointY, transform.position.z);
                Enemy.SetActive(true);
                Enemy.transform.position = spawnPoint;

                DisableObjectAbroadScreen();

            }

        }
    }
}
