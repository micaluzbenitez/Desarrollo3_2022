using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Enemies
{
    public class Crab : Enemy
    {
        [Header("Crab data"), Tooltip("Platform controller game object")]
        [SerializeField] private Transform platformController = null;
        [Tooltip("Controller distance down")]
        [SerializeField] private float distance = 0;

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            RaycastHit2D platformData = Physics2D.Raycast(platformController.position, Vector2.down, distance);
            if (!platformData) Turn();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(platformController.transform.position, platformController.transform.position + Vector3.down * distance);
        }
    }
}