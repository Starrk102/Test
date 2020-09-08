using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Swipe_mouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler/*, IPointerUpHandler, IPointerDownHandler*/
{

    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    Vector2 Vector2_Up;
    Vector2 Vector2_Zero;
    Vector2 Vector2_Down;

    public GameObject Stick;

    bool Token_Swipe = false;
    bool token_long_click = false;

    float Time_f = 0.0f;

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    Token_Swipe = false;
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Token_Swipe = true;
    //}

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    Token_Swipe = true;
    //}

    public void OnPointerEnter(PointerEventData eventData)
    {
        Token_Swipe = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Token_Swipe = false;
    }



    private void Start()
    {
        Vector2_Up = new Vector2(Stick.transform.position.x, Stick.transform.position.y + 25);
        Vector2_Down = new Vector2(Stick.transform.position.x, Stick.transform.position.y - 25);
        Vector2_Zero = Stick.transform.position;
    }

    void Update()
    {
        Debug.Log(Token_Swipe);

        if (token_long_click == true)
        {
            Time_f = Time_f + Time.deltaTime;
            if (Time_f > 0.8f)
            {
                ManagerInput_tumbler.j = 0;
                token_long_click = false;
                Time_f = 0.0f;
            }
        }
        else
        {
            Time_f = 0.0f;
        }

        if (Token_Swipe == true)
        {
            if(Input.GetMouseButton(0))
            {
                //long click
                token_long_click = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                //save began touch 2d point
                firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
            if (Input.GetMouseButtonUp(0))
            {   
                //long click
                token_long_click = false;

                //save ended touch 2d point
                secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                //create vector from the two points
                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    ManagerInput_tumbler.j = 1;
                    Token_Swipe = false;
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    ManagerInput_tumbler.j = -1;
                    Token_Swipe = false;
                }
                //swipe left
                //if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f && Left.activeSelf == true)
                //{
                //    //Massiv.instance.Token();
                //    Right.SetActive(false);
                //    Left.SetActive(false);
                //    Up.SetActive(false);
                //    Down.SetActive(false);
                //    Destroy(this.gameObject);
                //    //Debug.Log("left swipe");
                //}
                //swipe right
                //if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f && Right.activeSelf == true)
                //{
                //    //Massiv.instance.Token();
                //    Right.SetActive(false);
                //    Left.SetActive(false);
                //    Up.SetActive(false);
                //    Down.SetActive(false);
                //    Destroy(this.gameObject);
                //    //Debug.Log("right swipe");
                //}
            }
        }

        if (ManagerInput_tumbler.j == 1)
        {
            Stick.gameObject.GetComponent<RectTransform>().transform.position = Vector2_Up;
        }
        else if (ManagerInput_tumbler.j == -1)
        {
            Stick.gameObject.GetComponent<RectTransform>().transform.position = Vector2_Down;
        }
        else if(ManagerInput_tumbler.j == 0)
        {
            Stick.gameObject.GetComponent<RectTransform>().transform.position = Vector2_Zero;
        }
    }

    public void EnabledToken()
    {
        Token_Swipe = true;
    }

    public void UnabledToken()
    {
        Token_Swipe = false;
    }
}
