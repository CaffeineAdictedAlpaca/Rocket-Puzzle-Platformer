using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject test;
    [SerializeField, Range(0.5f, 100)] float maxRadius;
    RaycastHit rocketHit;
    [SerializeField] LayerMask mask;
    public float exploForce;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(rocketHit.point, maxRadius);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray lineOfSight = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(lineOfSight,out rocketHit))
            {
                //print(rocketHit.point);
                //Instantiate(test, rocketHit.point, Quaternion.identity);
               Collider[] objNear = Physics.OverlapSphere(rocketHit.point, maxRadius, mask);
                for (int i = 0; i < objNear.Length; i++)
                {
                    objNear[i].GetComponent<Rigidbody>().AddExplosionForce(exploForce, rocketHit.point, maxRadius);
                  //Destroy(objNear[i].gameObject);
                  
                }
            }
        }
       
    }
}
