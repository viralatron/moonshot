using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    private GameObject game;
    private Text scoreText, multiplierText;
    private int score, multiplier;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameMode");

        scoreText = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        multiplierText = this.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score = game.GetComponent<GameMode>().score;
        multiplier = game.GetComponent<GameMode>().multiplier;

        scoreText.text = "SCORE: " + score.ToString();
        multiplierText.text = "MULTIPLIER: " + multiplier.ToString();
        //Debug.Log(scoreText.text);
    }
}
