using System.Collections;
using System.Collections.Generic;
using FruitSystem;
using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Blade blade;
    public Spawner spawner;
    public TMPro.TextMeshProUGUI scoreText;
    public Image fadeImage;

    private void Awake()
    {

        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
    }

    public void Failed()
    {
        spawner.enabled = false;
        blade.enabled = false;
        StartCoroutine(ExplodeSequence());

    }
    public void ResetGame()
    {

        Time.timeScale = 1;
        spawner.enabled = true;
        blade.enabled = true;
        scoreText.text = "0";
        ClearScene();

    }
    void ClearScene()
    {

        Fruit[] fruits = FindObjectsOfType<Fruit>();
        foreach (Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }
        Bomb[] bombs = FindObjectsOfType<Bomb>();
        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }
    }
    public IEnumerator ExplodeSequence()
    {

        float elapsed = 0f;
        float duration = 0.5f;
        while (elapsed < duration)
        {
            float alpha = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, alpha);
            Time.timeScale = 1f - alpha;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);
        ResetGame();


        elapsed = 0f; // İlk döngü bittiğinde elapsed'ı sıfırla


        while (elapsed < duration)
        {
            float alpha = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, alpha);
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

    }

}
