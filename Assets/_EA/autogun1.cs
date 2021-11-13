using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autogun1 : MonoBehaviour {
	public GameObject bullet,bp,bp2,bp3,flo;
	public float speed = 1.5f,cd = 0.3f,cdd,matk,mbspd;
	private Vector3 target;

	private GameObject nearObj;
	GameObject targetObj = null; 

	void Start () {
		nearObj	 = serchTag(gameObject, "enemy");
		target = transform.position;
		cdd = 0;
		flo.SetActive (false);
	}

	void Update () {		
		cdd +=1* Time.deltaTime;
		if (cdd >= cd) {
			cdd = 0;
			GameObject clone;
			if (bp2 != null) {
				 clone = Instantiate (bullet, new Vector3 (bp3.transform.position.x, bp2.transform.position.y, bp2.transform.position.z - 10), bp3.transform.rotation) as GameObject;
//				clone.GetComponent<bullet> ().atk = matk;
//				clone.GetComponent<bullet> ().speed = mbspd;
				Destroy (clone, 3);
				 clone = Instantiate (bullet, new Vector3 (bp2.transform.position.x, bp3.transform.position.y, bp3.transform.position.z - 10), bp2.transform.rotation) as GameObject;
//				clone.GetComponent<bullet> ().atk = matk;
//				clone.GetComponent<bullet> ().speed = mbspd;
				Destroy (clone, 3);
			}
			clone = Instantiate (bullet, new Vector3 (bp.transform.position.x, bp.transform.position.y, bp.transform.position.z - 10), bp.transform.rotation) as GameObject;
//			clone.GetComponent<bullet> ().atk = matk;
//			clone.GetComponent<bullet> ().speed = mbspd;
			//clone.transform.parent = this.transform;
			Destroy (clone, 3);
		}
		if (nearObj == null) {
			nearObj = serchTag (gameObject, "enemy");
		}
		Vector3 norTar = (nearObj.transform.position - transform.position).normalized;
		float angle = Mathf.Atan2 (norTar.y, norTar.x) * Mathf.Rad2Deg;

		Quaternion rotation = new Quaternion ();
		rotation.eulerAngles = new Vector3 (0, 0, angle-90);
		transform.rotation = rotation;

		//shoot



	}   

	GameObject serchTag(GameObject nowObj,string tagName){
		float tmpDis = 0;           
		float nearDis = 0;  
		//string nearObjName = "";   
		GameObject[] balls = GameObject.FindGameObjectsWithTag(tagName);
		//int index = 0;

		//nearObj = serchTag(gameObject, "ball");
		if (balls != null) {
			foreach (GameObject obs in  balls) {

				tmpDis = Vector3.Distance (obs.transform.position, nowObj.transform.position);



				if (nearDis == 0 || nearDis > tmpDis) {
					nearDis = tmpDis;
					//nearObjName = obs.name;
					targetObj = obs;
				}

			}
		} 
		if (balls == null) {
			targetObj = flo;
		}
		//return GameObject.Find(nearObjName);
		return targetObj;

	}
}
