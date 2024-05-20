using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public delegate void DeleteTriangle();
public delegate void UpdateTriangle();

public class TriangleCardScript : MonoBehaviour
{
    public TMP_InputField x1, y1, z1, x2, y2, z2, x3, y3, z3;
    public DeleteTriangle deleteTriangle;

    public UpdateTriangle updateTriangle;
    public void pressDelete()
    {
        this.deleteTriangle();
    }

    public void pressUpdate()
    {
        this.updateTriangle();
    }

    public void setDeleteTriangle(DeleteTriangle deleteTriangle)
    {
        this.deleteTriangle = deleteTriangle;
    }

    public void setUpdateTriangle(UpdateTriangle updateTriangle)
    {
        this.updateTriangle = updateTriangle;
    }
}
