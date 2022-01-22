using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour {
	public GameObject en1,en2,en3;
	public Transform e1, e2, e3;
	public float cd = 1f,cdd;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		zakoSpawn();
	}

	void zakoSpawn()
	{
		cdd += 1 * Time.deltaTime;
		if (cdd >= cd)
		{
			cdd = 0;
			int b = Random.Range(1, 4);
			if (b == 1)
			{
				Instantiate(en1, e1.transform.position, Quaternion.identity);
			}
			if (b == 2)
			{
				Instantiate(en2, e2.transform.position, Quaternion.identity);
			}
			if (b == 3)
			{
				Instantiate(en3, e3.transform.position, Quaternion.identity);
			}
		}
	}
}
