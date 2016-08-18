using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class AnimatorControllerBoolParameter{
	
	public int NameID;

	public bool Get(Animator animator) {
		return animator.GetBool (NameID);
	}

	public void Set(Animator animator,bool val) {
		animator.SetBool (NameID,val);
	}
}
