using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quest1Controller : MonoBehaviour
{
    public GameObject content, triangleCard, triangle, tryAgainPanel;
    public Button nextButton;
    public TextMeshProUGUI timerText;
    public float timeLeft = 30f, timeSpent = 0.0f;
    private bool paused = false;
    public int attempts = 1;
    private List<Tuple<GameObject, GameObject>> triangles;

    public void pressAddTriangleButton()
    {
        GameObject newCard = Instantiate(triangleCard, content.transform);
        GameObject newTriangle = Instantiate(triangle, transform);
        Tuple<GameObject, GameObject> pair = new Tuple<GameObject, GameObject>(newCard, newTriangle);
        triangles.Add(pair);

        TriangleCardScript newCardScript = newCard.GetComponent<TriangleCardScript>();

        newCardScript.setDeleteTriangle(
            new DeleteTriangle(delegate ()
            {
                Destroy(newCard);
                Destroy(newTriangle);
                triangles.Remove(pair);
            })
        );
        newCardScript.setUpdateTriangle(
            new UpdateTriangle(delegate ()
            {
                newTriangle.GetComponent<Triangle>().updateVertices(float.Parse(newCardScript.x1.text), float.Parse(newCardScript.y1.text), float.Parse(newCardScript.z1.text), float.Parse(newCardScript.x2.text), float.Parse(newCardScript.y2.text), float.Parse(newCardScript.z2.text), float.Parse(newCardScript.x3.text), float.Parse(newCardScript.y3.text), float.Parse(newCardScript.z3.text));
                this.updatedTriangle(float.Parse(newCardScript.x1.text), float.Parse(newCardScript.y1.text), float.Parse(newCardScript.z1.text), float.Parse(newCardScript.x2.text), float.Parse(newCardScript.y2.text), float.Parse(newCardScript.z2.text), float.Parse(newCardScript.x3.text), float.Parse(newCardScript.y3.text), float.Parse(newCardScript.z3.text));
            })
        );
    }

    void Start()
    {
        triangles = new List<Tuple<GameObject, GameObject>>();
        timerText.text = "Time left: " + timeLeft.ToString("n1") + "s";
    }

    void updatedTriangle(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3)
    {
        if (x1 == 1 && y1 == 1 && z1 == 0 && x2 == 1 && y2 == 0 && z2 == 0 && x3 == 0 && y3 == 1 && z3 == 0)
        {
            nextButton.interactable = true;
            paused = true;
        }
    }

    void Update()
    {
        timeSpent += Time.deltaTime;
        if (paused)
        {
            return;
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timerText.text = "Time left: 0s";
            paused = true;
            tryAgainPanel.SetActive(true);
            attempts++;
        }
        else
        {
            timerText.text = "Time left: " + timeLeft.ToString("n1") + "s";
        }
    }

    public void pressTryAgain()
    {
        for (int i = 0; i < triangles.Count; i++)
        {
            Destroy(triangles[i].Item1);
            Destroy(triangles[i].Item2);
        }
        triangles = new List<Tuple<GameObject, GameObject>>();

        timeLeft = 30f;
        paused = false;
        tryAgainPanel.SetActive(false);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("q1Time", timeSpent);
        PlayerPrefs.SetInt("q1Attempts", attempts);
    }
}
