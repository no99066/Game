using UnityEngine;
using Views;

namespace Spawner
{
    public class EnemyFinder : MonoBehaviour
    {
        [SerializeField] private float _rayDistance;

        private Transform _transform;
        public EnemyView EnemyView { get; private set; }

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        public bool TryFindEnemy()
        {
            var hit = Physics2D.Raycast(_transform.position, Vector2.right, _rayDistance);

            if (hit)
            {
                if (hit.collider.gameObject.TryGetComponent(out EnemyView enemyView))
                {
                    EnemyView = enemyView;
                    return true;
                }
            }

            EnemyView = null;

            return false;
        }
    }
}