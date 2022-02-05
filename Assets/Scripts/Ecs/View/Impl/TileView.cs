
using System;
using Ecs.Components;
using Ecs.Systems.Pool.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.View.Impl
{
    public class TileView : LinkView
    {
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