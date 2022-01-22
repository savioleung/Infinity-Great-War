using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour {
	public GameObject hpbar,gover;
	public float wallmaxhp=0,wallhp=0,myhp,z=0;
	// Use this for initialization
	void Start () {
		wallhp = wallmaxhp;
		myhp = wallhp / wallmaxhp;
		gover.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		myhp = wallhp / wallmaxhp;
		hpbar.transform.localScale = new Vector3 (1, myhp, 1);
		if (wallhp > wallmaxhp) {
			wallhp = wallmaxhp;
		}
		if (wallhp <= 0) {
			gover.SetActive (true);
		}
	}

	void OnTriggerEnter2D(Collider2D other){		
		if (other.gameObject.tag == "enemy") {
			wallhp -= other.gameObject.GetComponent<enemy> ().atk;
			myhp = wallhp / wallmaxhp;
			myhp = wallhp / wallmaxhp;
			hpbar.transform.localScale = new Vector3 (1, myhp, 1);

			Destroy (other.gameObject,0.2f);
		}
	}
}
