using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float movingSpeed = 3F;
    private float minY = -10;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * movingSpeed * Time.deltaTime;

        if (transform.position.y < minY) {
            transform.position += new Vector3(0, 20F, 0);
        }
    }
}
