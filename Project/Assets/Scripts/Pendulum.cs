using UnityEngine;

public class Pendulum : MonoBehaviour
{
    private Rigidbody2D rb2d;
    
    [SerializeField] private float swingSpeed = 2f;

    [SerializeField] private float leftAngle;
    [SerializeField] private float rightAngle;

    private bool movingClockwise;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void ChangeDirection()
    {
        if (transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }

        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
    }

    private void Move()
    {
        ChangeDirection();
            
        if (movingClockwise)
        {
            rb2d.angularVelocity = swingSpeed;
        }
        else
        {
            rb2d.angularVelocity = -swingSpeed;
        }
    }
}
