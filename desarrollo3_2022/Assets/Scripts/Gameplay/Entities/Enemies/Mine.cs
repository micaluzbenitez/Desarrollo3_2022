using System;
using System.Collections.Generic;
using UnityEngine;
using Toolbox.Lerpers;

namespace Entities.Enemies
{
    public class Mine : Enemy
    {
        [Header("Mine data")]
        [SerializeField] private Shot.Shot shot = null;
        [Tooltip("Shot movement speed")]
        [SerializeField] private float shotSpeed = 0;
        [Tooltip("Target to shoot")]
        [SerializeField] private Transform target = null;

        private Vector2Lerper shotLerper = new Vector2Lerper();

        protected override void Awake()
        {
            base.Awake();
            shot.Damage = damage;
        }

        private void Update()
        {
            UpdateShotLerper();

            if (Input.GetKeyDown(KeyCode.M)) Shot();
        }

        private void Shot()
        {
            shotLerper.SetLerperValues(transform.position, target.position, shotSpeed, Lerper<Vector2>.LERPER_TYPE.STEP_SMOOTH, true);
        }

        private void UpdateShotLerper()
        {
            if (shotLerper.Active)
            {
                shotLerper.UpdateLerper();
                shot.transform.position = shotLerper.GetValue();

                if (shot.CollidePlayer)
                {
                    shotLerper.DesactiveLerper();
                    shot.transform.localPosition = Vector2.zero;
                    shot.CollidePlayer = false;
                }
            }
        }
    }
}