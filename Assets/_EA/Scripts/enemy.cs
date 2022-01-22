using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	//public GameObject gm;
	Rigidbody2D body;
	public float speed=1,hp=100f,atk=5;

	public int getGold = 1;
	bool hit=false;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();


	}
	void Update(){
		body.velocity = transform.right * -speed;
		//transform.Rotate(Vector3.back *(3600* Time.deltaTime), Space.World);
		if (hp <= 0) {
			
		//	gm.GetComponent<gameManage> ().g++;
			Destroy (this.gameObject);
		}
		if (hit) {
			body.velocity = Vector3.zero;
			transform.Rotate(Vector3.back *(3600* Time.deltaTime), Space.World);
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "bullet") {
			hp -= other.GetComponent<bullet> ().atk;
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "bullet_s") {
			
			hp -= other.GetComponent<bullet> ().atk;

		}else if(other.gameObject.tag!="enemy") {
			hit = true;
		}
	}
}
