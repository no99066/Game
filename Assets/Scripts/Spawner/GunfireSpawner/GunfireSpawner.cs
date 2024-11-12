using Setup;
using UnityEngine;
using Views;

namespace Spawner.GunfireSpawner
{
    public class GunfireSpawner : ObjectsPool<GunfireView>
    {
        [SerializeField] private GunfireView _gunfirePrefab;
        [SerializeField] private EnemyFinder _enemyFinder;
        [SerializeField] private Transform _spawnPoint;

        private void Start()
        {
            Initialize(_gunfirePrefab, _spawnPoint.position);
        }

        public void Shoot()
        {
            if (TryGetObject(out GunfireView gunfire))
            {
                SetGunfire(gunfire);
            }
        }

        private void SetGunfire(GunfireView gunfireView)
        {
            if (_enemyFinder.TryFindEnemy())
            {
                gunfireView.transform.position = GetPositionOfContainer();
                gunfireView.GetComponent<GunfireSetup>().Init(_enemyFinder.EnemyView, gunfireView);
                gunfireView.TurnOn();
            }
        }
    }
}