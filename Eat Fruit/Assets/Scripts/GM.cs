using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public GameObject Go;
    private GameObject Player;
    private Player PlayerScript;

    public Text scoreText;
    public int score = 0, goal = 10;

    public string SceneName;
    public bool ClearBool;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ClearBool = false;
        UpdateElements();
        GO();
    }

    void Update()
    {
        if(score == goal)
        {
            StartCoroutine(Clear());
        }
    }

    void UpdateElements()
    {
        scoreText.text = score.ToString() + " / " + goal.ToString();
    }

    public void EatFruit()
    {
        score++;
        UpdateElements();
    }

    public void GO()
    {
        Player.transform.position = Go.transform.position;
    }

    IEnumerator Clear()
    {
        ClearBool = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneName);
    }
}
