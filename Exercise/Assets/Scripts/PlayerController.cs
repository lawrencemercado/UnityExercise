using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	
	// Player Handling
	public float gravity = 20;
	public float speed = 8;
	public float acceleration = 30;
	public float jumpHeight = 12;
	
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	private PlayerPhysics playerPhysics;
	

	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	
	void Update () {
		// Reset acceleration upon collision
		if (playerPhysics.movementStopped) {
			targetSpeed = 0;
			currentSpeed = 0;
		}
		
		// If player is touching the ground
		if (playerPhysics.grounded) {
			amountToMove.y = 0;
			
			// Jump
			if (Input.GetButtonDown("Jump")) {
				amountToMove.y = jumpHeight;	
			}
		}
		
		// Input
		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed,acceleration);
		
		// Set amount to move
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);
	}
	
	// Increase currentspeed towards target by speed
	private float IncrementTowards(float curSpeed, float target, float accel) {
		if (curSpeed == target) {
			return curSpeed;	
		}
		else {
			float direction = Mathf.Sign(target - curSpeed); // must n be increased or decreased to get closer to target
			curSpeed += accel * Time.deltaTime * direction;
			return (direction == Mathf.Sign(target-curSpeed))? curSpeed: target; // if n has now passed target then return target, otherwise return currentSpeed
		}
	}
}
