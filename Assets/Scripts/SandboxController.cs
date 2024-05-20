using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SandboxController : MonoBehaviour
{
    public GameObject content, triangleCard, triangle;
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
            })
        );
    }

    void Start()
    {
        triangles = new List<Tuple<GameObject, GameObject>>();
    }

    void Update()
    {

    }
}
