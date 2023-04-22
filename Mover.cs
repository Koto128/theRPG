using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            MoveToCursor();
        }
        UpdateAnimator();
    }

    void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool isHit = Physics.Raycast(ray, out hitInfo);//Physics.Raycast ==> bool(hit koreche ki kore ni)
        if (isHit)
        {
            transform.gameObject.GetComponent<NavMeshAgent>().destination = hitInfo.point;
        }
    }

    void UpdateAnimator()
    {
        Vector3 velocity =  GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}
