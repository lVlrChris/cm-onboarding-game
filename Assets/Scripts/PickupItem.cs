﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupItem : MonoBehaviour {
		
	private PlayerInputActions _inputActions;
	private bool _carried = false;
	private GameObject _nearbyPlayer = null;

	private AudioSource[] sounds;
	private AudioSource pickupSound;
	private AudioSource dropSound;
	private Rigidbody _rigidbody;

	void Awake() {
		_inputActions = new PlayerInputActions();
		_inputActions.PlayerControls.Interact.performed += Pickup;
		sounds = GetComponents<AudioSource>();
		pickupSound = sounds[0];
		dropSound = sounds[1];
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			_nearbyPlayer = other.gameObject;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			_nearbyPlayer = null;
		}
	}

	public void Pickup(InputAction.CallbackContext ctx) {
	    if (_nearbyPlayer!= null && !_carried) {
		    if (_nearbyPlayer.GetComponent<PickupController>().Pickup(this)) {
			    _rigidbody.isKinematic = true;
			    _carried = true;
				pickupSound.Play();
		    }
	    }
    }

    public void Drop() {
	    _carried = false;
		dropSound.Play();
		_rigidbody.isKinematic = false;
    }
    
    private void OnEnable() {
	    _inputActions.Enable();
    }
    
    private void OnDisable() {
	    _inputActions.Disable();
    }
}

