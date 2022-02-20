using UnityEngine;

namespace Ecs.View.Impl
{
    public sealed class TileView : LinkView
    {
        public bool active = false;
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer sprite;
        private static readonly int Activate = Animator.StringToHash("Activate");

        private void OnEnable()
        {
            animator.SetTrigger(Activate);
        }

        private void OnDisable()
        {
            Transform.rotation = Quaternion.identity;
            sprite.color = new Color(1, 1, 1, 1);
        }
    }
}