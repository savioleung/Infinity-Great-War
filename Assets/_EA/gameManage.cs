using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameManage : MonoBehaviour {
	public Text enetxt,gt,wt,myt1,myt2,t1t1,t1t2,t2t1,t2t2,t3t1,t3t2;
	public GameObject enemy1,enemy2,enemy3,boss,t1,t2,t3,hpp,start,menu,b1,b2,b3,b4,g1,g11,g2,g3,g4;
	public float enemyNo=8,x = 30.0f,bs=1;
	public int g=0,w=0;
	bool game;
	//GameObject[] enemys;
	// Use this for initialization
	void Start () {
		start.SetActive (true);
//		for (int i = 0; i < 10; i++) {
//			Instantiate (enemy1, new Vector3 (Random.Range (14.0f, 30.0f), Random.Range (-6.0f, 6.0f), -100), Quaternion.identity);
//		}
		if (PlayerPrefs.HasKey("myatk")) {
			b1.GetComponent<bullet> ().atk = PlayerPrefs.GetFloat ("myatk");
			b2.GetComponent<bullet> ().atk = PlayerPrefs.GetFloat ("t1atk");
			b3.GetComponent<bullet> ().atk = PlayerPrefs.GetFloat ("t2atk");
			b4.GetComponent<bullet> ().atk = PlayerPrefs.GetFloat ("t3atk");
			g1.GetComponent<mygun> ().cd = PlayerPrefs.GetFloat ("myspd");
			g11.GetComponent<mygun> ().cd = PlayerPrefs.GetFloat ("myspd");
			g2.GetComponent<autogun1> ().cd = PlayerPrefs.GetFloat ("t1spd");
			g3.GetComponent<autogun1> ().cd = PlayerPrefs.GetFloat ("t2spd");
			g4.GetComponent<autogun1> ().cd = PlayerPrefs.GetFloat ("t3spd");
		} 

		if (PlayerPrefs.HasKey ("Gold")) {
			g = PlayerPrefs.GetInt ("Gold");
		} else {
			g = 50;
		}
	}

	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetInt ("Gold", g);
		if (hpp.GetComponent<hp> ().wallhp <= 0) {
			GameObject[] balll = GameObject.FindGameObjectsWithTag ("bullet");
			for(int i=0; i< balll.Length; i++)
			{
				Destroy(balll[i]);
			}
		}

		gt.text = g.ToString ()+"G";
		wt.text = "wave"+w.ToString ();
		if (game) {
			GameObject[] enemys = GameObject.FindGameObjectsWithTag ("enemy");
			if (enemys.Length <= 0) {
				w++;

				enemyNo += Random.Range (1, 3);
				x += Random.Range (2, 4);
				if ((w%50) == 0) {
					for(int i=0; i< bs; i++)
					{
						Instantiate (boss, new Vector3 (Random.Range(16,16+(9*bs)), 0, -100), Quaternion.identity);

					}
					bs++;
										
				} else {
					for (int i = 0; i < enemyNo; i++) {
						if (w <= 10) {
							Instantiate (enemy1, new Vector3 (Random.Range (14.0f, x), Random.Range (-6.0f, 6.0f), -100), Quaternion.identity);

						
						} else if (w <= 20) {
							int b = Random.Range (1, 3);
							if (b == 1) {
								Instantiate (enemy1, new Vector3 (Random.Range (14.0f, x), Random.Range (-6.0f, 6.0f), -100), Quaternion.identity);
							}
							if (b == 2) {
								Instantiate (enemy2, new Vector3 (Random.Range (14.0f, x), Random.Range (-6.0f, 6.0f), -100), Quaternion.identity);
							}

						} else {
							int b = Random.Range (1, 4);
							if (b == 1) {
								Instantiate (enemy1, new Vector3 (Random.Range (14.0f, x), Random.Range (-6.0f, 6.0f), -100), Quaternion.identity);
							}
							if (b == 2) {
								Instantiate (enemy2, new Vector3 (Random.Range (14.0f, x), Random.Range (-6.0f, 6.0f), -100), Quaternion.identity);
							}
							if (b == 3) {
								Instantiate (enemy3, new Vector3 (Random.Range (14.0f, x), Random.Range (-6.0f, 6.0f), -100), Quaternion.identity);
							}
						}
					}
				}
			}
		

			enetxt.text = "Enemy:"+enemys.Length.ToString ();
			for (int i = 0; i < enemys.Length; i++) {
				if (enemys [i].GetComponent<enemy> ().hp <= 0) {
					g += enemys [i].GetComponent<enemy> ().getGold;

				}
			}
		}
		myt1.text = b1.GetComponent<bullet> ().atk.ToString ();
		t1t1.text = b2.GetComponent<bullet> ().atk.ToString ();
		t2t1.text = b3.GetComponent<bullet> ().atk.ToString ();
		t3t1.text = b4.GetComponent<bullet> ().atk.ToString ();
		myt2.text = g1.GetComponent<mygun> ().cd.ToString ();
		t1t2.text = g2.GetComponent<autogun1> ().cd.ToString ();
		t2t2.text = g3.GetComponent<autogun1> ().cd.ToString ();
		t3t2.text = g4.GetComponent<autogun1> ().cd.ToString ();
	}

	public void addT(){
		if (g >= 20) {
			g -= 20;
			int a = Random.Range (1, 4);
			Debug.Log (a);
			if (a == 1) {
				Instantiate (t1, new Vector3 (Random.Range (-11f, -9f), Random.Range (-3f, 3f), -100), Quaternion.identity);
			}
			if (a == 2) {
				Instantiate (t2, new Vector3 (Random.Range (-11f, -9f), Random.Range (-3f, 3f), -100), Quaternion.identity);
			}
			if (a == 3) {
				Instantiate (t3, new Vector3 (Random.Range (-11f, -9f), Random.Range (-3f, 3f), -100), Quaternion.identity);
			}
		}
	}	public void addHP(){
		if (g >= 50) {
			g -= 50;
			hpp.GetComponent<hp>().wallhp+=100;
		}
	}
	public void Startgame(){
		game = true;
		start.SetActive (false);
	}
	public void loadgame(){
		SceneManager.LoadScene (0);
	}
	public void showsop(){
		menu.SetActive (true);

	}
	public void closesop(){
		menu.SetActive (false);
	}
	public void MytAtkUP(){
		if (g >= 50) {
			g -= 50;		
			b1.GetComponent<bullet> ().atk++;
			//PlayerPrefs.SetFloat ("myatk", b1.GetComponent<bullet> ().atk);
		}
	}
	public void MytSPDUP(){
		if (g >= 50) {
			g -= 50;		
			g1.GetComponent<mygun> ().cd -= 0.02f;
			g11.GetComponent<mygun> ().cd -= 0.02f;
			//PlayerPrefs.SetFloat ("myspd", g1.GetComponent<mygun> ().cd);
		}
	}
	public void t1AtkUP(){
		if (g >= 50) {
			g -= 50;		
			b2.GetComponent<bullet> ().atk++;
		//	PlayerPrefs.SetFloat ("t1atk", b2.GetComponent<bullet> ().atk);
		}
	}
	public void t1SPDUP(){
		if (g >= 50) {
			g -= 50;		
			g2.GetComponent<autogun1> ().cd -= 0.02f;
			//PlayerPrefs.SetFloat ("t1spd", g2.GetComponent<autogun1> ().cd);

		}
	}
	public void t2AtkUP(){
		if (g >= 50) {
			g -= 50;		
			b3.GetComponent<bullet> ().atk++;
			//PlayerPrefs.SetFloat ("t2atk", b3.GetComponent<bullet> ().atk);
		}
	}
	public void t2SPDUP(){
		if (g >= 50) {
			g -= 50;		
			g3.GetComponent<autogun1> ().cd -= 0.02f;
			//PlayerPrefs.SetFloat ("t2spd", g3.GetComponent<autogun1> ().cd);

		}
	}
	public void t3AtkUP(){
		if (g >= 50) {
			g -= 50;		
			b4.GetComponent<bullet> ().atk++;
			//PlayerPrefs.SetFloat ("t3atk", b4.GetComponent<bullet> ().atk);
		}
	}
	public void t3SPDUP(){
		if (g >= 50) {
			g -= 50;		
			g4.GetComponent<autogun1> ().cd -= 0.02f;
			//PlayerPrefs.SetFloat ("t3spd", g4.GetComponent<autogun1> ().cd);

		}
	}


}
