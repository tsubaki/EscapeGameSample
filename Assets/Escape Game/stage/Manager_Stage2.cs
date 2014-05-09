using UnityEngine;
using System.Collections;

public class Manager_Stage2 : MonoBehaviour {

	FlagController flags;

	void Awake () {
		flags = FlagController.Instance;
		flags.changeFlagEvent += ChangeFlagValue;
	}

	void Start()
	{
		MessageController.AddAction(()=>{
			MessageController.SetText("Stage 2");
		});
	}
	
	void ChangeFlagValue (string flag) 
	{
		if( flag == "key" && flags["key"] )
		{
			MessageController.AddAction(()=>{
				MessageController.SetText("鍵を手に入れた！");
			});
		}

		if(flag == "icon" && flags["icon"])
		{
			MessageController.AddAction(()=>{
				MessageController.SetText("アイコンは駄目だ");
			});
			flags["icon"] =  false;
		}

		if(flag == "door")
		{

		   if( flags["key"] && flags["door"] ){
				MessageController.AddAction(()=>{
					MessageController.SetText("脱出した");
				}, ()=>{
					FadeCamera.Instance.FadeOut( 1, ()=>{
						Application.LoadLevel(2);
						FadeCamera.Instance.FadeIn(1, null);
					});
				});
			}else if(!flags["key"] && flags["door"] ){
				flags["door"] = false;
				MessageController.AddAction(()=>{
					MessageController.SetText("鍵がかかっている…");
				}, ()=>{
					MessageController.SetText("開くには鍵が必要だ");
				});
			}
		}
	}
}
