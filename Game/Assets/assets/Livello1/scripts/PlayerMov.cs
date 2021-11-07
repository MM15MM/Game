using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMov : MonoBehaviour
{
	public Rigidbody2D bullet;

	[SerializeField]
	public Transform bulletPos;

	[SerializeField]
	float bulletSpeed = 500f;


	public CharacterController2D controller;

	public float Speed = 40f;
	public Animator anim;

	bool shoot = false;

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

		horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal") * Speed;
		anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (CrossPlatformInputManager.GetButtonDown("Jump"))
		{
			jump = true;
			anim.SetBool("Jump", true);
		}

		if (CrossPlatformInputManager.GetButtonDown("Fire1"))
		{
			anim.SetBool("Shoot", true);
			Invoke("Shooting", 0.25f);
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
		
		var FiredBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
		FiredBullet.AddForce(bulletPos.up * bulletSpeed);
    }
	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}
}

