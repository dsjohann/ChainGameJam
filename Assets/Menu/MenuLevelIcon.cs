using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelIcon : MonoBehaviour
{
    public int levelIndex;

    public Sprite onSprite;
    public Sprite offSprite;

    private SpriteRenderer sr;
    LevelLocker levelLocker;

    bool selectorOnTop;

    private void Start()
    {
        levelLocker = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<LevelLocker>();
    }

    // Start is called before the first frame update
    void Update()
    {
        sr = GetComponent<SpriteRenderer>();
        if (levelLocker.levelUnlocked[levelIndex] == true)
        {
            sr.sprite = onSprite;
            GetComponentInChildren<TMP_Text>().color = Color.white;
        }
        else 
        {
            sr.sprite = offSprite;
        }
        if (Input.GetButton("select") && selectorOnTop)
        {
            if (levelLocker.levelUnlocked[levelIndex] == true)
            {
                SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        selectorOnTop = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        selectorOnTop = false;
    }
}
