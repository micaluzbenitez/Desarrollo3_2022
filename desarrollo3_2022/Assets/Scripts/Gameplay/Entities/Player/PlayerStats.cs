using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [Header("Player data")]
        [SerializeField] protected int initialLife = 0;

        protected int life = 0;

        protected virtual void Awake()
        {
            life = initialLife;
        }

        protected void LoseLife(int damage)
        {
            life -= damage;
            Debug.Log("Life: " + life);
        }
    }
}