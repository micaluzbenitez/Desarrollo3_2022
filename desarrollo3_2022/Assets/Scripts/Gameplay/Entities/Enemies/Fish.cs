using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Enemies
{
    public class Fish : Enemy
    {
        [Header("Fish data"), Tooltip("Horizontal speed")]
        [SerializeField] private float speed = 0;

        private Rigidbody2D rigidBody = null;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y); /// Move
        }

        private void Turn()
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            speed *= -1;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Wall")) Turn();
        }
    }
}