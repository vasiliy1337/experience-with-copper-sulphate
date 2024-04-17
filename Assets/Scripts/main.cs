using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main : MonoBehaviour
{

    public static bool WaterExists = false;
    public static bool ColoredWater = false;
    public static bool InWater = false;
    public Camera firstCamera;
    public Camera secondCamera;
    private Button resetButton;

    // Start is called before the first frame update
    void Start()
    {
        resetButton = GetComponent<Button>(); // Получаем компонент кнопки
        resetButton.onClick.AddListener(ResetScene); // Связываем нажатие на кнопку с методом ResetScene
        firstCamera.enabled = true;
        secondCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            firstCamera.enabled = !firstCamera.enabled;
            secondCamera.enabled = !secondCamera.enabled;
        }
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Загружаем текущую сцену заново
        WaterExists = false;
        ColoredWater = false;
        InWater = false;
    }

}
