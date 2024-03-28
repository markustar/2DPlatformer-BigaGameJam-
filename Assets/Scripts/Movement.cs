using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Text timertext;
    public Gun gun;
    
    public Text shooting;
    public Text jumping;
    public Text lefting;
    public Text righting;
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool canDoubleJump = false; // Added variable for double jump
    private float timer = 30f;

    public bool doubleJumpEnabled = false; // Toggle for double jump
    private bool doubleJumpUsed = false; // Added variable to track double jump usage

    public KeyCode[] keys = { KeyCode.A, KeyCode.D, KeyCode.Space, KeyCode.Q, KeyCode.Z, KeyCode.E, KeyCode.X, KeyCode.Mouse0 };
    public KeyCode[] keysCopy = {};
    private KeyCode left;
    private KeyCode right;
    private KeyCode jump;
    public KeyCode shoot;

    private bool facingRight = true;

    public Animator anim;
    public AudioSource audioSource;
    void Start()
    {
        doubleJumpEnabled = false;
        rb = GetComponent<Rigidbody2D>();
        UpdateKeyBindings();
    }

    void Update()
    {
        anim.SetFloat("yVelositi", rb.velocity.y);
        shooting.text = shoot.ToString();
        jumping.text = jump.ToString();
        righting.text = right.ToString();
        lefting.text = left.ToString();

        timer -= Time.deltaTime;
        timertext.text = Mathf.Round(timer).ToString();

        if (timer <= 0f)
        {
            UpdateKeyBindings();
            timer = 30f;
        }

        float horizontalInput = 0f;

        if (Input.GetKey(left))
        {
            horizontalInput -= 1f;
        }
        if (Input.GetKey(right))
        {
            horizontalInput += 1f;
        }

        if (Input.GetKeyDown(jump) && (isGrounded || (doubleJumpEnabled && !doubleJumpUsed))) // Check for double jump
        {
            if (!isGrounded)
            {
                doubleJumpUsed = true; // Mark double jump as used
            }
            audioSource.Play();
            anim.SetBool("Jump", true);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;

            // Trigger the "Jump" animation.
        }

        if (isGrounded)
        {
            doubleJumpUsed = false; // Reset double jump when grounded
        }

        if (facingRight == false && horizontalInput > 0f)
        {
            // Flip the character to face left when moving left.
            Flip();
        }
        else if (facingRight == true && horizontalInput < 0f)
        {
            // Return the character to its original orientation when moving right.
            Flip();
        }

        if (horizontalInput != 0)
        {
            anim.SetBool("Idle", false);
        }
        else
        {
            anim.SetBool("Idle", true);

            // Trigger the "Fall" animation when not moving horizontally and not grounded.
        }
        if (rb.velocity.y < 0)
        {
            anim.SetBool("Jump", true);
        }

        transform.position += transform.right * horizontalInput * speed * Time.deltaTime;
    }

    void UpdateKeyBindings()
    {
        keysCopy = keys;
        int randLeft = Random.Range(0, keys.Length);
        left = keys[randLeft];
        keysCopy = RemoveElementFromArray(keysCopy, left);
        int randRight = Random.Range(0, keysCopy.Length);
        right = keysCopy[randRight];
        keysCopy = RemoveElementFromArray(keysCopy, right);
        int randJump = Random.Range(0, keysCopy.Length);
        jump = keysCopy[randJump];
        keysCopy = RemoveElementFromArray(keysCopy, jump);
        int randShoot = Random.Range(0, keysCopy.Length);
        shoot = keysCopy[randShoot];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("Jump", !isGrounded);
        }
    }

    private T[] RemoveElementFromArray<T>(T[] array, T element)
    {
        List<T> tempList = new List<T>(array);
        tempList.Remove(element);
        return tempList.ToArray();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void AttackEnemy()
    {
        gun.DamageEnemiesInZone();
    }
}
