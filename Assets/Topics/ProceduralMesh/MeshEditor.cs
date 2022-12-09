using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshEditor : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private MeshCollider _meshCollider;
    private Vector3[] _vertices;

    private void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshCollider = GetComponent<MeshCollider>();
        _vertices = _meshFilter.mesh.vertices;

        DebugVertices();
    }

    private void Update()
    {
        for (var i = 0; i < _vertices.Length; i++)
        {
            _vertices[i] += Vector3.up * Time.deltaTime;
        }
        _meshFilter.mesh.vertices = _vertices;
        _meshFilter.mesh.RecalculateBounds();
        _meshCollider.sharedMesh = _meshFilter.mesh;
    }

    private void DebugVertices()
    {
        for (var i = 0; i < _vertices.Length; i++)
        {
            Debug.Log($"{i} position: {_vertices[i]}");
        }
    }
    
    /*private void OnDrawGizmos()
    {
        if (_vertices == null) return;
        Gizmos.color = Color.red;
        for (int i = 0; i < _vertices.Length; i++)
        {
            Gizmos.DrawSphere(_vertices[i], 0.1f);
        }
    }*/
}
