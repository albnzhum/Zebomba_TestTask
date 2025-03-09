using UnityEngine;

public class PendulumController : MonoBehaviour
{
    public GameObject ballPrefab;  // Префаб шара
    public Transform spawnPoint;   // Где создается шарик
    private GameObject currentBall;

    void Start()
    {
        SpawnBall();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && currentBall != null)
        {
            currentBall.GetComponent<HingeJoint2D>().enabled = false; // Отключаем связь
            currentBall.GetComponent<Rigidbody2D>().gravityScale = 1; // Включаем падение
            currentBall = null;
            Invoke("SpawnBall", 1f); // Генерируем новый шарик через 1 сек
        }
    }

    void SpawnBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        ball.GetComponent<HingeJoint2D>().connectedBody = gameObject.GetComponent<Rigidbody2D>();
        currentBall = ball;
    }
}