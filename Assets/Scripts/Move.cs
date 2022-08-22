using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Move : MonoBehaviour {
	float move_X;
	float move_z;
	public GameObject bullet;
	public GameObject taret;
	public Camera PlayerCamera;
	public float bulletVelocity = 50;
	public float moveSpeed = 50;
	// Use this for initialization
	void Start () {

		PlayerCamera = Camera.FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
	
	{
		//Comprobar si se esta presionadno el boton de mover
		move();
		//Comprobar si se esta presionadno el boton de disparar
		CheckInput();

	}


	private void CheckInput()
    {
		//Boton de disparar presionado

		if(Input.GetMouseButtonUp(0))
        {
			//Buscar si ya se creado un una bala, si existe una bala no crear otra
			if (!GameObject.FindWithTag("bullet"))
			{

				//Crear la bala
				GameObject BulletObject = Instantiate(bullet, transform.position + PlayerCamera.transform.forward +new Vector3(1,1,1), Quaternion.identity);
				//Dirección que irá la bala
				BulletObject.transform.forward = PlayerCamera.transform.forward;
				//Darle fuerza a la bala
				BulletObject.GetComponent<Rigidbody>().velocity = BulletObject.transform.forward * bulletVelocity;
			}
        }
		
	}

	private void move()
    {
		//Control de movimiento, moverse dependiendo del botón presionado
		move_X = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		move_z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

		transform.Translate(new Vector3(move_X, 0, move_z));

	}
}
