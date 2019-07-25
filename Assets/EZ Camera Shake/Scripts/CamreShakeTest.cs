using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CamreShakeTest : MonoBehaviour {

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f,1f);
        }
	}
}
