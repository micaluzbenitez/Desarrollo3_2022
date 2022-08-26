using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Toolbox.Lerpers
{
    public class Vector2Lerper : Lerper<Vector2>
    {
        /// <summary>
        /// Call this to set vector2 lerper values, auto start if you want the timer to start or not yet
        /// </summary>
        public override void SetLerperValues(Vector2 start, Vector2 end, float time, LERPER_TYPE lerperType, bool autoStart = false)
        {
            SetValues(start, end, time, lerperType, autoStart);
        }

        /// <summary>
        /// Call this to get the vector2 lerper actual value
        /// </summary>
        public override Vector2 GetValue()
        {
            return currentValue;
        }

        /// <summary>
        /// Update vector2 lerper position
        /// </summary>
        protected override void UpdateCurrentPosition(float percentage)
        {
            currentValue = Vector2.Lerp(start, end, percentage);
        }

        /// <summary>
        /// Check if the vector2 lerper has reached or not
        /// </summary>
        protected override bool CheckReached()
        {
            if (currentValue == end) return true;
            else return false;
        }
    }
}

/* Test vector2 lerper:
public class test : MonoBehaviour
{
    public float time = 0;
    private Vector2Lerper vector2Lerper = new Vector2Lerper();

    private void Awake()
    {
        vector2Lerper.SetLerperValues(Vector2.zero, new Vector2(8, 15.4f), time, Lerper<Vector2>.LERPER_TYPE.STEP_SMOOTH, true);
    }

    private void Update()
    {
        if (vector2Lerper.Active) vector2Lerper.UpdateLerper();

        if (Input.GetKeyDown(KeyCode.M)) vector2Lerper.ActiveLerper();
        if (Input.GetKeyDown(KeyCode.N)) vector2Lerper.DesactiveLerper();

        Debug.Log(vector2Lerper.GetValue());
    }
}
 */