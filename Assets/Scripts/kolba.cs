using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kolba : MonoBehaviour
{
    //public Material newMaterial;

    public GameObject water;
    public Color startColor;
    public Color endColor;
    public float duration = 5.0f;


    private Renderer water_render;
    private bool changedColor = false;

    void Start()
    {
        // Находим компонент Renderer на объекте
        water_render = water.GetComponent<Renderer>();
        water.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (main.ColoredWater && !changedColor)
            StartCoroutine(ChangeColor());
        if (main.WaterExists)
            water.SetActive(true);
    }

    IEnumerator ChangeColor()
    {
        changedColor = true;
        float time = 0;

        while (time < duration)
        {
            water_render.material.color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        water_render.material.color = endColor;
    }
}
