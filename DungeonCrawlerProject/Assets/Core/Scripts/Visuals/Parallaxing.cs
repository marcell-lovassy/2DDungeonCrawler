using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Core.Visuals
{
    public class Parallaxing : MonoBehaviour
    {
        ParallaxingCameraProvider.CameraInfo _cameraInfo;
        Vector3 startPosition;
        Vector3 previousCamPosition;

        [SerializeField]
        [Range(0f, 1f)]
        float parallaxEffect = 0.5f;

        // Start is called before the first frame update
        void Start()
        {
            _cameraInfo = gameObject.GetComponentInParent<ParallaxingCameraProvider>().ProvideCameraInfo();
            startPosition = transform.position;
            previousCamPosition = _cameraInfo.CamPosition;
            transform.position = new Vector3(transform.position.x, transform.position.y, parallaxEffect * 10);
        }

        void Update()
        {
            CalculateParallaxPosition();
        }

        private void CalculateParallaxPosition()
        {
            var camPos = _cameraInfo.CamPosition;
            Vector3 camDeltaPosition = camPos - previousCamPosition;
            transform.position += camDeltaPosition * parallaxEffect;
            previousCamPosition = camPos;
        }

        //private Vector3 CalculateParallaxPosition()
        //{
        //    Vector3 camDelta = _cameraInfo.GetCameraDelta();
        //    float parallaxAmountX = transform.position.z == 0f ? 0f : camDelta.x / (1 + 1 / (transform.position.z * parallax));
        //    float parallaxAmountY = transform.position.z == 0f ? 0f : camDelta.y / (1 + 1 / (transform.position.z * parallax));

        //    float x = startPosition.x + parallaxAmountX;
        //    float y = startPosition.y + parallaxAmountY;

        //    Vector3 position = new Vector3(x, y, transform.position.z);
        //    return position;
        //}
    }
}

