using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _whatIsGround;

    public bool CheckGround()
    {
        if (Physics2D.OverlapCircle(_point.position, _radius, _whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool SuperPower()
    {
        return true;
    }
}
