using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interact
{
    [SerializeField] bool NegativeY;
    [SerializeField] bool NegativeX;
    [SerializeField] bool Y;
    [SerializeField] bool X;

    [SerializeField] float travel;
    [SerializeField] float time;

    Vector3 destination;
    Vector3 origin;

    public override void Start()
    {
        base.Start();

        origin = transform.position;
    }
    // Update is called once per frame
    public override void _Interact()
    {
        if (NegativeX)
        {
            destination = new Vector3(transform.position.x - travel, transform.position.y, transform.position.z);
            StartCoroutine(moveObject());
        }
    }
    public IEnumerator moveObject()
    {
        float totalMovementTime = time; //the amount of time you want the movement to take
        float currentMovementTime = 0f;//The amount of time that has passed
        while (Vector3.Distance(transform.localPosition, destination) > 0)
        {
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(origin, destination, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }
}
