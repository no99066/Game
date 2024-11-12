using System;
using Spawner;
using UnityEngine;

namespace Views
{
    public class GunfireView : View, ISpawnable
    {
        private Transform _transform;

        public event Action<EnemyView> Collided;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        public void Move(Vector2 position)
        {
            _transform.position = position;
        }

        public void TurnOff()
        {
            gameObject.SetActive(false);
        }

        public void TurnOn()
        {
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out EnemyView enemyView))
            {
                Collided?.Invoke(enemyView);
            }

            TurnOff();
        }
    }
}