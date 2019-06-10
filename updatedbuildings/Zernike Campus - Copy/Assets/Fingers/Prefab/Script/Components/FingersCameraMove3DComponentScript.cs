using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
    [AddComponentMenu("Fingers Gestures/Component/Fingers Camera Move 3D", 4)]
    public class FingersCameraMove3DComponentScript : MonoBehaviour
    {
        [Tooltip("The transform to move, defaults to the transform on this script")]
        public Transform Target;

        [Range(-10.0f, 10.0f)]
        [Tooltip("Controls pan (left/right for strafe, up/down for forward/back) speed in number of world units per screen units panned")]
        public float PanSpeed = -1.0f;

        [Range(-10.0f, 10.0f)]
        [Tooltip("Controls tilt with two finger pan up or down")]
        public float TiltSpeed = -1.0f;

        [Tooltip("Threshold (in units) tilt gesture must move in order to execute")]
        public float TiltThreadhold = 0.3f;

        [Range(-10.0f, 10.0f)]
        [Tooltip("Controls zoom in/out speed")]
        public float ZoomSpeed = 1.0f;

        [Range(-10.0f, 10.0f)]
        [Tooltip("Controls rotation speed")]
        public float RotateSpeed = 1.0f;

        [Range(0.0f, 1.0f)]
        [Tooltip("How much to dampen movement, lower values dampen faster")]
        public float Dampening = 0.95f;

        public PanGestureRecognizer PanGesture { get; private set; }
        public PanGestureRecognizer TiltGesture { get; private set; }
        public ScaleGestureRecognizer ScaleGesture { get; private set; }
        public RotateGestureRecognizer RotateGesture { get; private set; }

        private Vector3 moveVelocity;
        private float tiltVelocity;
        private float angularVelocity;
        private Vector3 zoomVelocity;

        private void PanGestureCallback(GestureRecognizer gesture)
        {
            if (gesture.State == GestureRecognizerState.Executing)
            {
                Quaternion q = Target.rotation;
                q = Quaternion.Euler(0.0f, q.eulerAngles.y, 0.0f);
                moveVelocity += (q * Vector3.right * DeviceInfo.PixelsToUnits(gesture.DeltaX) * Time.deltaTime * PanSpeed * 500.0f);
                moveVelocity += (q * Vector3.forward * DeviceInfo.PixelsToUnits(gesture.DeltaY) * Time.deltaTime * PanSpeed * 500.0f);
            }
        }

        private void TiltGestureCallback(GestureRecognizer gesture)
        {
            if (gesture.State == GestureRecognizerState.Executing)
            {
                tiltVelocity += (DeviceInfo.PixelsToUnits(gesture.DeltaY) * Time.deltaTime * TiltSpeed * 25.0f);
            }
        }

        private void ScaleGestureCallback(GestureRecognizer gesture)
        {
            if (gesture.State == GestureRecognizerState.Executing)
            {
                float zoomSpeed = ScaleGesture.ScaleMultiplierRange;
                zoomVelocity += (Target.forward * zoomSpeed * Time.deltaTime * ZoomSpeed * 25.0f);
            }
        }

        private void RotateGestureCallback(GestureRecognizer gesture)
        {
            if (gesture.State == GestureRecognizerState.Executing)
            {
                angularVelocity += (RotateGesture.RotationDegreesDelta * Time.deltaTime * RotateSpeed * 10.0f);
            }
        }

        private void OnEnable()
        {
            if (Target == null)
            {
                Target = transform;
            }

            PanGesture = new PanGestureRecognizer();
            PanGesture.StateUpdated += PanGestureCallback;
            FingersScript.Instance.AddGesture(PanGesture);

            TiltGesture = new PanGestureRecognizer();
            TiltGesture.StateUpdated += TiltGestureCallback;
            TiltGesture.ThresholdUnits = 0.5f; // higher than normal to not interfere with other gestures
            TiltGesture.MinimumNumberOfTouchesToTrack = TiltGesture.MaximumNumberOfTouchesToTrack = 3;
            FingersScript.Instance.AddGesture(TiltGesture);

            ScaleGesture = new ScaleGestureRecognizer();
            ScaleGesture.StateUpdated += ScaleGestureCallback;
            FingersScript.Instance.AddGesture(ScaleGesture);

            RotateGesture = new RotateGestureRecognizer();
            RotateGesture.StateUpdated += RotateGestureCallback;
            FingersScript.Instance.AddGesture(RotateGesture);

            PanGesture.AllowSimultaneousExecution(ScaleGesture);
            PanGesture.AllowSimultaneousExecution(RotateGesture);
            ScaleGesture.AllowSimultaneousExecution(RotateGesture);
        }

        private void OnDisable()
        {
            if (FingersScript.HasInstance)
            {
                FingersScript.Instance.RemoveGesture(PanGesture);
                FingersScript.Instance.RemoveGesture(ScaleGesture);
                FingersScript.Instance.RemoveGesture(RotateGesture);
            }
        }

        public float minRotation = 50;
        public float maxRotation = 90;
        public float clampXMin = 0.0f;
        public float clampXMax = 0.0f;
        public float clampYMin = 0.0f;
        public float clampYMax = 0.0f;
        public float clampZMin = 0.0f;
        public float clampZMax  = 0.0f;
        public float zoomSpeed = 0.1f;
        private void Update()
        {
            TiltGesture.ThresholdUnits = TiltThreadhold;

            Target.Translate(moveVelocity + zoomVelocity, Space.World);
            Target.Rotate(Vector3.up, angularVelocity, Space.World);
            Target.Rotate(Target.right, tiltVelocity, Space.World);

            moveVelocity *= Dampening;
            tiltVelocity *= Dampening;
            zoomVelocity *= Dampening;
            angularVelocity *= Dampening;

            Camera.main.transform.position = new Vector3(Mathf.Clamp(transform.position.x, clampXMin, clampXMax),
                                                         Mathf.Clamp(transform.position.y, clampYMin, clampYMax),
                                                         Mathf.Clamp(transform.position.z, -clampZMin, clampZMax));

            Vector3 currentRotation = transform.localRotation.eulerAngles;
            currentRotation.x = Mathf.Clamp(currentRotation.x, minRotation, maxRotation);
            transform.localRotation = Quaternion.Euler(currentRotation);

            if(Input.touchCount > 1)
            {
                CameraZoom();
            }
        }

        public float minZoom = 0.0f;
        public float maxZoom = 0.0f;

        void CameraZoom()
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float previousTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagDiff = previousTouchDeltaMag - touchDeltaMag;
            Camera.main.orthographicSize += deltaMagDiff * zoomSpeed;

            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);

        }
    }
}