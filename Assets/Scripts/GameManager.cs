using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameOverPanel;

    private int coin = 0;

    [HideInInspector]
    public bool isGameOver = false;

    [SerializeField]
    private GameObject[] backGrounds;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void IncreaseCoin() {
        coin++;
        text.SetText(coin.ToString());

        if (coin % 30 == 0) {
            Player player = FindObjectOfType<Player>();
            if (player != null) {
                player.Upgrade();
            }
        }
    }

    public void SetGameOver() {
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null) {
            enemySpawner.StopEnemyRoutine();
        }

        isGameOver = true;
        
        Invoke("ShowGameOverPanel", 0.5F);
    }

    void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain() {       
        SceneManager.LoadScene("SampleScene");
    }

    public void changeBackGround() {
        foreach (GameObject item in backGrounds)
        {
            SpriteRenderer renderer = item.GetComponent<SpriteRenderer>();
            if (renderer != null) {
                renderer.color = new Color(0.9F, 0F, 0F, 0.7F);
            }
        }
    }
}
