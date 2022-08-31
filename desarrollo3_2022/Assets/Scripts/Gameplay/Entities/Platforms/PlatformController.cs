using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Platforms
{
    public class PlatformController : MonoBehaviour
    {
        #region VARIABLES
        #region SERIALIZED VARIABLES

        [SerializeField] private float timeForNextAugment = 5;
        [SerializeField] private float augmentDuration = 3; 
        [SerializeField] private float augmentValue = 0.001f;                                               

        #endregion

        #region STATIC VARIABLES

        private static float platformVerticalSpeed = 1.0f;

        #endregion

        #region PRIVATE VARIABLES

        #endregion

        #region PROPERTIES
        public static float VerticalSpeed
        {
            get
            {
                return platformVerticalSpeed;
            }
        }
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
            StartCoroutine(SecondsTimer());
        }

        IEnumerator SecondsTimer()
        {
            StartCoroutine(SpeedAugment());
            yield return new WaitForSeconds(timeForNextAugment);
        }
        IEnumerator SpeedAugment()
        {
            float t = 0;
            while (t < augmentDuration)
            {
                t += Time.deltaTime;
                platformVerticalSpeed += augmentValue;
                yield return null;
            }
            if(GameManager.GameRunning)
                StartCoroutine(SecondsTimer());
        }

        #endregion
        #endregion
    }
}