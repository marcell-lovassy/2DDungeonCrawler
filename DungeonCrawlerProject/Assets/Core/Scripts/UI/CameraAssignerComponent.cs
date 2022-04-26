using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

[RequireComponent(typeof(Canvas))]
public class CameraAssignerComponent : MonoBehaviour
{
    private Canvas canvas;

    [SerializeField]
    private int planeDistance;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetUpCanvas();
    }

    private void OnLevelWasLoaded(int level)
    {
        SetUpCanvas();
    }

    private void SetUpCanvas()
    {
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.pixelPerfect = true;
        canvas.worldCamera = Camera.main;
        canvas.planeDistance = planeDistance;
    }

}
