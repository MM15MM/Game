using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace ClearSky
{
    public class SimplePlayerController : MonoBehaviour
    {

        private Rigidbody2D rb;
        private Animator anim;

        Vector3 movement;
        public float movePower = 10f;

        private int direction = 1;
        private bool isRight = true;

        bool isJumping = false;
        public float jumpPower = 15f; //Set Gravity Scale in Rigidbody2D Component to 5

        private bool alive = true;

        public GameObject bullet;
        public Rigidbody2D bulletBody;
        public Transform bulletDimensions;
        public float bulletSpeed = 15f;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                //Hurt();
                //Die();
                Attack();
                Jump();
                Run();

            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }


        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);

            if (CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0)
            {
                if (isRight) { transform.Rotate(0f, 180f, 0f); }

                isRight = false;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            if (CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0)
            {
                if (!isRight) { transform.Rotate(0f, 180f, 0f); }

                isRight = true;

                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
        void Jump()
        {
            if ((CrossPlatformInputManager.GetButtonDown("Jump") || CrossPlatformInputManager.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        void Attack()
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("attack");
                Invoke("Shooting", 0.5f);
            }
        }
        private void Shooting()
        {
            Rigidbody2D instance = Instantiate(bulletBody, bulletDimensions.position, bulletDimensions.rotation);
            instance.velocity = transform.right * bulletSpeed;
        }
        /* void Hurt()
        {
            if (CrossPlatformInputManager.GetButtonDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                anim.SetTrigger("die");
                alive = false;
            }
        } */
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                anim.SetTrigger("idle");
                alive = true;
            }
        }
    }
}