using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy data"), Tooltip("Damage dealt to the player if touched")]
        [SerializeField] protected int damage = 0;
        [Tooltip("Horizontal speed")]
        [SerializeField] protected float speed = 0;

        protected Rigidbody2D rigidBody = null;

        protected virtual void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        protected virtual void Update()
        {
            //rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y); /// Move
            float newX = rigidBody.position.x + speed * Time.deltaTime;
            rigidBody.MovePosition(new Vector2(newX, rigidBody.position.y));
        }

        protected virtual void Turn()
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            speed *= -1;
        }

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Wall")) Turn();
        }

        public int GetDamage()
        {
            return damage;
        }
    }
}