using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screpka : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public float duration = 5.0f;

    private Renderer objectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Находим компонент Renderer на объекте
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Присваиваем объекту новый цвет
        if (main.ColoredWater && main.InWater)
            StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        float time = 0;

        while (time < duration)
        {
            objectRenderer.material.color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        objectRenderer.material.color = endColor;
    }
}
