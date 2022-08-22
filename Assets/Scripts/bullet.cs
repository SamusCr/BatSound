using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {




	public GameObject soundWave;
	public Material Wall1;
	//Lo que dura el mure invisible, se le pasa al CountCenter para poder
	public float DurationVisible = 1 ;

	//ContactPoint collision_Point;


	// Use this for initialization
	void Start () 
	{
		
		
	}

	void Update()
    {

		
	}
	
	// Update is called once per frame
	
	void OnCollisionEnter(Collision collision)
    {
		//Cuando la bala toca una pared y i no hay otra onda
		if (collision.gameObject.tag != "bullet" && collision.gameObject.tag != "weave" && collision.gameObject.tag != "Target")
		{

			//Se crea una onda
			Instantiate(soundWave, this.gameObject.transform.position, this.gameObject.transform.rotation);

			//Pasarle la informacion de donde ha golpeado la bala
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CountCenter>().AddCenter(Wall1, this.gameObject.transform.position, Time.timeSinceLevelLoad + DurationVisible);
			//Se destruye la bala
			Destroy(this.gameObject);

		}
	}
}
