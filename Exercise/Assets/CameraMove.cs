using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public Transform player;
	float time = 10f;
	// Use this for initialization
	void Start () {
	//player = GetComponent<GameObject>();
		iTween.LookFrom(this.gameObject, iTween.Hash("looktarget",player.transform.localPosition,"delay",5));
	}
	
	// Update is called once per frame
	void Update () {
	//iTween.LookTo(this.gameObject,player.transform.localPosition,time);
		
	}
}
