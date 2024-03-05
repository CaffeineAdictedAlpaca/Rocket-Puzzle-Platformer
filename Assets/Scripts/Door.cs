using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interact
{
    //Sixten gjorde hela det här scriptet
    public bool open;

    [SerializeField] bool moveY;
    [SerializeField] bool moveX;

    [SerializeField] float speed;

    public float maxMove;
    float moveTrack;
    public override void _Interact()//on interact open the door -Sixten
    {
        open = true;
    }
    public override void _Update()
    {
        if (open == true && moveX == true)//define the direction of travel for the door -Sixten
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            moveTrack += speed * Time.deltaTime;
        }
        else if (open == true && moveY == true)//define the direction of travel for the door -Sixten
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            moveTrack += speed * Time.deltaTime;
        }

        if (moveTrack >= maxMove)//stop moving when the door has moved the predetermined max distence(maxMove) -Sixten
        {
            open = false;
        }
    }
}
