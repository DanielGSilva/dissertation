using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quest3Controller : MonoBehaviour
{
    public GameObject content, triangleCard, triangle, tryAgainPanel;
    public Button nextButton;
    public TextMeshProUGUI timerText;
    public float timeLeft = 90f, timeSpent = 0.0f;
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
        for (int i = 0; i < 11; i++)
        {
            this.pressAddTriangleButton();
        }

        // left face
        TriangleCardScript triangle0 = triangles[0].Item1.GetComponent<TriangleCardScript>();
        triangle0.x2.text = "0,0";
        triangle0.z2.text = "1,0";
        triangle0.updateTriangle();

        TriangleCardScript triangle1 = triangles[1].Item1.GetComponent<TriangleCardScript>();
        triangle1.z1.text = "1,0";
        triangle1.x2.text = "0,0";
        triangle1.y2.text = "1,0";
        triangle1.z2.text = "1,0";
        triangle1.updateTriangle();

        // right face
        TriangleCardScript triangle2 = triangles[2].Item1.GetComponent<TriangleCardScript>();
        triangle2.x1.text = "1,0";
        triangle2.z1.text = "1,0";
        triangle2.x3.text = "1,0";
        triangle2.z3.text = "1,0";
        triangle2.updateTriangle();

        TriangleCardScript triangle3 = triangles[3].Item1.GetComponent<TriangleCardScript>();
        triangle3.x1.text = "1,0";
        triangle3.y1.text = "1,0";
        triangle3.x3.text = "1,0";
        triangle3.z3.text = "1,0";
        triangle3.updateTriangle();

        // bottom face
        TriangleCardScript triangle4 = triangles[4].Item1.GetComponent<TriangleCardScript>();
        triangle4.x3.text = "1,0";
        triangle4.y3.text = "0,0";
        triangle4.z3.text = "1,0";
        triangle4.updateTriangle();

        // back face
        TriangleCardScript triangle5 = triangles[5].Item1.GetComponent<TriangleCardScript>();
        triangle5.z1.text = "1,0";
        triangle5.y2.text = "1,0";
        triangle5.z2.text = "1,0";
        triangle5.z3.text = "1,0";
        triangle5.updateTriangle();

        TriangleCardScript triangle6 = triangles[6].Item1.GetComponent<TriangleCardScript>();
        triangle6.z1.text = "1,0";
        triangle6.z2.text = "1,0";
        triangle6.x3.text = "1,0";
        triangle6.z3.text = "1,0";
        triangle6.updateTriangle();

        // upper face
        TriangleCardScript triangle7 = triangles[7].Item1.GetComponent<TriangleCardScript>();
        triangle7.y1.text = "1,0";
        triangle7.z1.text = "1,0";
        triangle7.y2.text = "1,0";
        triangle7.updateTriangle();

        TriangleCardScript triangle8 = triangles[8].Item1.GetComponent<TriangleCardScript>();
        triangle8.y1.text = "1,0";
        triangle8.z1.text = "1,0";
        triangle8.y2.text = "1,0";
        triangle8.x3.text = "1,0";
        triangle8.z3.text = "1,0";
        triangle8.updateTriangle();

        // front face
        TriangleCardScript triangle9 = triangles[9].Item1.GetComponent<TriangleCardScript>();
        triangle9.x1.text = "1,0";
        triangle9.y1.text = "1,0";
        triangle9.updateTriangle();
    }

    void updatedTriangle(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3)
    {
        if ((x1 == 0.0f && y1 == 0.0f && z1 == 0.0f && x2 == 1.0f && y2 == 0.0f && z2 == 1.0f && x3 == 0.0f && y3 == 0.0f && z3 == 1.0f)
        || (x1 == 0.0f && y1 == 0.0f && z1 == 0.0f && x2 == 0.0f && y2 == 0.0f && z2 == 1.0f && x3 == 1.0f && y3 == 0.0f && z3 == 1.0f)
        || (x1 == 0.0f && y1 == 0.0f && z1 == 1.0f && x2 == 0.0f && y2 == 0.0f && z2 == 0.0f && x3 == 1.0f && y3 == 0.0f && z3 == 1.0f)
        || (x1 == 0.0f && y1 == 0.0f && z1 == 1.0f && x2 == 1.0f && y2 == 0.0f && z2 == 1.0f && x3 == 0.0f && y3 == 0.0f && z3 == 0.0f)
        || (x1 == 1.0f && y1 == 0.0f && z1 == 1.0f && x2 == 0.0f && y2 == 0.0f && z2 == 1.0f && x3 == 0.0f && y3 == 0.0f && z3 == 0.0f)
        || (x1 == 1.0f && y1 == 0.0f && z1 == 1.0f && x2 == 0.0f && y2 == 0.0f && z2 == 0.0f && x3 == 0.0f && y3 == 0.0f && z3 == 1.0f)
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

        timeLeft = 90f;
        paused = false;
        tryAgainPanel.SetActive(false);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("q3Time", timeSpent);
        PlayerPrefs.SetInt("q3Attempts", attempts);
    }
}
