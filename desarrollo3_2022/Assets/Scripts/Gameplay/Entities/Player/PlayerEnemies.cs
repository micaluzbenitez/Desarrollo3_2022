using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Enemies;

namespace Entities.Player
{
    public class PlayerEnemies : PlayerStats
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy) LoseLife(enemy.GetDamage());
        }
    }
}