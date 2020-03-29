using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New movement type", menuName = "Movement/Type")]
public class MovementType : ScriptableObject
{
    public string typeName;
    //slowleness for directions
    public float upRate;
    public float downRate;
    public float rightRate;
    public float leftRate;
}
