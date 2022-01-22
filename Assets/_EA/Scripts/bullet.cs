using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	//public GameObject gun;
	Vector2 v;
	Vector3 target;
	Rigidbody2D body;
	public float speed=10,atk=10;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		//Vector3 norTar = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
//		Vector3 norTar = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
//		float angle = Mathf.Atan2 (norTar.y, norTar.x) * Mathf.Rad2Deg;
////
//		Quaternion rotation = new Quaternion ();
//		rotation.eulerAngles = new Vector3 (0, 0, angle-90);
//		transform.rotation = rotation;
//		v.x= Mathf.Cos(Mathf.Deg2Rad * angle)*speed;
//		v.y= Mathf.Sin(Mathf.Deg2Rad * angle)*speed;
		body.velocity = transform.up * speed;
	}
//	void Update(){
//		body.AddForce (gun.transform.forward * speed);
//		//transform.position = new Vector3(transform.position.x+0.01f,transform.position.y,transform.position.z );
//	}
	

}
