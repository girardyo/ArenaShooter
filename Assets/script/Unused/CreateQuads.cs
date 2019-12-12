using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateQuads : MonoBehaviour
{

    public Material cubeMaterial;

    public int Taille;


    void createQuads()
    {
        Mesh mesh = new Mesh();
        mesh.name = "my mesh";

        Vector3[] vertices = new Vector3[Taille*Taille];
        Vector3[] normals = new Vector3[Taille * Taille * 4];
        int[] triangles = new int[Taille*Taille*6];
        Vector2[] uvs = new Vector2[Taille*Taille*4];

        int c = 0;
        for (int i =0; i< Taille; i++)
        {
            for (int j = 0; j< Taille; j++)
            {
                vertices[i+j] = new Vector3(i, 0, j);
            }
        }


        for (int i= 0; i< normals.Length; i++)
        {
            normals[i] = Vector3.forward;
        }



        c = 0;
        for (int i = 0; i < Taille; i++)
        {
            for (int j = 0; j < Taille; j++)
            {
                uvs[c] = new Vector2(0f, 0f);
                uvs[c + 1] = new Vector2(1f, 0f);
                uvs[c + 2] = new Vector2(0f, 1f);
                uvs[c + 3] = new Vector2(1f, 1f);

                c += 4;
            }
        }


        c = 0;
        for (int i = 0; i < Taille-1; i++)
        {
            for (int j = 0; j < Taille-1; j++)
            {

                triangles[c] = i + j;
                triangles[c + 1] = i + j + Taille + 1;
                triangles[c + 2] = i + j + 1;
                triangles[c + 3] = i + j;
                triangles[c + 4] = i + j + Taille;
                triangles[c + 5] = i + j + Taille + 1;

                c += 6;
            }
        }




        //vertices = new Vector3[] { p0, p1, p2, p3 };
        //normals = new Vector3[] { Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward };

        triangles = new int[] { 0, 2, 1, 0, 3, 2 };

        /*
        Vector2 uv00 = new Vector2(0f, 0f);
        Vector2 uv10 = new Vector2(1f, 0f);
        Vector2 uv01 = new Vector2(0f, 1f);
        Vector2 uv11 = new Vector2(1f, 1f);
        */




        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        mesh.RecalculateBounds();

        GameObject quad = new GameObject("quad");
        quad.transform.parent = transform;
        MeshFilter meshFilter = quad.AddComponent<MeshFilter>();

        MeshRenderer meshRenderer = quad.AddComponent<MeshRenderer>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
