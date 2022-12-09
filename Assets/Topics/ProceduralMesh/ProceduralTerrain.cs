using UnityEngine;

namespace Topics.ProceduralMesh
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class ProceduralTerrain : MonoBehaviour
    {
        [SerializeField]
        private int _xSize, _ySize;

        private Vector3[] _vertices;
        private Mesh _mesh;

        private void Start()
        {
            Generate();
            
            DebugVertices();
        }
        
        private void DebugVertices()
        {
            for (var i = 0; i < _vertices.Length; i++)
            {
                Debug.Log($"{i} position: {_vertices[i]}");
            }
        }

        private void Generate()
        {
            _mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = _mesh;
            _mesh.name = "Terrain";

            _vertices = new Vector3[(_xSize + 1) * (_ySize + 1)];
            Vector2[] uvs = new Vector2[_vertices.Length];
            for (int i = 0, y = 0; y <= _ySize; y++)
            {
                for (int x = 0; x <= _xSize; x++, i++)
                {
                    _vertices[i] = new Vector3(x, y);
                    uvs[i] = new Vector2((float)x / _xSize, (float)y / _ySize);
                }
            }
            _mesh.vertices = _vertices;
            _mesh.uv = uvs;

            int[] triangles = new int[_xSize * _ySize * 6];
            int ti = 0, vi = 0;
            for (int y = 0; y < _ySize; y++, vi++)
            {
                for (int x = 0; x < _xSize; x++, ti += 6, vi++)
                {
                    triangles[ti] = vi;
                    triangles[ti + 1] = triangles[ti + 4] = vi + _xSize + 1;
                    triangles[ti + 2] = triangles[ti + 3] = vi + 1;
                    triangles[ti + 5] = vi + _xSize + 2;
                }
            }
                

            _mesh.triangles = triangles;
            _mesh.RecalculateNormals();
        }

        /*private void OnDrawGizmos()
        {
            if (_vertices == null)
            {
                return;
            }
            Gizmos.color = Color.red;
            for (int i = 0; i < _vertices.Length; i++)
            {
                Gizmos.DrawSphere(_vertices[i], 0.2f);
            }
        }*/
    }
}