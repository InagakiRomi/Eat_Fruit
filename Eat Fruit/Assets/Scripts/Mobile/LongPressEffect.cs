using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class LongPressEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float PressDownTimer;
    private bool PressDown; //按下
    public enum Direction
    {
        LButton, RButton
    }
    public Direction Button;

    private MobileWalk MW;

    void Start()
    {
        MW = GameObject.FindGameObjectWithTag("Player").GetComponent<MobileWalk>();
    }
    void FixedUpdate()
    {
        if (Button == Direction.LButton && PressDown == true)
        {
            MW.LefttWalk();
        }
        if (Button == Direction.RButton && PressDown == true)
        {
            MW.RightWalk();
        }
    }
    //按下按鈕
    public void OnPointerDown(PointerEventData eventData)
    {
        PressDown = true;
    }
    //按鈕彈起
    public void OnPointerUp(PointerEventData eventData)
    {
        PressDown = false;
        PressDownTimer = 0;
    }
    //當按下按鈕 PressDown = true 時計時
    void Update()
    {
        if (Button == Direction.LButton && PressDown == true && PressDownTimer >= -1)
        {
            PressDownTimer += -Time.deltaTime;
        }
        if (Button == Direction.RButton && PressDown == true && PressDownTimer <= 1)
        {
            PressDownTimer += Time.deltaTime;
        }
    }
}