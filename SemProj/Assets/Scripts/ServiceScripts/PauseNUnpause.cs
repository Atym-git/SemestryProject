using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseNUnpause : MonoBehaviour
{
    private bool _isPaused;

    [SerializeField] private CameraZoom cameraZoom;

    public void Pause()
    {
        Time.timeScale = 0f;
        _isPaused = true;
        cameraZoom.Pause(_isPaused);
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        _isPaused = false;
        cameraZoom.Pause(_isPaused);
    }
}