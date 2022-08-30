using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [Header("Player data")]
        [SerializeField] private int initialLife = 0;

        //[SerializeField] 
        private int life = 0;

        private void Awake()
        {
            life = initialLife;
        }

        public void LoseLife(int damage)
        {
            life -= damage;
        }
    }
}