using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerlessAR : MonoBehaviour {
    /// <summary>
    /// Gyroscope
    /// </summary>
    private Gyroscope gyro;
	private GameObject cameraContainer;
	private Quaternion rotation;

	/// <summary>
	/// Camera
	/// </summary>
	private WebCamTexture cam;
	public RawImage background;
	public AspectRatioFitter fit;

	private bool arReady = false;

	// Use this for initialization
	void Start () {
#if !UNITY_EDITOR
		/// Check if we support both services
		/// Gyroscope
		if (!SystemInfo.supportsGyroscope) {
			Debug.Log("Device has no gyroscope.");
			return;
		}

		/// Back Camera Service
		for (int i = 0; i < WebCamTexture.devices.Length; i++) {
            if (!WebCamTexture.devices[i].isFrontFacing) {
                cam = new WebCamTexture(WebCamTexture.devices[i].name, Screen.width, Screen.height);
                break;
            }
		}

        /// If didn't find a back camera
        if (cam == null) {
            Debug.Log("Device has no back camera.");
            return;
        }

        /// Both services are supported, so let's enable them.
        cameraContainer = new GameObject("Camera Contaner");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyro = Input.gyro;
        gyro.enabled = true;
        cameraContainer.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        rotation = new Quaternion(0, 0, 1, 0); /// makes sure that it's pointing forward

        cam.Play();
        background.texture = cam;

        arReady = true;
#endif
    }

    // Update is called once per frame
    void Update () {
		if (arReady) {
            /// Update camera every single frame
            float ratio = (float)cam.width / (float)cam.height;
            fit.aspectRatio = ratio;

            float scaleY = cam.videoVerticallyMirrored ? -1.0f : 1.0f;
            background.rectTransform.localScale = new Vector3(1.0f, scaleY, 1.0f);

            int orient = -cam.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0.0f, 0.0f, orient);

            /// Update Gyroscope
            transform.localRotation = gyro.attitude * rotation;
        }
	}
}