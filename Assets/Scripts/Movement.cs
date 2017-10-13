using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour 
{

	public float moveForce = 5;
	Rigidbody2D body;
	Animator animator;

	private int state = 0;

	// Use this for initialization
	void Start () 
	{
		body = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void FixedUpdate() 
	{
		Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
		// print(moveVec);
		DetermineState(moveVec);
		body.MovePosition(body.position + moveVec * Time.fixedDeltaTime);
	}

	void DetermineState(Vector2 vector)
	{
		if (vector == Vector2.zero) 
		{
			SetAnimation(0);
		}
		else 
		{
			float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
			if (angle < 0.0f) 
			{
				angle += 360.0f;
			}
			int state = (int)(angle / 60.0f) + 1;
			SetAnimation(state);
		}
	}

	void SetAnimation(int state) 
	{
		switch (state) 
		{
			// Idle
			case 0:
				animator.SetInteger("State", 0);
				MirrorSprite(false);
				break;
			// Right Up
			case 1:
				animator.SetInteger("State", 3);
				MirrorSprite(false);
				break;
			// Tilt Up
			case 2:
				animator.SetInteger("State", 1);
				MirrorSprite(false);
				break;
			// Left Up
			case 3:
				animator.SetInteger("State", 3);
				MirrorSprite(true);
				break;
			// Left Down
			case 4:
				animator.SetInteger("State", 4);
				MirrorSprite(true);
				break;
			// Tilt Down
			case 5:
				animator.SetInteger("State", 2);
				MirrorSprite(false);
				break;
			// Right Down
			case 6:
				animator.SetInteger("State", 4);
				MirrorSprite(false);
				break;
			default:
				break;
		}
	}

	void MirrorSprite(bool mirrored)
	{
		float scale = Mathf.Abs(transform.localScale.x);
		transform.localScale = new Vector3((mirrored) ? (0.0f - scale) : scale, scale, 0);
	}
}
