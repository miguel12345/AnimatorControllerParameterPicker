using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class AnimatorControllerFloatParameter {

	public int NameID;

	public float Get(Animator animator) {
		return animator.GetFloat (NameID);
	}

	public void Set(Animator animator,float val) {
		animator.SetFloat (NameID,val);
	}

	public void Set(Animator animator,float val,float dampTime, float deltaTime) {
		animator.SetFloat (NameID, val, dampTime, deltaTime);
	}
}

