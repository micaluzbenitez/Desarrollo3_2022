using System;
using System.Collections.Generic;
using UnityEngine;
using Toolbox;
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

        [Header("Shot data")]
        [SerializeField] private int timePerShot = 0;

        private Vector2Lerper shotLerper = new Vector2Lerper();
        private Timer timerPerShot = new Timer();

        protected override void Awake()
        {
            base.Awake();
            shot.Damage = damage;
            timerPerShot.SetTimer(timePerShot, Timer.TIMER_MODE.DECREASE, true);
        }

        private void Update()
        {
            UpdateTimerPerShot();
            UpdateShotLerper();
        }

        private void UpdateTimerPerShot()
        {
            if (timerPerShot.Active) timerPerShot.UpdateTimer();

            if (timerPerShot.ReachedTimer())
            {
                Shot();
                timerPerShot.ActiveTimer();
            }
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