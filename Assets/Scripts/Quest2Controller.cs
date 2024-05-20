using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quest2Controller : MonoBehaviour
{
    public GameObject content, triangleCard, triangle, tryAgainPanel;
    public Button nextButton;
    public TextMeshProUGUI timerText;
    public float timeLeft = 60f, timeSpent = 0.0f;
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

        setupScene();
    }

    void setupScene()
    {
        for (int i = 0; i < 3; i++)
        {
            this.pressAddTriangleButton();
        }

        TriangleCardScript triangle0 = triangles[0].Item1.GetComponent<TriangleCardScript>();
        triangle0.x3.text = "0,5";
        triangle0.updateTriangle();

        TriangleCardScript triangle1 = triangles[1].Item1.GetComponent<TriangleCardScript>();
        triangle1.x1.text = "1,0";
        triangle1.x2.text = "2,0";
        triangle1.x3.text = "1,5";
        triangle1.y3.text = "1,0";
        triangle1.updateTriangle();

        TriangleCardScript triangle2 = triangles[2].Item1.GetComponent<TriangleCardScript>();
        triangle2.x1.text = "0,5";
        triangle2.y1.text = "1,0";
        triangle2.x2.text = "1,5";
        triangle2.y2.text = "1,0";
        triangle2.x3.text = "1,0";
        triangle2.y3.text = "2,0";
        triangle2.updateTriangle();
    }

    void updatedTriangle(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3)
    {
        if ((x1 == 0.5f && y1 == 1 && z1 == 0 && x2 == 1 && y2 == 0 && z2 == 0 && x3 == 1.5f && y3 == 1 && z3 == 0)
        || (x1 == 1f && y1 == 0 && z1 == 0 && x2 == 1.5f && y2 == 1 && z2 == 0 && x3 == 0.5f && y3 == 1 && z3 == 0)
        || (x1 == 1.5f && y1 == 1 && z1 == 0 && x2 == 0.5f && y2 == 1 && z2 == 0 && x3 == 1f && y3 == 0 && z3 == 0)
        || (x1 == 0.5f && y1 == 1 && z1 == 0 && x2 == 1.5f && y2 == 1 && z2 == 0 && x3 == 1f && y3 == 0 && z3 == 0)
        || (x1 == 1.5f && y1 == 1 && z1 == 0 && x2 == 1f && y2 == 0 && z2 == 0 && x3 == 0.5f && y3 == 1 && z3 == 0)
        || (x1 == 1f && y1 == 0 && z1 == 0 && x2 == 0.5f && y2 == 1 && z2 == 0 && x3 == 1.5f && y3 == 1 && z3 == 0)
        )
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
        setupScene();

        timeLeft = 60f;
        paused = false;
        tryAgainPanel.SetActive(false);
    }
    
    void OnDisable() {
        PlayerPrefs.SetFloat("q2Time", timeSpent);
        PlayerPrefs.SetInt("q2Attempts", attempts);
    }
}
