using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshCollider))]
public class MeshDeformer : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private MeshCollider _meshCollider;
    private Vector3[] _vertices;

    private void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshCollider = GetComponent<MeshCollider>();
        _vertices = _meshFilter.mesh.vertices;
    }

    private void Update()
    {
        for (var i = 0; i < _vertices.Length; i++)
        {
            Debug.Log($"{i} position: {_vertices[i]}");
            //_vertices[i] += Vector3.up * Time.deltaTime;
        }
        _meshFilter.mesh.vertices = _vertices;
        _meshFilter.mesh.RecalculateBounds();
        _meshCollider.sharedMesh = _meshFilter.mesh;
    }
}
