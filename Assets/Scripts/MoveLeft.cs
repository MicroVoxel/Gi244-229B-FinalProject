using UnityEngine;
using UnityEngine.InputSystem;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    public float normalSpeed;
    public float dashSpeed;

    private float leftBound = -15;

    private PlayerController playerController;
    private InputAction dashAction;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        dashAction = InputSystem.actions.FindAction("Sprint");

        normalSpeed = speed;
        dashSpeed = speed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (dashAction.IsPressed())
        {
            speed = dashSpeed;
        }
        else { speed = normalSpeed; }

        if (!playerController.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            ObstacleObjectPool.GetInstance().Return(gameObject);
        }
    }
}
