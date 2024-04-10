using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interact
{
    [Header("Adjustment")]
    [SerializeField] float travel;
    [SerializeField] float time;

    Vector3 destination;
    Vector3 origin;

    public bool activated;

    [SerializeField] Material green;

    public override void Start()
    {
        base.Start();

        origin = transform.localPosition;
    }
    // Update is called once per frame
    public override void _Interact()
    {
        destination = transform.localPosition + transform.right * travel;
        StartCoroutine(MoveObject());
        interactText.SetActive(false);
    }
    public IEnumerator MoveObject()
    {
        float totalMovementTime = time; //the amount of time you want the movement to take
        float currentMovementTime = 0f;//The amount of time that has passed
        while (Vector3.Distance(transform.localPosition, destination) > 0)
        {
            canInteract = false;
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(origin, destination, currentMovementTime / totalMovementTime);
            yield return null;
        }
        activated = true;
        gameObject.GetComponent<Renderer>().material = new Material(green);
        StartCoroutine(MoveObject2());
    }
    public IEnumerator MoveObject2()
    {
        float totalMovementTime = time; //the amount of time you want the movement to take
        float currentMovementTime = 0f;//The amount of time that has passed
        while (Vector3.Distance(transform.localPosition, origin) > 0)
        {
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(destination, origin, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }
}
