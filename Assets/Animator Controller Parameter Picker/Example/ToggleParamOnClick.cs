using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ToggleParamOnClick : MonoBehaviour, IPointerClickHandler {

	public AnimatorControllerBoolParameter Param;

	Animator animator;

	void Awake() {
		animator = GetComponent<Animator> ();
	}

	public void OnPointerClick (PointerEventData eventData) {
		Param.Set (animator, !Param.Get (animator));
	}
}
