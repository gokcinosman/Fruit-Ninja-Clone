
using UnityEngine;


namespace PlayerSystem
{
    public class Blade : MonoBehaviour
    {
        private Camera mainCamera;
        public Vector3 direction { get; private set; }
        private Collider bladeCollider;
        public float sliceForce = 5f;
        private TrailRenderer bladeTrail;
        private bool isCutting;
        public float minSliceVelocity = 0.1f;



        private void Awake()
        {
            bladeTrail = GetComponentInChildren<TrailRenderer>();
            mainCamera = Camera.main;
            bladeCollider = GetComponent<Collider>();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartSlicing();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopSlicing();
            }
            else if (isCutting)
            {
                ContinueSlicing();
            }
        }
        private void OnEnable()
        {
            StopSlicing();
        }
        void OnDisable()
        {
            StopSlicing();
        }
        private void StartSlicing()
        {
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;
            transform.position = newPosition;
            isCutting = true;
            bladeCollider.enabled = true;
            bladeTrail.enabled = true;
            bladeTrail.Clear();
        }
        private void StopSlicing()
        {

            isCutting = false;
            bladeCollider.enabled = false;
            bladeTrail.enabled = false;
        }
        private void ContinueSlicing()
        {
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;
            direction = newPosition - transform.position;
            float velocity = direction.magnitude / Time.deltaTime;
            bladeCollider.enabled = velocity > minSliceVelocity;
            transform.position = newPosition;

        }



    }
}