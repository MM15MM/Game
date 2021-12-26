using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            body.velocity = new Vector2(0, verticalInput);
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            body.velocity = new Vector2(horizontalInput, 0);
        else
            body.velocity = new Vector2(0, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            if (Input.GetKey(KeyCode.E))
                collision.gameObject.GetComponent<NPC_Controller>().ActivateDialogue();
        }
    }
}
