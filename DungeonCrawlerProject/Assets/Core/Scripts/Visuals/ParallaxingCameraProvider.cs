using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Core.Visuals
{
    public class ParallaxingCameraProvider : MonoBehaviour
    {
        [SerializeField]
        Camera _camera;

        CameraInfo _cameraInfo;

        // Start is called before the first frame update
        void Awake()
        {
            _camera = Camera.main;
            _cameraInfo = new CameraInfo(_camera);
        }
        
        public CameraInfo ProvideCameraInfo()
        {
            return _cameraInfo;
        }

        public class CameraInfo
        {
            internal CameraInfo(Camera c)
            {
                camera = c;
            }

            private Camera camera { get; }
            public Vector3 CamPosition => camera.transform.position;
        }
    }
}

