using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitCollect : MonoBehaviour
{
    FruitTracker fruitTacker;
    private void Start()
    {
        fruitTacker = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<FruitTracker>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (fruitTacker.fruitCollected[SceneManager.GetActiveScene().buildIndex] == true)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.35f);
        }
    }

    public void NewScene()
    {
        SceneManager.LoadSceneAsync(28, LoadSceneMode.Single);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.tag == "Player")
        {
            fruitTacker.fruitFound(SceneManager.GetActiveScene().buildIndex);
            NewScene();
        }
    }
}

