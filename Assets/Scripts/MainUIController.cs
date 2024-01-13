using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainUIController : MonoBehaviour
{

    private VisualElement root;
    private VisualElement countryButton;
    private ScrollView scrollViewMain;
    private VisualElement testButton;

    private Vector2 localMousePositionStratDrag;
    private bool scrollerDragStarted = false;


    private void Awake()
    {
        InitUIElements();
    }





    private void InitUIElements()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        countryButton = root.Q("CountryButton");
        countryButton.RegisterCallback<ClickEvent>(OnCountryButtonClicked);

        scrollViewMain = root.Q<ScrollView>();
        scrollViewMain.RegisterCallback<MouseDownEvent>(MouseDown);
        scrollViewMain.RegisterCallback<MouseUpEvent>(MouseUp);
        scrollViewMain.RegisterCallback<MouseMoveEvent>(MouseMove);

        testButton = root.Q("TestButton");
        testButton.RegisterCallback<MouseDownEvent>(ButtonOneClicked);

    }

    private void OnCountryButtonClicked(ClickEvent e)
    {
        Debug.Log("Countrybutton clicked!");
    }

    private void MouseDown(MouseDownEvent evt)
    {
        localMousePositionStratDrag = evt.localMousePosition + scrollViewMain.scrollOffset;
        scrollerDragStarted = true;
    }

    private void MouseUp(MouseUpEvent evt)
    {
        scrollerDragStarted = false;
        //if (Vector2.Distance(dragStart, evt.localMousePosition) > 5)
        //{
        //    evt.StopImmediatePropagation();
        //}
    }

    private void MouseMove(MouseMoveEvent evt)
    {
        if(!scrollerDragStarted) { return; }
        scrollViewMain.scrollOffset = new Vector2(0, localMousePositionStratDrag.y - evt.localMousePosition.y);
    }

    private void ButtonOneClicked(MouseDownEvent evt)
    {
        Debug.Log("Testbutton clicked!");
    }

}
