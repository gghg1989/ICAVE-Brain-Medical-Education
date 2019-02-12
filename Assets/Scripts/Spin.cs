using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public float speed = 0;

	// Use this for initialization
	void Start () {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.sharedMesh;
        Color[] vertexColors = mesh.colors;
        for (int i = 0; i < (int)(vertexColors.Length / 2); ++i)
        {
            vertexColors[i] = Color.blue;
        }
        mesh.colors = vertexColors; // update the vertex color
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}
