using UnityEngine;
using System.Collections;

public class MenuClick : MonoBehaviour {
	public bool press;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick()
	{	
		if(press)
		{
			Application.Quit();
		}
		else
		{
			Application.LoadLevel(1);
		}
	}
}
