using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy data"), Tooltip("Damage dealt to the player if touched")]
        [SerializeField] private int damage = 0;

        public int GetDamage()
        {
            return damage;
        }
    }
}