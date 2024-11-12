using System.Collections;
using Setup;
using UnityEngine;
using Views;
using Random = UnityEngine.Random;

namespace Spawner.EnemySpawner
{
    public class EnemySpawner : ObjectsPool<EnemyView>
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Root _root;

        private Wave[] _waves;

        private Wave _currentWave;
        private int _numberOfCurrentWave;

        private void Awake()
        {
            _root.Init();
            _waves = _root.Waves;
            _currentWave = _waves[_numberOfCurrentWave];
            Initialize(_currentWave.EnemyViews, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position);
        }

        private void OnEnable()
        {
            _currentWave.AllEnemiesSpawned += OnAllEnemiesSpawned;
        }

        private void OnDisable()
        {
            _currentWave.AllEnemiesSpawned -= OnAllEnemiesSpawned;
        }

        private void Start()
        {
            StartCoroutine(EnemiesSpawning());
        }

        private IEnumerator EnemiesSpawning()
        {
            while (enabled)
            {
                if (_currentWave.Equals(null))
                    continue;

                yield return new WaitForSeconds(_currentWave.TimeDelayOfSpawn);
                Spawn();
            }
        }

        private void Spawn()
        {
            if (TryGetObject(out EnemyView enemyView))
            {
                SetEnemy(enemyView);
                _currentWave.Spawn();
            }
        }

        private void SetEnemy(EnemyView enemyView)
        {
            enemyView.transform.position = GetPositionOfContainer();
            enemyView.GetComponent<EnemySetup>().Init(_root.Score, _root.Wizard, _root.Archer, _root.Castle);
            enemyView.TurnOn();
        }

        private void OnAllEnemiesSpawned()
        {
            if (_numberOfCurrentWave == _waves.Length - 1)
                return;

            SetNextWave();
        }

        private void SetNextWave()
        {
            _currentWave.AllEnemiesSpawned -= OnAllEnemiesSpawned;
            _currentWave = _waves[++_numberOfCurrentWave];
            _currentWave.AllEnemiesSpawned += OnAllEnemiesSpawned;
        }
    }
}