using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	public GameObject panel;
	public GameObject blanca;
	public GameObject negra;
	public GameObject corchea;
	public Button b;
	public Button n;
	public Button c;
	public Button play;
	public Button delete;
	public AudioSource octav;
	public AudioSource negr;
	public AudioSource blan;
	int m_IndexNumber=0;

	int counter = 0;
	int counter2 = 0;
	GameObject half;
	GameObject quarter;
	GameObject eighth;


	void Start () {
	}

	IEnumerator Length()
	{
		
		int num = panel.transform.childCount;
		string tag;

		for (int i = 0; i < counter2; i++)
		{
			tag = panel.transform.GetChild (i).gameObject.tag;	
			if(tag == "half"){blan.Play ();
				yield return new WaitForSeconds(2);
			}
			if(tag == "quarter"){negr.Play ();
				yield return new WaitForSeconds(1);
			}
			if(tag == "eighth"){octav.Play ();
				yield return new WaitForSeconds(0.5f);
			}
		}
	}

	void Update () {
		
	}

	public void PressBlanca()
	{
		Debug.Log ("Blanca");

		if ((8-counter)>=4) {
			counter = counter + 4;
			counter2 = counter2 + 1;
			half = (GameObject) Instantiate(blanca);
			half.transform.parent = panel.transform;
			transform.SetSiblingIndex(m_IndexNumber++);
			Debug.Log("Sibling Index : " + half.transform.GetSiblingIndex());
		}


	}

	public void PressNegra()
	{
		Debug.Log ("Negra");

		if ((8-counter)>=2) {
			counter = counter + 2;
			counter2 = counter2 + 1;
			quarter = (GameObject) Instantiate(negra);
			quarter.transform.parent = panel.transform;
			transform.SetSiblingIndex(m_IndexNumber++);
			Debug.Log("Sibling Index : " + quarter.transform.GetSiblingIndex());
		}


	}

	public void PressCorchea()
	{
		Debug.Log ("Corchea");

		if ((8-counter)>=1) {
			counter = counter + 1;
			counter2 = counter2 + 1;
			eighth = (GameObject) Instantiate(corchea);
			eighth.transform.parent = panel.transform;
			transform.SetSiblingIndex(m_IndexNumber++);
			Debug.Log("Sibling Index : " + eighth.transform.GetSiblingIndex());
		}


	}
		

	public void PressPlay()
	{
		StartCoroutine( Length() );
	}

	public void PressDelete()
	{
		int num = panel.transform.childCount;
		string tag = panel.transform.GetChild (num - 1).gameObject.tag;
		Debug.Log ("Tag " + tag);

		if(tag == "half"){counter = counter - 4;counter2 = counter2 - 1;}
		if(tag == "quarter"){counter = counter - 2;counter2 = counter2 - 1;}
		if(tag == "eighth"){counter = counter - 1;counter2 = counter2 - 1;}
		transform.SetSiblingIndex(m_IndexNumber--);

		Destroy(panel.transform.GetChild(num-1).gameObject);

	}

	public void PressRetro()
	{
		GameObject g = new GameObject();
	

		for(int i = panel.transform.childCount-1; i >= 0; i--)
		{
			
			panel.transform.GetChild (i).transform.parent = g.transform;

		}

		for (int i = 0; i < counter2; i++)
		{
			g.transform.GetChild (0).transform.parent = panel.transform;
		}
	}
}
