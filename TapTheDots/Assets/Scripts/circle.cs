using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    public Scorekeeper scorekeeper;
    // Start is called before the first frame update
    void Awake()
    {
        scorekeeper = FindObjectOfType<Scorekeeper>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("clicked");
            if (this.tag == "greencircle")
            {
                scorekeeper.IncreaseScore();
            }
            else if (this.tag == "redcircle")
            {
                scorekeeper.DecreaseScore();
            }
        }
    }
}
