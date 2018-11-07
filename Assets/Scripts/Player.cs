using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            GetMovementFromAxis();
        }
        else
        {
            GetMovementFromMouse();
        }

    }

    private void GetMovementFromAxis()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            return;
        }
    }

    private void GetMovementFromMouse()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 relativeMousePosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

            if (relativeMousePosition.x < 0.5f)
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(speed, 0);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}