using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

[RequireComponent (typeof (VRInteractiveItem))]
public class VRCalloutController : MonoBehaviour {
	// canvas that will be shown/hidden
	public Canvas canvas;

	// vr interactive item component
	VRInteractiveItem vrInteractiveItem;

	// is it showing or hidden?
	// Default value will be false
	public bool isInitiallyVisible = false;

	// activate when hovering the reticle over?
	public bool isHoverActivated = false;

	// activate when clicking?
	public bool isClickActivated = false;

	private void Awake () {
		vrInteractiveItem = GetComponent<VRInteractiveItem> ();

		canvas.enabled = isInitiallyVisible;
	}

	void OnEnable () {
		// hook on to hovering events
		if (isHoverActivated) {
			vrInteractiveItem.OnOver += ShowCanvas;
			vrInteractiveItem.OnOut += HideCanvas;
		}
		if (isClickActivated) {
			vrInteractiveItem.OnClick += ToggleCanvas;
		}
	}

	private void ToggleCanvas () {
		canvas.enabled = !canvas.enabled;
	}

	private void ShowCanvas () {
		canvas.enabled = false;
	}

	private void HideCanvas () {
		canvas.enabled = false;
	}

	void OnDisable () {
		if (isHoverActivated) {
			vrInteractiveItem.OnOver -= ShowCanvas;
			vrInteractiveItem.OnOut -= HideCanvas;
		}
		if (isClickActivated) {
			vrInteractiveItem.OnClick -= ToggleCanvas;
		}
	}
}