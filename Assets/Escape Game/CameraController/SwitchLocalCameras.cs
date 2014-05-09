using UnityEngine;
using System.Collections;

public class SwitchLocalCameras : SingletonMonoBehaviour<SwitchLocalCameras>
{
	public Camera[] cameras;
	[Range(0, 12)]
	public int
		current = 0;

	void Start ()
	{
		SetCurrentCamera ();
	}

	[ContextMenu("collection camera")]
	public void ExecuteCollectionCamera ()
	{
		var allCameras = FindObjectsOfType<Camera> ();
		cameras = System.Array.FindAll<Camera> (allCameras, (item) => item.CompareTag ("SceneCamera"));
	}

	public void ChangeCamera (int no)
	{
		current = no;
		FadeCamera.Instance.FadeOut (0.3f, () =>
		{
			for (int i=0; i< cameras.Length; i++) {
				cameras [i].gameObject.SetActive (i == current);
			}
			FadeCamera.Instance.FadeIn (0.3f, null);
		});
	}

	void SetCurrentCamera ()
	{
		if (cameras.Length == 0)
			return;
		current = Mathf.Min (current, cameras.Length - 1);
		
		for (int i=0; i< cameras.Length; i++) {
			cameras [i].gameObject.SetActive (i == current);
		}
	}

	void OnValidate ()
	{
		SetCurrentCamera ();

		if (current == 0)
			foreach (var item in cameras) {
				item.gameObject.SetActive (true);
			}
	}
}
