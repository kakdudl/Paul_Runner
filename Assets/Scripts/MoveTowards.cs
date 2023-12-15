using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    [SerializeField] private Vector3 positionToGoBackTo;
    [SerializeField] private Vector3 destination;

    [SerializeField] private float scalingMultiplayer;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    private bool isSpeedingUp;

    private void Update()
    {
        if (Time.timeScale == 0)
            return;
        
        transform.position = Vector2.MoveTowards(transform.position, destination, speed);

        if (transform.position == destination)
            transform.position = positionToGoBackTo;
        
        if (isSpeedingUp)
        {
            speed *= scalingMultiplayer;
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
                isSpeedingUp = false;
            }
        }
    }

    public void StartScript()
    {
        isSpeedingUp = true;
    }
}
