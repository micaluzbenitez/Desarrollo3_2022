using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Enemies
{
    public class Crab : Enemy
    {
        [Header("Crab data"), Tooltip("Horizontal speed")]
        [SerializeField] private float speed = 0;
        [Tooltip("Platform controller game object")]
        [SerializeField] private Transform platformController = null;
        [Tooltip("Controller distance down")]
        [SerializeField] private float distance = 0;

        private Rigidbody2D rigidBody = null;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y); /// Move

            RaycastHit2D platformData = Physics2D.Raycast(platformController.position, Vector2.down, distance);
            if (!platformData) Turn();
        }

        private void Turn()
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            speed *= -1;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(platformController.transform.position, platformController.transform.position + Vector3.down * distance);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Wall")) Turn();
        }
    }
}