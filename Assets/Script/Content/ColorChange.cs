using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    //[SerializeField] private Material newCol;
    MeshRenderer[] meshes;


    void Start()
    {
        meshes = GetComponentsInChildren<MeshRenderer>();
    }

    private void Update()
    {
        // Debug
        if(Input.GetMouseButtonDown(0))
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        foreach (MeshRenderer mesh in meshes)
        {
            mesh.material.color = RandomColor();
        }
    }

    Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }


}
