using UnityEngine;
using System.Collections;

public class VisibleFlag : MonoBehaviour {

	public bool enableIsVisible = true;

	void Start()
	{
		FlagController.Instance.changeFlagEvent += Handleaction;
		Handleaction(name);
	}

	void Handleaction (string changeFlagName)
	{
		if( name == changeFlagName )
		{
			if( enableIsVisible )
				gameObject.SetActive( FlagController.Instance[name] );
			else
				gameObject.SetActive( !FlagController.Instance[name] );
		}
	}
}
