using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;
    private float _speed = 2f;
    private bool _isReach = true;

    void Update()
    {
        if (_isReach)
        {
            transform.position = Vector3.MoveTowards(transform.position, _secondPoint.position, _speed * Time.deltaTime);

            if (transform.position == _secondPoint.position)
            {
                _isReach = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _firstPoint.position, _speed * Time.deltaTime);
                
            if (transform.position == _firstPoint.position)
            {
                _isReach = true;
            }
        }
    }
}
