using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Views;
using Random = System.Random;

namespace Spawner
{
    public abstract class ObjectsPool<T> : MonoBehaviour
        where T : View, ISpawnable
    {
        [SerializeField] private int _capacity;
        [SerializeField] private Transform _container;

        private readonly List<T> _pool = new List<T>();

        protected Vector3 GetPositionOfContainer()
        {
            return _container.position;
        }

        protected void Initialize(T prefab, Vector2 positionOfSpawn)
        {
            for (var i = 0; i < _capacity; i++)
            {
                var spawned = Create(prefab, positionOfSpawn);
                spawned.TurnOff();

                _pool.Add(spawned);
            }
        }

        protected void Initialize(IEnumerable<T> prefabs, Vector2 positionOfSpawn)
        {
            var random = new Random();

            for (var i = 0; i < _capacity; i++)
            {
                var prefab = prefabs.RandomElement(random);
                var spawned = Instantiate(prefab, _container.transform);
                spawned.TurnOff();

                _pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out T objectOfPool)
        {
            objectOfPool = _pool.FirstOrDefault(element => element.gameObject.activeSelf == false);
            return objectOfPool != null;
        }

        private T Create(T prefab, Vector2 position)
        {
            return Instantiate(prefab, position, Quaternion.identity);
        }
    }

    internal static class Extensions
    {
        public static T RandomElement<T>(this IEnumerable<T> source, Random random)
        {
            var current = default(T);
            var count = 0;

            foreach (var element in source)
            {
                count++;

                if (random.Next(count) == 0)
                {
                    current = element;
                }
            }

            if (count == 0)
                throw new InvalidOperationException("Sequence was empty");

            return current;
        }
    }
}