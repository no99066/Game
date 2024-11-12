using System;
using System.Collections.Generic;
using Model;
using UnityEngine;
using Views;

namespace Spawner
{
    [Serializable]
    public class Wave : Entity
    {
        [SerializeField] private EnemyView[] _enemyViews;
        [SerializeField] private float _timeDelayOfSpawn;
        [SerializeField] private int _countOfEnemy;

        public int CountOfSpawned { get; private set; }
        public event Action AllEnemiesSpawned;

        public float TimeDelayOfSpawn => _timeDelayOfSpawn;
        public IEnumerable<EnemyView> EnemyViews => _enemyViews;

        public void Spawn()
        {
            CountOfSpawned++;

            if (CountOfSpawned >= _countOfEnemy)
                AllEnemiesSpawned?.Invoke();
        }
    }
}