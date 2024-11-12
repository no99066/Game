using UnityEngine;

namespace Model.Enemies
{
    public class Golem : Enemy
    {
        public Golem(ITarget[] targets, Vector2 position) : base(targets, position)
        {
        }
    }
}