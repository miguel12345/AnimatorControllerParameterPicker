using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SetTriggerParamOnClick : MonoBehaviour, IPointerClickHandler {

	public AnimatorControllerTriggerParameter Param;

	Animator animator;

	void Awake() {
		animator = GetComponent<Animator> ();
	}

	public void OnPointerClick (PointerEventData eventData) {
		Param.Set (animator);
	}
}
