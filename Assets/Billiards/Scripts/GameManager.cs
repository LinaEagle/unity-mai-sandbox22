using UnityEngine;

namespace Billiards
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Transform _cue;
        [SerializeField] private Transform _cueBall;
        [SerializeField] private float _force = 10;
        [SerializeField] private float _cueDistanceToBall = 1;
        private Vector3 _direction;
        [SerializeField] private ForceMode _forceMode;
        private Camera _camera;

        private Vector3 WorldMousePosition
        {
            get
            {
                var mousePos = Input.mousePosition;
                mousePos.z = _camera.farClipPlane;
                var position = _camera.ScreenToWorldPoint(mousePos);
                position.y = 0;
                return position;
            }
        }

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            var ballPos = new Vector3(_cueBall.position.x, 0, _cueBall.position.z);

            _direction = (WorldMousePosition - ballPos).normalized;
            var targetCuePosition = ballPos + _direction * _cueDistanceToBall;
            _cue.position = new Vector3(targetCuePosition.x, _cue.position.y, targetCuePosition.z);
            _cue.LookAt(new Vector3(ballPos.x, _cue.position.y, ballPos.z), Vector3.up);
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _cueBall.GetComponent<Rigidbody>().AddForce(_cue.forward * _force, _forceMode);
            }
        }

        private void OnDrawGizmos()
        {
            var ray = new Ray(_cueBall.position, (_cue.position - _cueBall.position).normalized);
            Gizmos.DrawRay(ray);
        }
    }
}
