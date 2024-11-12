using Spawner.GunfireSpawner;
using UnityEngine;

namespace Views
{
    public class CastleView : View
    {
        [SerializeField] private GunfireSpawner _gunfireSpawner;

        public void Attack()
        {
            _gunfireSpawner.Shoot();
        }
    }
}