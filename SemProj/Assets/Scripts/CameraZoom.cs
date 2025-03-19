using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private float _maxZoom;
    [SerializeField] private float _minZoom;
    [SerializeField] private float _zoomSpeed;
    [SerializeField] private float _smoothness;

    private float _orthoSize;
    private float _velocity;

    private const string _scrollWheel = "Mouse ScrollWheel";

    private void Awake()
    {
        _camera = Camera.main;
        _orthoSize = _camera.orthographicSize;
    }

    private void LateUpdate()
    {
        Zoom();
    }

    private void Zoom()
    {
        var inputDelta = Input.GetAxis(_scrollWheel);
        var inputDeltaWithSpeed = inputDelta * _zoomSpeed;

        _orthoSize = Mathf.Clamp(_orthoSize - inputDeltaWithSpeed, _minZoom, _maxZoom);

        var newOrthoSize = Mathf.SmoothDamp(
            _camera.orthographicSize,
            _orthoSize,
            ref _velocity,
            _smoothness);

        _camera.orthographicSize = newOrthoSize;
    }

}
