using System.Collections;
using GameEventSystem;
using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public GameEvent onBombExploded;
    public Image fadeImage;

    private void Awake()
    {
        fadeImage = FindObjectOfType<Image>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            onBombExploded.Raise(this, null);


        }

    }



}
