using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // private field여도 Unity 에디터에서 접근 가능
    private float movingSpeed;

    [SerializeField]
    private GameObject[] weapons;
    private int weaponLevel = 0;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05F;
    private float lastShotTime = 0F;

    void Update()
    {
        // mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float toX = Mathf.Clamp(mousePos.x, -2.3F, 2.3F);

        transform.position = new Vector3(toX, transform.position.y);

        if (!GameManager.instance.isGameOver) {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time - lastShotTime > shootInterval) {
            Instantiate(weapons[weaponLevel], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Enemy") || other.gameObject.tag.Equals("Boss")) {
            GameManager.instance.SetGameOver();
            Destroy(gameObject);
        } else if (other.gameObject.tag.Equals("Coin")) {
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade() {
        if (weaponLevel >= weapons.Length - 1) return;
        weaponLevel++;
    }
}
