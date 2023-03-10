using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PathCreator : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    public List<Vector3> _points = new List<Vector3>();
    public Action<IEnumerable<Vector3>> OnNewPathCreated = delegate { };
    private Camera _camera;
    private IPointerClickHandler _pointerClickHandlerImplementation;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _points.Clear();
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Cube"))
                {  
                    return;
                }
                _points.Add(hitInfo.point);
                _lineRenderer.positionCount = _points.Count;
                //if (DistanceToLastPoint(hitInfo.point) > .000000000001f)
                //{
                    _points.Add(hitInfo.point);
                    _lineRenderer.positionCount = _points.Count;
                    _lineRenderer.SetPositions(_points.ToArray());
                    /*for (int i = 0; i < _points.Count; i++)
                    {
                        _lineRenderer.SetPosition(i,_points[i]);
                    }*/
                    
                //}
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            OnNewPathCreated(_points);
        }
    }

    
    public float DistanceToLastPoint(Vector3 point)
    {
        if (!_points.Any())
        {
            return Mathf.Infinity;
        }

        return Vector3.Distance(_points.Last(), point);
    }

    
}
