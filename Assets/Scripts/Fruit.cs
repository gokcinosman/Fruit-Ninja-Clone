
using UnityEngine;
using PlayerSystem;
using GameEventSystem;


namespace FruitSystem
{
    public class Fruit : MonoBehaviour, IFruitScore
    {

        public int score;
        public GameEvent fruitSlicedEvent;
        public GameObject wholeFruit;
        public GameObject slicedFruit;
        private Rigidbody fruitRigidbody;
        private Collider fruitCollider;
        private ParticleSystem fruitSlicedParticles;
        private void Awake()
        {
            fruitRigidbody = GetComponent<Rigidbody>();
            fruitCollider = GetComponent<Collider>();
            fruitSlicedParticles = GetComponentInChildren<ParticleSystem>();
        }

        private void Slice(Vector3 direction, Vector3 position, float force)
        {

            wholeFruit.SetActive(false);
            slicedFruit.SetActive(true);
            fruitCollider.enabled = false;
            fruitSlicedParticles.Play();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            slicedFruit.transform.position = transform.position;
            slicedFruit.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            Rigidbody[] slices = slicedFruit.GetComponentsInChildren<Rigidbody>();
            foreach (Transform child in slicedFruit.transform)
            {
                child.localPosition = Vector3.zero;
            }
            foreach (Rigidbody slice in slices)
            {

                slice.velocity = fruitRigidbody.velocity;
                slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
            }
            fruitSlicedEvent.Raise(this, AddScore(score));

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Blade"))
            {
                Debug.Log("Blade hit");
                Blade blade = other.GetComponent<Blade>();
                Slice(blade.direction, blade.transform.position, blade.sliceForce);
            }

        }

        public int AddScore(int score)
        {
            return score;

        }

        public int GetScore()
        {
            throw new System.NotImplementedException();
        }

        public void ResetScore()
        {
            throw new System.NotImplementedException();
        }

    }
}