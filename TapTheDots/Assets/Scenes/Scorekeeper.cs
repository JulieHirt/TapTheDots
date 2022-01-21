using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour
{
    public Text scoretext;
    // Start is called before the first frame update
    int score = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseScore()
    {
        score += 10;
        scoretext.text = "Score" + score.ToString();
    }

}
