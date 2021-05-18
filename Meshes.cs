using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meshes : MonoBehaviour {

    public Material material;
    Vector3[] vertices = new Vector3[6];
    Vector2[] uv = new Vector2[6];
    int[] triangles = new int[3];

    

    void Start() {

        vertices[0] = new Vector3(-.5f, 0);
        vertices[1] = new Vector3(0, 0);
        vertices[2] = new Vector3(.5f, 0);
        vertices[3] = new Vector3(.25f, -.5f);
        vertices[4] = new Vector3(0, -1);
        vertices[5] = new Vector3(-.25f, -.5f);

        uv[0] = new Vector2(-.5f, 0);
        uv[1] = new Vector2(0, 0);
        uv[2] = new Vector2(.5f, 0);
        uv[3] = new Vector2(.25f, -.5f);
        uv[4] = new Vector2(0, -1);
        uv[5] = new Vector2(-.25f, -.5f);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;
    }

}
