using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float enemySpeed = 10F;
    private float minY = -7F;

    [SerializeField]
    private float hp = 1F;

    [SerializeField]
    private GameObject coin;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * enemySpeed * Time.deltaTime;

        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    public void SetEnemySpeed(float enemySpeed) {
        this.enemySpeed = enemySpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (transform.position.y >= 5.7) return;

        if (other.gameObject.tag.Equals("Weapon")) {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;
            Destroy(other.gameObject);
        }

        if (hp <= 0) {

            if (gameObject.tag.Equals("Boss")) {
                GameManager.instance.SetGameOver();
            }

            Destroy(gameObject);
            Instantiate(coin, transform.position, Quaternion.identity);
        }
    }
}
