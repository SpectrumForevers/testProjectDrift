using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] float fastClickTime = 0.2f;
    [SerializeField] GUIManager guiManager;
    float timer;
    [SerializeField] ClickOptions typeClick = ClickOptions.NoClick;
    [SerializeField] SwipeDetect swipeDetect = SwipeDetect.StartSwipe;
    Vector3 startPosition;
    Vector3 endPosition;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            if(swipeDetect == SwipeDetect.StartSwipe)
            {
                startPosition = Input.mousePosition;
                swipeDetect = SwipeDetect.EndSwipe;
            }
            timer += Time.deltaTime;
            if (timer > fastClickTime)
            {
                typeClick = ClickOptions.LongClick;

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            typeClick = ClickOptions.NoClick;
            if (timer < fastClickTime)
            {
                typeClick = ClickOptions.FastClick;
                if (swipeDetect == SwipeDetect.EndSwipe)
                {
                    endPosition = Input.mousePosition;
                    if (startPosition.y < endPosition.y)
                    {
                        guiManager.throwPosition = ThrowPosition.UpThrow;
                    }
                    else
                    {
                        guiManager.throwPosition = ThrowPosition.DownThrow;
                    }
                }
            }

            timer = 0;

        }
    }
    public int GetTypeClick()
    {
        switch (typeClick)
        {
            case ClickOptions.NoClick:
                return 0;

            case ClickOptions.LongClick:
                return 1;

            case ClickOptions.FastClick:
                return 2;
        }
        return 0;
    }
}
enum ClickOptions
{
    NoClick,
    FastClick,
    LongClick
}
enum SwipeDetect
{
    StartSwipe,
    EndSwipe
}