using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float weaponSpeed = 10F;
    public float damage = 1F;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.2F);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * weaponSpeed * Time.deltaTime;
    }
}
