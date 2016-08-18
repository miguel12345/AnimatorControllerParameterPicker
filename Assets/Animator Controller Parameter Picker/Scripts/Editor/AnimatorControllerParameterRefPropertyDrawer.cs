using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(AnimatorControllerBoolParameter))]
[CustomPropertyDrawer(typeof(AnimatorControllerFloatParameter))]
[CustomPropertyDrawer(typeof(AnimatorControllerTriggerParameter))]
public class AnimatorControllerParameterRefPropertyDrawer : PropertyDrawer {
	
	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty(position, label, property);

		MonoBehaviour targetMonoBehaviour = (MonoBehaviour) property.serializedObject.targetObject;
		var animator = targetMonoBehaviour.GetComponent<Animator> ();


		// Draw label
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);


		if (animator == null) {
			EditorGUILayout.HelpBox("No Animator component found!", MessageType.Warning);
			EditorGUI.EndProperty();
			return;
		}

		var propertyType = property.type;
		bool isBoolParameter = propertyType == typeof(AnimatorControllerBoolParameter).Name;
		bool isFloatParameter = propertyType == typeof(AnimatorControllerFloatParameter).Name;
		bool isTriggerParameter = propertyType == typeof(AnimatorControllerTriggerParameter).Name;

		var NameIDProperty = property.FindPropertyRelative ("NameID");
		List<AnimatorControllerParameter> animatorParameters = new List<AnimatorControllerParameter> ();


		int parameterCount = animator.parameterCount;
		for (int i = 0; i < parameterCount; i++) {
			var parameter = animator.GetParameter (i);
			if (parameter.type == AnimatorControllerParameterType.Bool && isBoolParameter) {
				animatorParameters.Add (parameter);
			}
			else if (parameter.type == AnimatorControllerParameterType.Float && isFloatParameter) {
				animatorParameters.Add (parameter);
			}
			else if (parameter.type == AnimatorControllerParameterType.Trigger && isTriggerParameter) {
				animatorParameters.Add (parameter);
			}
		}

		List<string> animatorParameterNames = new List<string> ();
		int currentlySelectedParameterIndex = 0;

		for (int i = 0; i < animatorParameters.Count; i++) {
			animatorParameterNames.Add (animatorParameters [i].name);
			if (NameIDProperty.intValue == animatorParameters [i].nameHash) {
				currentlySelectedParameterIndex = i;
			}
		}

		if (animatorParameterNames.Count == 0) {
			var warningText = string.Format ("No {0} parameters found in the animator", isBoolParameter ? "Bool" : (isFloatParameter ? "Float" : "Trigger"));
			EditorGUILayout.HelpBox(warningText, MessageType.Warning);
		} else {
			int selectedIndex = EditorGUI.Popup(position,currentlySelectedParameterIndex, animatorParameterNames.ToArray());
			NameIDProperty.intValue = animatorParameters[selectedIndex].nameHash;
		}

		EditorGUI.EndProperty();
	}

}
