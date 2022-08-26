using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Player
{
    public class PlayerFall : PlayerStats
    {
        protected bool isFalling = false;

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Floor") isFalling = true;
        }
    }
}