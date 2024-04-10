using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    GameObject raket;
    [SerializeField, Range(0.5f, 100)] float maxRadius;
    public Vector3 barrel;
    [SerializeField] LayerMask mask;
    public float exploForce;
    public GameObject raketprefab;
    RaycastHit rocketHit;
    

   

    // Start is called before the first frame update
    void Start()
    {
        raket = Instantiate(raketprefab, barrel, Quaternion.identity);
       
    }

    public void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(rocketHit.point, maxRadius);
    }

    // Update is called once per frame
    void Update()
    {
        //raket.transform.position = rocketHit;//make raycasthit to a vector3.
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
             Ray lineOfSight = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(lineOfSight,out rocketHit))
             {
            //print(rocketHit.point);
         
               Instantiate(raketprefab, barrel, Quaternion.identity);
                
            
               Collider[] objNear = Physics.OverlapSphere(barrel, maxRadius, mask);
                for (int i = 0; i < objNear.Length; i++)
                {
                    objNear[i].GetComponent<Rigidbody>().AddExplosionForce(exploForce, barrel, maxRadius);
                  //Destroy(objNear[i].gameObject);
                  
                }
            }
        }
       
    }
}
