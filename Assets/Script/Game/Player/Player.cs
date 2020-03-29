using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int id;

    void Start()
    {
        MovementSystem movementSystem = FindObjectOfType<MovementSystem>();
        movementSystem.RegisterGameObject(GetId(), this.gameObject);
    }

    void Update()
    {
        
    }

    public int GetId() 
    {
        return id;
    }
}
