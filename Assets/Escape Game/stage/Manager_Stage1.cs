using UnityEngine;
using System.Collections;

public class Manager_Stage1 : MonoBehaviour
{

	FlagController flags;

	void Awake ()
	{
		flags = FlagController.Instance;
		flags.changeFlagEvent += ChangeFlagValue;
	}

	void Start ()
	{
		MessageController.AddAction (() =>
		{
			MessageController.SetText ("Stage 1");
		}, () => {
			MessageController.SetText ("部屋ヲ脱出セヨ");
		});
	}
	
	void ChangeFlagValue (string flag)
	{
		if (flag == "key" && flags ["key"]) {
			MessageController.AddAction (() =>
			{
				MessageController.SetText ("鍵を手に入れた！");
			});
		}

		if (flag == "door") {
			if (flags ["key"] && flags ["door"]) {
				MessageController.AddAction (() => {
					MessageController.SetText ("脱出した");
				}, () => {
					FadeCamera.Instance.FadeOut (1, () =>
					{
						Application.LoadLevel (1);
						FadeCamera.Instance.FadeIn (1, null);
					});
				});
			}

			if (!flags ["key"] && flags ["door"]) {
				flags ["door"] = false;
				MessageController.AddAction (() => {
					MessageController.SetText ("鍵がかかっている…");
				}, () => {
					MessageController.SetText ("開くには鍵が必要だ");
				});
			}
		}
	}
}
