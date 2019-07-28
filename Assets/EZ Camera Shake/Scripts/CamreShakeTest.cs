using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CamreShakeTest : MonoBehaviour {

 	public void FairyRipShake ()
    {
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f,1f);
	}
}
