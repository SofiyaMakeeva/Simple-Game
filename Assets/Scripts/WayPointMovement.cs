using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;
    private Transform _target;

    private int _angle = 180;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        _target = _points[_currentPoint];
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
        {
            _currentPoint++;

            if (_currentPoint == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (_currentPoint >= _points.Length)
            {
                transform.rotation = Quaternion.Euler(0, _angle, 0);
                _currentPoint = 0;
            }
        }
    }
}
