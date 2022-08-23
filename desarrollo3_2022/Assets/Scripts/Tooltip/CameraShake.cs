using UnityEngine;

namespace Toolbox
{
	public class CameraShake : MonoBehaviour
	{
		[Header("Camera data"), Tooltip("Transform of the camera to shake, grabs the gameObject's transform if null")]
		[SerializeField] private Transform mainCamera = null;
		[Tooltip("How long the camera should shake for")]
		[SerializeField] private float shakeDuration = 0f;
		[Tooltip("Amplitude of the shake, a larger value shakes the camera harder")]
		[SerializeField] private float shakeAmount = 0.7f;
		[Tooltip("Rate at which shake decreases")]
		[SerializeField] private float decreaseFactor = 1.0f;

		/// Camera original position
		private Vector3 originalPos = Vector3.zero;
		/// If the camera is shaking or not
		private bool shake = false;
		/// Shake timer
		private float shakeTimer = 0;

		/// <summary>
		/// Camera shake
		/// </summary>
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.M)) StartShake();

			if (shake)
			{
				if (shakeTimer > 0)
				{
					mainCamera.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
					shakeTimer -= Time.deltaTime * decreaseFactor;
				}
				else
				{
					shakeTimer = 0f;
					mainCamera.localPosition = originalPos;
					shake = false;
				}
			}
		}

		/// <summary>
		/// Call this to active the camera shake
		/// </summary>
		public void StartShake()
        {
			originalPos = mainCamera.localPosition;
			shakeTimer = shakeDuration;
			shake = true;
		}
	}
}