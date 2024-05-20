using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsController : MonoBehaviour
{
    public TextMeshProUGUI resultsText;
    // Start is called before the first frame update
    void Start()
    {
        resultsText.text += PlayerPrefs.GetFloat("explanationTime").ToString("n1") + "s | "
        + PlayerPrefs.GetFloat("q1Time").ToString("n1") + "s | "
        + PlayerPrefs.GetInt("q1Attempts").ToString() + " | "
        + PlayerPrefs.GetFloat("q2Time").ToString("n1") + "s | "
        + PlayerPrefs.GetInt("q2Attempts").ToString() + " | "
        + PlayerPrefs.GetFloat("q3Time").ToString("n1") + "s | "
        + PlayerPrefs.GetInt("q3Attempts").ToString();
        
        PlayerPrefs.SetInt("skillTree", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
