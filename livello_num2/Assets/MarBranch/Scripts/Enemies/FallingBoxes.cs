using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBoxes : MonoBehaviour
{
	Rigidbody2D rb;
     
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			Invoke("DropPlatform", 0.5f);
			Destroy(gameObject, 2f);
		}
	}

	private void DropPlatform()
	{
		rb.isKinematic = false;
	}
}
