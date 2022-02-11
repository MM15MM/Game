using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMov : MonoBehaviour
{
	[Header("Bullet")]
	public Rigidbody2D bullet;   
   [SerializeField]
	public Transform bulletPos;   //'Bullet' spawn position
    [SerializeField]
	float bulletSpeed = 500f; 

	[Header("Cassandra's movements variables and animator")]
	public PlayerController controller;
    public float Speed = 40f;
	public Animator anim;
    float horizontalMove = 0f;
	bool jump = false;
    Vector3 localScale;
	private Rigidbody2D rb;

	
	void Start()
	{
		localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{  
		//Touch controls and animations

		horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal") * Speed;
		anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (CrossPlatformInputManager.GetButtonDown("Jump"))
		{
			jump = true;
			anim.SetBool("Jump", true);
			AudioManager.instance.Play("Jump");
		}

		if (CrossPlatformInputManager.GetButtonDown("Fire1"))
		{
			anim.SetBool("Shoot", true);
			Invoke("Shooting", 0.5f);
			AudioManager.instance.Play("CassandraAttacks");
		}

		
		if (CrossPlatformInputManager.GetButtonUp("Fire1"))
        {
			anim.SetBool("Shoot", false);
		}
	}

	public void OnLanding()
    {
		anim.SetBool("Jump", false);
    }

	private void Shooting()
	{
		//Cassandra attacks

		var FiredBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);          //bullet should spawn in thecorrect position (bulletPos)
		FiredBullet.AddForce(bulletPos.up * bulletSpeed);
		}
	void FixedUpdate()
	{
		// Move our Cassandra
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}
}

