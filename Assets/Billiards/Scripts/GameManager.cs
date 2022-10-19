using System;
using UnityEngine;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _cue;
    [SerializeField] private Transform _cueBall;
    [SerializeField] private float _force = 10;
    [SerializeField] private float _cueDistanceToBall = 1;
    private Vector3 _direction;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.farClipPlane;
        var cuePosition = Camera.main.ScreenToWorldPoint(mousePos);
        cuePosition.y = 0;

        var ballPos = new Vector3(_cueBall.position.x, 0, _cueBall.position.z);

        _direction = (cuePosition - ballPos).normalized;
        var targetCuePosition = ballPos + _direction * _cueDistanceToBall;
        _cue.position = new Vector3(targetCuePosition.x, _cue.position.y, targetCuePosition.z);
        _cue.LookAt(new Vector3(ballPos.x, _cue.position.y, ballPos.z), Vector3.up);
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _cueBall.GetComponent<Rigidbody>().AddForce(_cue.forward * _force, ForceMode.VelocityChange);
        }
    }

    private void OnDrawGizmos()
    {
        var ray = new Ray(_cueBall.position, (_cue.position - _cueBall.position).normalized);
        Gizmos.DrawRay(ray);
    }
}
