using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {
	public bool press;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		 UILabel s= GameObject.Find("ScoreDisplay").GetComponent<UILabel>();
		s.text = Player.score.ToString();
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
