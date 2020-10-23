using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public float mouseSensitivity = 10f;
	public Transform camera;

	float xRotation = 0f;
	
	void Start(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	void Update(){
		float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		camera.localRotation = Quaternion.Euler(xRotation, 0, 0);

		transform.Rotate(Vector3.up*mouseX);

	}
}
