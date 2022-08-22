using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SelfDEstroy : MonoBehaviour {


	public float timeLive = 1;
	float time;


	void Start()
    {

		time = Time.timeSinceLevelLoad + timeLive;

    }


	// Update is called once per frame
	void Update ()
	
	{
		if (Time.timeSinceLevelLoad >= time)
		{


			Destroy(this.gameObject);
        }


	}
}
