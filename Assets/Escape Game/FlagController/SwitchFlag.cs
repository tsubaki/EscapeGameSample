using UnityEngine;
using System.Collections;

public class SwitchFlag : MonoBehaviour
{

	public enum SwitchType
	{
		Toggle,
		On,
		Off
	}

	public SwitchType switchType = SwitchType.On;

	void OnMouseDown ()
	{
		switch (switchType) {
		case SwitchType.Off:
			FlagController.Instance [name] = false;
			break;
		case SwitchType.On:
			FlagController.Instance [name] = true;
			break;
		case SwitchType.Toggle:
			FlagController.Instance [name] = !FlagController.Instance [name];
			break;
		}

	}
}
