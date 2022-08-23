using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Platforms
{
    public class Platform : MonoBehaviour
    {
        #region VARIABLES
        #region SERIALIZED VARIABLES
        [Header("Lateral Limits")]
        [SerializeField] private float minX = -2.75f;
        [SerializeField] private float maxX = 2.75f;

        [Header("Speeds")]
        [SerializeField] private float elevationSpeed = 1.0f;
        //[SerializeField] private float sideSpeed = 1.0f;

        [Header("Initial Y Positions")]
        [SerializeField] private float distanceBetweenPlatforms = 2.1f;
        

        [Header("Reset Y Limit")]
        [SerializeField] private Transform upperLimitTransform;

        #endregion

        #region STATIC VARIABLES

        #endregion

        #region PRIVATE VARIABLES

        private float[] initialPositions; 
        private float resetYPos = -5.3f;

        #endregion
        #endregion

        #region METHODS
        #region PUBLIC METHODS

        #endregion

        #region STATIC METHODS

        #endregion

        #region PRIVATE METHODS
        private void LateUpdate()
        {
            Elevate();
        }
        private void Start()
        {
            SetRandomX();
        }
        private void Elevate()
        {
            float newY = transform.position.y + elevationSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, newY);
        }
        private void SetRandomX()
        {
            float newX = minX + Random.Range(0, (Mathf.Abs(minX - maxX)));
            transform.position = new Vector3(newX, transform.position.y);
        }
        private void ResetPosition()
        {
            SetRandomX();
            transform.position = new Vector3(transform.position.x, resetYPos);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag.Equals("ResetZone"))
            {
                ResetPosition();
            }
        }
        #endregion
        #endregion
    }
}

