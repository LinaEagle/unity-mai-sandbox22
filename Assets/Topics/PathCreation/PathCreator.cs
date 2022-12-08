using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class PathCreator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AnimationCurve AnimationCurve;
    [SerializeField, Range(0,1)] private float _interval = 0.3f;
    [SerializeField] private List<Vector3> wayPoints;
    private Coroutine _process;
    private bool _inProgress;

    public void OnPointerDown(PointerEventData eventData)
    {
        _inProgress = true;
        Debug.Log("Start");
        _process = StartCoroutine(TrackPath());
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inProgress = false;
        Debug.Log("Stop");
        StopCoroutine(_process);
        var path = new Path
        {
            name = Time.time.ToString(),
            waypoints = wayPoints.ToArray()
        };

        var file = JsonUtility.ToJson(path, true);
        File.WriteAllText($"way.txt", file);
    }

    private IEnumerator TrackPath()
    {
        while (_inProgress)
        {
            var point = Input.mousePosition;
            wayPoints.Add(point);
            yield return new WaitForSeconds(_interval);
        }
    }
}

[Serializable]
public class Path
{
    public string name = "";
    public Vector3[] waypoints;
}
