using UnityEngine;
using System.Collections;

public class ScoreGui : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UILabel s = GameObject.Find("Score").GetComponent<UILabel>();
		s.text = Player.score.ToString();
	}
}
