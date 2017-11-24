using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateController : MonoBehaviour {
    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;

    public Text angularVelocityText;

    public float rotateSpeed;

    public void Start()
    {
        this.GetComponent<Rigidbody>().maxAngularVelocity = 100f;
    }

    private void FixedUpdate()
    {
       
    }


    void Update()
    {
        angularVelocityText.text = ""+this.GetComponent<Rigidbody>().angularVelocity.y;
        //#if UNITY_ANDROID
        if (Input.touchCount > 0)

        {

            Touch touch = Input.touches[0];



            switch (touch.phase)

            {

                case TouchPhase.Began:

                    startPos = touch.position;

                    break;



                case TouchPhase.Ended:

                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY)

                    {

                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeValue > 0)//up swipe
                        {

                        }
                             //Jump ();

                        else if (swipeValue < 0)//down swipe
                        {

                        }
                             //Shrink ();

                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX)

                    {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0)//right swipe
                        {
                          //  this.GetComponent<Rigidbody>().angularVelocity *= 5f;
                            this.GetComponent<Rigidbody>().AddTorque(transform.up * -rotateSpeed *Time.deltaTime, ForceMode.Force );
                            this.GetComponent<Rigidbody>().AddTorque(this.GetComponent<Rigidbody>().angularVelocity * 500f * Time.deltaTime);
                        }
                             //MoveRight ();

                        else if (swipeValue < 0)//left swipe
                        {
                          //  this.GetComponent<Rigidbody>().angularVelocity *= 50000f;

                            this.GetComponent<Rigidbody>().AddTorque(transform.up * rotateSpeed *Time.deltaTime, ForceMode.Force);
                            this.GetComponent<Rigidbody>().AddTorque(this.GetComponent<Rigidbody>().angularVelocity * 500f*Time.deltaTime);
                        }
                             //MoveLeft ();

                    }
                    break;
            }
        }
    }
}


