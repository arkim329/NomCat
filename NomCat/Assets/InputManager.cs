using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public Camera controlCamera;
    RaycastHit2D hit;

    delegate void InputEvent();
    InputEvent inputEvent;

    Cat rightCat, leftCat;

    void Awake()
    {
        if (Application.isMobilePlatform)
            inputEvent = new InputEvent(MobileUpdate);
        else
            inputEvent = new InputEvent(DesktopUpdate);
    }

    void Update()
    {
        inputEvent();
    }

    void DesktopUpdate()
    {
        //click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 point = controlCamera.ScreenPointToRay(Input.mousePosition).origin;
            hit = Physics2D.Raycast(point, Vector2.zero);
            if (!hit.transform) return;
            if (hit.transform.GetComponent<Cat>())
            {
                leftCat = rightCat = hit.transform.GetComponent<Cat>();
                leftCat.ChangeStateEat();
                rightCat.ChangeStateEat();
            }
        }

        //release
        if (Input.GetMouseButtonUp(0))
        {
            if (leftCat != null && rightCat != null)
            {
                leftCat.ChangeStateIdle();
                rightCat.ChangeStateIdle();
            }
        }
    }

    void MobileUpdate()
    {
        //input start
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            Touch firstTouch = Input.GetTouch(0);

            Vector2 point = controlCamera.ScreenPointToRay(firstTouch.position).origin;
            hit = Physics2D.Raycast(point, Vector2.zero);
            if (!hit.transform) return;
        }
    }
}
