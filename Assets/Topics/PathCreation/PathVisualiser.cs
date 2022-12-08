using System;
using System.IO;
using System.Net;
using UnityEngine;

public class PathVisualiser : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private string filePath = "way.txt";
    [SerializeField] private float width = 10;

    [ContextMenu("ReadPathFile")]
    public void ReadPathFile()
    {
        var file = File.ReadAllText(filePath);
        var path = JsonUtility.FromJson<Path>(file);
        Debug.Log(path.name);

        line.endWidth = width;
        line.startWidth = width;
        line.positionCount = path.waypoints.Length;
        line.SetPositions(path.waypoints);
    }
}