﻿using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class AnimatorControllerFloatParameter {

	public int NameID;

	public bool Get(Animator animator) {
		return animator.GetBool (NameID);
	}

	public void Set(Animator animator,float val) {
		animator.SetFloat (NameID,val);
	}

	public void Set(Animator animator,float val,float dampTime, float deltaTime) {
		animator.SetFloat (NameID, val, dampTime, deltaTime);
	}
}

