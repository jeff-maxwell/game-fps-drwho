using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text txt = GameObject.Find("lblScoreVal").GetComponent<Text>();
        txt.text = GameInfo.currentScore.ToString();
    }

}
