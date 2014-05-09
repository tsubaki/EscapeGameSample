using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

	public int switchCameraNo = 1;

	void OnMouseDown()
	{
		SwitchLocalCameras.Instance.ChangeCamera(switchCameraNo);
	}
}
