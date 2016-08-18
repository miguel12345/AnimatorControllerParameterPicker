using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class AnimatorControllerTriggerParameter {

	public int NameID;

	public void Set(Animator animator) {
		animator.SetTrigger (NameID);
	}
}
