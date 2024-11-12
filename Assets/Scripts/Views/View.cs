using Setup;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Setup<,>))]
    public abstract class View : MonoBehaviour
    {
        public Vector2 Position => transform.position;

        public virtual void Died()
        {
            Destroy(gameObject);
        }
    }
}