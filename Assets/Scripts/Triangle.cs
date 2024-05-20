using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    public Vector3 point1, point2, point3;
    public void Awake()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[3]
        {
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 0.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 0.0f)
        };
        mesh.vertices = vertices;

        int[] tris = new int[6]
        {
            0, 1, 2,
            0, 2, 1
        };
        mesh.triangles = tris;

        Vector3[] normals = new Vector3[3]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
        };
        mesh.normals = normals;

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
    }

    public void Update()
    {
    }

    public void updateVertices(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3)
    {
        Vector3[] vertices = new Vector3[3] {
            new Vector3(x1, y1, z1),
            new Vector3(x2, y2, z2),
            new Vector3(x3, y3, z3)
        };
        gameObject.GetComponent<MeshFilter>().mesh.vertices = vertices;
    }
}
