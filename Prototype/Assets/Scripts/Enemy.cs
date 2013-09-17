using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	

	private bool moveToRight = true;
	bool moveDown = false;
	private float startTime;
	public float t;
    float xpos = 18.0f;
	float sxpos = -18.0f;

	float x = 18.0f;
	float y = 10.0f;

	Vector3 projectPos;
	// Use this for initialization
	void Start () 
	{
		this.startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		t= (Time.time - startTime) * 1.0f;
	
			if (moveToRight)
	            x = Mathf.Lerp(sxpos, xpos, t);
	        else
	            x = Mathf.Lerp(xpos, sxpos, t);
	        
	        if (x > xpos)
	        {	
	            moveToRight = false;
				this.startTime = Time.time;   
	        }
	        else if (x < sxpos)
	        {
	            moveToRight = true;
	            this.startTime = Time.time;
	        }
			
			else if (x == xpos)
			{
				moveDown = true;
				y= Mathf.Lerp(y,y -= 3.0f,t);
				moveToRight = false;
				this.startTime = Time.time;
			}
			
			else if (x==sxpos)
			{
				y= Mathf.Lerp(y,y -= 1.0f,t);
				moveToRight= true;
				this.startTime = Time.time;
			}
	   		

        this.transform.position = new Vector3(x, y, this.transform.position.z);
		
	}
	
	void FixedUpdate()
	{
		if(this.transform.position.y == -10f)
		{
			y=10;
		}
	}
		
	
	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.CompareTag("Lazer"))
		{
			Destroy(this.gameObject);
		}
		
		if(collider.gameObject.CompareTag("Player"))
		{
			Destroy(this.gameObject);
		}
		
		if(collider.gameObject.CompareTag("Block"))
		{
			 transform.rotation = Quaternion.AngleAxis(Mathf.Lerp(0,180,Time.time/ 2), transform.up);
		Debug.Log ("rotation");
		}
	}
	

}
