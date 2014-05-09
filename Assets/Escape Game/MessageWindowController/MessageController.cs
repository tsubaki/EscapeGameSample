using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : SingletonMonoBehaviour<MessageController>
{
	private Queue<Action> actionQueue = new Queue<Action> ();
	public TextMesh textMesh;

	void Start ()
	{
		gameObject.SetActive (false);
	}

	void OnMouseDown ()
	{
		if (actionQueue.Count == 0) {
			gameObject.SetActive (false);
		} else {
			var action = actionQueue.Dequeue ();
			action ();
		}
	}

	public static void AddAction (params System.Action[] actions)
	{
		foreach (var action in actions) {
			Instance.actionQueue.Enqueue (action);
		}
		Instance.gameObject.SetActive (true);

		Instance.actionQueue.Dequeue () ();
	}

	public static void SetText (string text)
	{
		Instance.textMesh.text = text;
	}
}