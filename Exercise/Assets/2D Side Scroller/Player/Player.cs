using UnityEngine;

public class Player : MonoBehaviour {

	public static float distanceTraveled;
	float time = 25f;
	public float acceleration =5;
	public Vector3 jumpVelocity;
	private bool touchingPlatform;
	private bool doublejump = false;
	public static float score = 0;
	public bool reset;
	
	void Start()
	{
		reset = true;
	}
	void Update () {
		if(reset)
		{
			time += Time.deltaTime;
			Debug.Log("time:" + time);
			
			if(transform.position.y>0 && time >=30f)
			{	Debug.Log("time:" + time);
				Jump();
			distanceTraveled = transform.localPosition.x;
			
			//Debug.Log("score:" + score);
			}
			
			else if(transform.position.y <=-20)
			{
				Application.LoadLevel(2);
				reset = false;
			}
			
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
	
	void Jump()
	{	foreach(Touch  touch in Input.touches)
		{
		if(touchingPlatform && touch.phase == TouchPhase.Began){
				rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);	
				doublejump = true;
				}
				
				else if(!touchingPlatform && touch.phase == TouchPhase.Began&& doublejump)
				{
					rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
					doublejump = false;
				}
		}
	}
}