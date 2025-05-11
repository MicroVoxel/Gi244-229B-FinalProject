using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSfx;
    public AudioClip crashSfx;

    private Rigidbody rb;
    private InputAction jumpAction;
    private bool isOnGround = true;

    private Animator playerAnim;
    private AudioSource playerAudio;

    public bool gameOver = false;
    public int hp = 3;
    public HealthBar healthBar;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Start()
    {
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);

        jumpAction = InputSystem.actions.FindAction("Jump");

        healthBar.SetMaxHp(hp);

        gameOver = false;
    }

    void Update()
    {
        if (jumpAction.triggered && isOnGround && !gameOver)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSfx);
        } 

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            ObstacleObjectPool.GetInstance().Return(collision.gameObject);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSfx);
            hp -= 1;
            healthBar.SetHp(hp);
        }
        if (hp <= 0)
        {
            Debug.Log("Game Over!");
            gameOver = true;
            dirtParticle.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }

}