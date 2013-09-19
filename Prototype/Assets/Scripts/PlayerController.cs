using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 20;
	public int score =0;
	public GameObject Lazer;
	public static int playerLives=3;
	public bool horizontalstop;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		

		if(Input.GetKey(KeyCode.LeftArrow))
		{		
			if(transform.position.x <= 16)
			iTween.MoveBy(gameObject,iTween.Hash("x",-Input.GetAxisRaw("Horizontal"),"easetype",iTween.EaseType.linear, "time",1,"speed",20));
			
			
		}
		
		if(Input.GetKey(KeyCode.RightArrow))
		{	if(transform.position.x >= -16)
			iTween.MoveBy(gameObject,iTween.Hash("x",-Input.GetAxisRaw("Horizontal"),"easetype",iTween.EaseType.linear, "time",1,"speed",20));
		}
		
		
		
		if(Input.GetKey(KeyCode.UpArrow))
		{	if(transform.position.y <= 10)
			iTween.MoveBy(gameObject,iTween.Hash("y",Input.GetAxisRaw("Vertical"),"easetype",iTween.EaseType.linear, "time",1,"speed",20));
		}
		
		if(Input.GetKey(KeyCode.DownArrow))
		{	if(transform.position.y >= -8)
			iTween.MoveBy(gameObject,iTween.Hash("y",Input.GetAxisRaw("Vertical"),"easetype",iTween.EaseType.linear, "time",1,"speed",20));
		}
		
		
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Vector3 projectPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
			Instantiate(Lazer, projectPos, Quaternion.identity);
		}
		
		
	}
	
	void OnTriggerEnter(Collider collide)
	{
		if(collide.gameObject.CompareTag("Enemy"))
		{
			//player life will decrement by 1 in each collision
			playerLives--;
			print("Lives : " + playerLives + "	Score : " + score);
			
			if(playerLives == 0)
			DestroyObject(this.gameObject);
		}
	}
}