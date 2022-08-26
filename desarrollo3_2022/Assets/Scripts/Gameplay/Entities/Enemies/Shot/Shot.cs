using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Enemies.Shot
{
    public class Shot : MonoBehaviour
    {
        private int damage = 0;
        private bool collidePlayer = false;

        /// <summary>
        ///  Properties
        /// </summary>
        public int Damage { get => damage; set => damage = value; }
        public bool CollidePlayer { get => collidePlayer; set => collidePlayer = value; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) collidePlayer = true;
        }
    }
}