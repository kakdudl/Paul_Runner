using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulMovement : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D rb;

    [SerializeField] private float xMarginLeft = 0f;
    [SerializeField] private float xMarginRight = 3f;
    [SerializeField] private float playerSpeed = 150;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        int dirX = 0;
        transform.rotation = Quaternion.Euler(0, 0, 90);

        if (Application.isEditor)
        {
            //wasd input
            if (Input.GetKey(KeyCode.D))
            {
                //go right
                dirX = 1;
                transform.rotation = Quaternion.Euler(0, 0, 60);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                //go left
                dirX = -1;
                transform.rotation = Quaternion.Euler(0, 0, 120);
            }
        }
        else
        {
            //touchscreen
            if (Input.touches.Length > 0)
            {
                Vector3 touchPosition = Input.touches[0].position;
                touchPosition = mainCamera.ScreenToWorldPoint(touchPosition);

                if (touchPosition.x > 0)
                {
                    //go right
                    dirX = 1;
                    transform.rotation = Quaternion.Euler(0, 0, 60);
                }
                else
                {
                    //go left
                    dirX = -1;
                    transform.rotation = Quaternion.Euler(0, 0, 120);
                }
            }
        }

        rb.velocity = new Vector2(dirX * playerSpeed * Time.deltaTime, 0);

        float posX = transform.position.x;
        posX = Mathf.Clamp(posX, xMarginLeft, xMarginRight);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
