using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Enemies;
using Entities.Enemies.Shot;

namespace Entities.Player
{
    public class PlayerEnemies : PlayerStats
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                LoseLife(enemy.GetDamage());
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Shot"))
            {
                Shot shot = collision.gameObject.GetComponent<Shot>();
                LoseLife(shot.Damage);
            }
        }
    }
}