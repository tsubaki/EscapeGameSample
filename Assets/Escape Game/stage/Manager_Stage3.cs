using UnityEngine;
using System.Collections;

public class Manager_Stage3 : MonoBehaviour {

	FlagController flags;

	void Awake () {
		flags = FlagController.Instance;
		flags.changeFlagEvent += ChangeFlagValue;
	}

	void Start()
	{
		MessageController.AddAction(()=>{
			MessageController.SetText("Stage 3");
		});
	}
	
	void ChangeFlagValue (string flag) 
	{
		if( (flag == "key1" || flag == "key2"))
		{
			MessageController.AddAction(()=>
			{
				MessageController.SetText("鍵を手に入れた！");
			});
		}

		if ( flag == "icon" )
		{
			if( flags["icon"] )
				MessageController.AddAction(()=>{
					MessageController.SetText("何かを手に入れた！");
				});
			else
				MessageController.AddAction(()=>{
					MessageController.SetText("何かを戻した！");
				});
		}

		if(flag == "door")
		{
			if(flags["icon"]){
				MessageController.AddAction(()=>{
					MessageController.SetText("余計なものを持っている");
				}, ()=>{
					MessageController.SetText("邪魔な物は戻せ");
				});
			}else if( flags["key1"] && flags["key2"] && flags["door"] )
			{
				MessageController.AddAction(()=>{
					MessageController.SetText("脱出した");
				}, ()=>{
					FadeCamera.Instance.FadeOut( 1, ()=>{
						Application.LoadLevel(0);
						FadeCamera.Instance.FadeIn(1, null);
					});
				});
			}else if( (!flags["key1"] || !flags["key2"] ) && flags["door"] ) {
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
