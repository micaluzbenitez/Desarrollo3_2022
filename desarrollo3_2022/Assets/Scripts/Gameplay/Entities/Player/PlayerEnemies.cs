using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Enemies;
using Entities.Enemies.Objects;

namespace Entities.Player
{
    public class PlayerEnemies : PlayerStats
    {
        [Header("Obstacles tags")]
        public string enemiesTag = "";
        public string bulletsTag = "";

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(enemiesTag))
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                LoseLife(enemy.GetDamage());
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(bulletsTag))
            {
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                LoseLife(bullet.Damage);
            }
        }
    }
}