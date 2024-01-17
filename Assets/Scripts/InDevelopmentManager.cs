using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InDevelopmentManager : MonoBehaviour
{

    VisualElement root;
    VisualElement canvas;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        canvas = root.Q("Canvas");

        canvas.RegisterCallback<MouseUpEvent>(BackToSceneOne);
    }

    private void BackToSceneOne(MouseUpEvent e)
    {
        SceneManager.LoadScene(0);
    }

}
