using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject interactText;//drag and drop InteractText in unity -Sixten
    public bool canInteract = false;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        _Start();
        interactText.SetActive(false);//hide interact text on start -Sixten
    }

    // Update is called once per frame
    void Update()
    {
        _Update();
        if (canInteract == true && Input.GetKeyDown(KeyCode.E))
        {
            _Interact();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            interactText.SetActive(true);
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            interactText.SetActive(false);
            canInteract = false;
        }
    }
    public virtual void _Start()//override this to use start in child script -Sixten
    {

    }
    public virtual void _Interact()//ovveride this to set what hapens on interact -Sixten
    {

    }

    public virtual void _Update()//override this to use update in child script -Sixten

    {

    }
}
