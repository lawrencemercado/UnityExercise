using UnityEngine;

public class Player : MonoBehaviour {

	public static float distanceTraveled;
	float time = 25f;
	public float acceleration =5;
	public Vector3 jumpVelocity;
	private bool touchingPlatform;
	public static float score = 0;
	void Update () {
		time += Time.deltaTime;
		Debug.Log("time:" + time);
		if(transform.position.y>0 && time >=30f)
		{	Debug.Log("time:" + time);
			if(touchingPlatform && Input.GetButtonDown("Jump")){
			rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
				
		}
		distanceTraveled = transform.localPosition.x;
		
		//Debug.Log("score:" + score);
		}
		
		
		if(transform.position.y <-5)
		{
			
		}
	}

	void FixedUpdate () {
		if(touchingPlatform && time >=30f){
			rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
			score = score + Time.deltaTime * 100;
		}
		
		else if (transform.position.y >=-5 && time >=30f)
		{
			score = score + Time.deltaTime * 100;
		}
		
	}

	void OnCollisionEnter () {
		touchingPlatform = true;
	}

	void OnCollisionExit () {
		touchingPlatform = false;
	}
}