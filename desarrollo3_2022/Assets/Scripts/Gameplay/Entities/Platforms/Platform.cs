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


        [Header("Obstacle Spawn")]
        [SerializeField] private GameObject obstacle;

        #endregion

        #region STATIC VARIABLES
        #endregion

        #region PRIVATE VARIABLES

        private float resetYPos = -5.3f;

        #endregion
        #endregion

        #region METHODS
        #region PUBLIC METHODS

        #endregion

        #region STATIC METHODS

        #endregion

        #region PRIVATE METHODS
        private void Start()
        {
            SetRandomX();
        }

        private void LateUpdate()
        {
            Elevate();
        }
        
        private void Elevate()
        {
            float newY = transform.position.y + PlatformController.PlatformVerticalSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, newY);
        }
        private void SetRandomX()
        {
            float newX = minX + Random.Range(0, (Mathf.Abs(minX - maxX)));
            transform.position = new Vector3(newX, transform.position.y);
        }
        private void ResetPosition()
        {
            obstacle.SetActive(false);
            SetRandomX();
            transform.position = new Vector3(transform.position.x, resetYPos);
            SpawnEnemy();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.Equals("ResetZone"))
            {
                ResetPosition();
            }
        }

        private void SpawnEnemy()
        {
            float rand = Random.Range(0.0f, 1.0f);
            Debug.Log("Random: " + rand + "/ SpawnRate: " + PlatformController.ObstacleSpawnRate);
            if (PlatformController.ObstacleSpawnRate > 1.0f || rand < PlatformController.ObstacleSpawnRate)
            {
                obstacle.SetActive(true);
            }
        }

        private void ApplySpawnRateAugment()
        {

        }

        #endregion
        #endregion
    }
}

