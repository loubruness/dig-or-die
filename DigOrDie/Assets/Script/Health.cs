using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject gameOverScreen;
    public GameObject player;
    private Transform[] spawnPoints;

    // Start is called before the first frame update
    private void Awake()
    {
        spawnPoints = new Transform[2];
        spawnPoints = GameObject.Find("PlayerManager").GetComponent<PlayerManager>().spawnPoints;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        if (health < 1 || transform.position.y < -1)
        {
            gameOver();
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        health = 3;

        Debug.Log("Game Over");
        Debug.Log("spawnPoints");
        if (player.name == "Player1")
        {
            player.transform.position = spawnPoints[0].position;
        }
        else if (player.name == "Player2")
        {
            player.transform.position = spawnPoints[1].position;
        }
    }

    public void win()
    {
        gameOverScreen.SetActive(true);
    }
}