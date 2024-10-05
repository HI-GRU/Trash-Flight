using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7F;
    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    private void Jump()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        float jumpForce = Random.Range(3F, 5F);
        Vector2 jumpVelocity = Vector2.up * jumpForce;
        jumpVelocity.x = Random.Range(-1F, 1F);

        rigidbody2D.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }
}
