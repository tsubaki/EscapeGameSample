using UnityEngine;
using System.Collections;

public class FadeCameaCalled : MonoBehaviour {

	[Range(1, 5)]
	public float fadeoutTime = 1;

	public Texture2D texture, maskTexture;

	// Use this for initialization
	void Start () {
		var fadeCam = FadeCamera.Instance;
		if( texture != null)
			fadeCam.UpdateTexture(texture);

		if( maskTexture != null)
			fadeCam.UpdateMaskTexture(maskTexture);

		FadeCamera.Instance.FadeIn(fadeoutTime, ()=>
		{
			Destroy (this);
		});
	}

	void OnDestroy()
	{
		texture = null;
		maskTexture = null;
		Resources.UnloadUnusedAssets();
	}
}
