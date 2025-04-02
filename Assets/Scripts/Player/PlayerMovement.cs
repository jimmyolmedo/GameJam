using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 8f;
    Vector3 move;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        move = new Vector3(x, y);
        move.Normalize();
        transform.position += move * speed * Time.deltaTime;
    }
}
