using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 900f;                          // Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // What is ground to Cassandra?
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings                

	private bool m_Grounded;              // Grounded or not
	private float k_GroundedRadius = .1f;
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;   // Which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	private int availableJumps;
	public int totalJumps;


	[Header("Events")]


	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		availableJumps = totalJumps;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
       
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				
				if (!wasGrounded)
				{
					OnLandEvent.Invoke();
				}

			}
		}
		
}


	public void Move(float move, bool jump)
	{
     	// only control Cassandra if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			// Move Cassandra by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving Cassandra right and our Cassandra is facing left
			if (move > 0 && !m_FacingRight)
			{
				// flip Cassandra
				Flip();
			}
			// Otherwise if the input is moving Cassandra left and our beloved Cassandra is facing right
			else if (move < 0 && m_FacingRight)
			{
				// flip the player.
				Flip();
			}
		}

		

		if (m_Grounded == true)
        {
			availableJumps = totalJumps;
        }
			if (jump && availableJumps > 0)
			{

			// Add a vertical force to the player.

			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
	    	availableJumps--;
			m_Grounded = false;
		     }
			else
		   if ( jump && m_Grounded)
		    {
			// Add a vertical force to the player.
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			m_Grounded = false;
			}

		}


	
private void Flip()
	{
		// Switch the way Cassandra is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply Cassandra's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}