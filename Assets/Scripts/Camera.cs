using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public float RotationSPeed = 1;
	//Es el objeto donde va la camera
	public Transform Target;
	//El objeto jugador
	public Transform Player;
	float mouseX;
	float mouseY;

	// Use this for initialization
	void Start () {

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	
	}
	
	// Update is called once per frame
	void Update () {
		//Se comprueba el control de la camera
		CameraControl();
	}

	void CameraControl()
    {
		//La camera funciona según los ejes del taón
		mouseX += Input.GetAxis("Mouse X") * RotationSPeed;
		mouseY -= Input.GetAxis("Mouse Y") * RotationSPeed;
		//Se bloquea la camera para que no pueda ir más arriabd e lo que deberñia
		 mouseY = Mathf.Clamp(mouseY, -80, 80);
		//Se rota el cuerpo del jugador
        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        Player.rotation = Quaternion.Euler(0, mouseX, 0);


    }


}
