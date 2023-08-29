using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MobileJoyStick : MonoBehaviour
{
    [Header("Element")]
    [SerializeField] private RectTransform joyStickOutline;
    [SerializeField] private RectTransform joyStickKnob;

    [Header("Setting")]
    [SerializeField] private float moveFactor;
    private Vector3 move;
    private Vector3 clickedPosition;
    private bool canControl;


    // Start is called before the first frame update
    void Start()
    {
        HideJoyStick();
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
        {
            ControlJoyStick();
        }

    }

    public void ClickOnJoyStickZoneCallBack()
    {
        clickedPosition = Input.mousePosition;
        joyStickOutline.position = clickedPosition;

        ShowJoyStick();

    }

    private void ShowJoyStick()//โชว์ JoyStick
    {
        joyStickOutline.gameObject.SetActive(true);
        canControl = true;
    }

    private void HideJoyStick()//ซ่อน joyStick
    {
        joyStickOutline.gameObject.SetActive(false);
        canControl = false;

        move = Vector3.zero;
    }

    private void ControlJoyStick()//ควบคุม joystick
    {
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - clickedPosition;

        float moveMagnitude = direction.magnitude * moveFactor / Screen.width;

        moveMagnitude = Mathf.Min(moveMagnitude, joyStickOutline.rect.width / 2);

        move = direction.normalized * moveMagnitude;

        Vector3 targetPosition = clickedPosition + move;

        joyStickKnob.position = targetPosition;

        if(Input.GetMouseButtonUp(0))
        {
            HideJoyStick();
        }
    }

    public Vector3 GetMoveVector()
    {
        return move;
    }


}//Class
