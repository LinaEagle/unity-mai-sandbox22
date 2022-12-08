using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Cube : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _duration = 1;
    [SerializeField] private float _targetRotationByY = 360;

    private Stopwatch _stopwatch = new Stopwatch();
    
    public void SomeAction()
    {
        Debug.Log("Action!");
    }

    private void Start()
    {
        //StartCoroutine(Animate());
        StartCoroutine(AnimateWithStopwatch());
    }

    private IEnumerator Animate(float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        var startTime = Time.time;

        while (Time.time - startTime < _duration)
        {
            var progress = (Time.time - startTime) / _duration;
            Debug.Log(progress);
            
            var curvedProgress = _curve.Evaluate(progress);
            var targetRotation = transform.localEulerAngles;
            targetRotation.y = curvedProgress * _targetRotationByY;
            transform.localEulerAngles = targetRotation;
            yield return null;
        }
    }
    
    private IEnumerator AnimateWithStopwatch(float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        _stopwatch.Start();
        double durationInMilliseconds = _duration * 1000;

        while (_stopwatch.Elapsed.TotalMilliseconds < durationInMilliseconds)
        {
            var progress = (float) (_stopwatch.Elapsed.TotalMilliseconds / durationInMilliseconds);
            var curvedProgress = _curve.Evaluate(progress);
            var targetRotation = transform.localEulerAngles;
            targetRotation.y = curvedProgress * _targetRotationByY;
            transform.localEulerAngles = targetRotation;
            yield return null;
        }
    }
}
