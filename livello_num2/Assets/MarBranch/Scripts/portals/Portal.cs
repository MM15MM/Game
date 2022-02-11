using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    //bool teleport = false;
    public GameObject PortalObject;
    public GameObject Player;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //teleport = true;
            StartCoroutine(Teleport());
            
        }
        //else 
           // if(teleport == true)
        //{
            //teleport = false;
        //}
    }


    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.5f);
        AudioManager.instance.Play("Teleport");
        Player.transform.position = new Vector2(PortalObject.transform.position.x, PortalObject.transform.position.y);
        Destroy(gameObject);
    }
}

