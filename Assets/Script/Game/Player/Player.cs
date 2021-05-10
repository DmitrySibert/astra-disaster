using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int id;

    void Start()
    {
    }

    public int GetId() 
    {
        return id;
    }
}
