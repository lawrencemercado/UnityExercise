using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {
	
	public float projectileSpeed = 10.0f;
	public GameObject Enemy;
	public GameObject Block;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);
		
		if(transform.position.y > 15)
			DestroyObject(this.gameObject);
	
	
	}
	
	void OnTriggerEnter(Collider collider)
	{	
		if(collider.gameObject.CompareTag("Enemy"))
		{	 //Player.score = Player.score + 1;
			Destroy(this.gameObject);
		}
		
		if(collider.gameObject.CompareTag("Block"))
		{	 //Player.score = Player.score + 1;
			Destroy(this.gameObject);
		}
	}
	
	
}