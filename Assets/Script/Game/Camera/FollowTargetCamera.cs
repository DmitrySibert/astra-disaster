using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.transform.position;
        targetPos.z = transform.position.z;
        transform.position = targetPos;
    }
}
