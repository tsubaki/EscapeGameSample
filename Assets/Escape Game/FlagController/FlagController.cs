using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlagController : SingletonMonoBehaviour<FlagController> 
{
	public bool this [string key] {
		get {
			if( !flagDictionary.ContainsKey(key) ){
				flagDictionary.Add(key, false);
			}
			return flagDictionary[key];
		}
		set {
			flagDictionary[key] = value;
			if( changeFlagEvent != null)
				changeFlagEvent(key);
		}
	}

	public delegate void EventChangeFlag(string flagName );
	private Dictionary<string, bool> flagDictionary = new Dictionary<string, bool>();

	public event EventChangeFlag changeFlagEvent;

	void OnDestroy()
	{
		changeFlagEvent = null;
	}
}