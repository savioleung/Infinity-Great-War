using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mygun : MonoBehaviour
{
    public GameObject bullet, bp, bp2;
    public float speed = 1.5f, cd = 0.1f, cdd;
    private Vector3 target;

    void Start()
    {
        target = transform.position;
        cdd = 0;
    }

    void Update()
    {
        gunControl();

    }
    void gunControl()
    {
        cdd += 1 * Time.deltaTime;
        if (cdd >= cd)
        {
            cdd = 0;
            GameObject clone = Instantiate(bullet, new Vector3(bp.transform.position.x, bp.transform.position.y, bp.transform.position.z - 10), transform.rotation) as GameObject;

            //clone.transform.parent = this.transform;
            Destroy(clone, 3);
            GameObject clone2 = Instantiate(bullet, new Vector3(bp2.transform.position.x, bp2.transform.position.y, bp2.transform.position.z - 10), transform.rotation) as GameObject;
            Destroy(clone2, 3);
        }
#if UNITY_EDITOR
        Vector3 norTar = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;

        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        transform.rotation = rotation;
#else
		Touch myTouch = Input.GetTouch(0);
		Touch[] myTouches = Input.touches;
		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.touchCount <= 1|| this.tag=="gun") {
				if (Input.touches [0].phase == TouchPhase.Began || Input.touches [0].phase == TouchPhase.Moved) {
					Vector2 norTar = (Camera.main.ScreenToWorldPoint (Input.touches [0].position) - transform.position).normalized;
					float angle = Mathf.Atan2 (norTar.y, norTar.x) * Mathf.Rad2Deg;

					Quaternion rotation = new Quaternion ();
					rotation.eulerAngles = new Vector3 (0, 0, angle - 90);
					transform.rotation = rotation;
				}
			}
			if (this.tag == "gun2") {
				if (Input.touches [1].phase == TouchPhase.Began || Input.touches [1].phase == TouchPhase.Moved) {
					Vector2 norTar = (Camera.main.ScreenToWorldPoint (Input.touches [1].position) - transform.position).normalized;
					float angle = Mathf.Atan2 (norTar.y, norTar.x) * Mathf.Rad2Deg;

					Quaternion rotation = new Quaternion ();
					rotation.eulerAngles = new Vector3 (0, 0, angle - 90);
					transform.rotation = rotation;
				}
			}
			}
#endif
    }

    //		Vector2 norTar = (Camera.main.ScreenToWorldPoint(Input.touches[0].position) - transform.position).normalized;




    //if (Input.GetMouseButton(0)) {

    //			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //			target.z = transform.position.z;
    //			clone.transform.position = Vector3.MoveTowards(clone.transform.position, target, speed * Time.deltaTime);
    //}


}

