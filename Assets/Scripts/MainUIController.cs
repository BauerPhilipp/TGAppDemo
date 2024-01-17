using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainUIController : MonoBehaviour
{

    private VisualElement root;
    private VisualElement countryButton;
    private ScrollView scrollViewMain;


    private VisualElement introButton;
    private VisualElement mozartButton;
    private VisualElement aktionenButton;

    private Vector2 localMousePositionStratDrag;
    private bool scrollerDragStarted = false;

    private Vector2 mainScrollerOffsetStart;
    private bool isScrolling = false;


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
        scrollViewMain.RegisterCallback<MouseDownEvent>(MainScrollerMouseDown);
        scrollViewMain.RegisterCallback<MouseUpEvent>(MainScrollerMouseUp);
        scrollViewMain.RegisterCallback<MouseMoveEvent>(MainScrollerMouseMove);

        introButton = root.Q("IntroButton");
        introButton.RegisterCallback<MouseUpEvent>(IntroButtonClicked);

        mozartButton = root.Q("MozartButton");
        mozartButton.RegisterCallback<MouseDownEvent>(MozartButtonClicked);

        aktionenButton = root.Q("AktionenButton");
        aktionenButton.RegisterCallback<MouseDownEvent>(AktionenButtonClicked);

    }

    private void OnCountryButtonClicked(ClickEvent e)
    {
        Debug.Log("Countrybutton clicked!");
    }

    private void MainScrollerMouseDown(MouseDownEvent evt)
    {

        //Debug.Log("scrollerDragStarted: " + scrollerDragStarted + ", isScrolling: " + isScrolling);
        mainScrollerOffsetStart = scrollViewMain.scrollOffset;
        localMousePositionStratDrag = evt.localMousePosition + scrollViewMain.scrollOffset;
        scrollerDragStarted = true;
    }

    private void MainScrollerMouseUp(MouseUpEvent evt)
    {
        scrollerDragStarted = false;
    }

    private void MainScrollerMouseMove(MouseMoveEvent evt)
    {
        if (Mathf.Abs(mainScrollerOffsetStart.y - scrollViewMain.scrollOffset.y) > 50)
        {
            isScrolling = true;
        }
        else
        {
            isScrolling = false;
        }
        if (!scrollerDragStarted) { return; }
        scrollViewMain.scrollOffset = new Vector2(0, localMousePositionStratDrag.y - evt.localMousePosition.y);
    }

    private void IntroButtonClicked(MouseUpEvent evt)
    {
        if(isScrolling) { return; }
        Debug.Log("Intro clicked!");
    }

    private void MozartButtonClicked(MouseDownEvent evt)
    {
        Debug.Log("Mozart clicked!");
    }
    private void AktionenButtonClicked(MouseDownEvent evt)
    {
        Debug.Log("Aktionen clicked!");
    }

}
