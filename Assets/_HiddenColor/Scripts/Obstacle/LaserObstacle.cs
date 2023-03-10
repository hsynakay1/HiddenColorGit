using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using DG.Tweening;
using UnityEngine;
using Color = UnityEngine.Color;

public class LaserObstacle : MonoBehaviour
{
    public GameObject player;
    public LineRenderer lineRenderer1;
    public LineRenderer lineRenderer2;
    private Material _buttonMaterial;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        _buttonMaterial =  GetComponentInChildren<Renderer>().materials[0];
    }

    
    void Update()
    {
        if ((transform.position - player.transform.position).sqrMagnitude < 4f)
        {
            CloseLaser();
        }
    }

    private void CloseLaser()
    {
        Vector3[] positions = new Vector3[lineRenderer1.positionCount];
        lineRenderer1.GetPositions(positions);
        Vector3 position = positions[0];
        DOTween.To(() => position.x, x => position.x = x, -22f, 0.2f).OnUpdate(() => {
            positions[0] = position;
            lineRenderer1.SetPositions(positions);
        });
        
        Vector3[] positions2 = new Vector3[lineRenderer2.positionCount];
        lineRenderer2.GetPositions(positions);
        Vector3 position2 = positions[0];
        DOTween.To(() => position.x, x => position.x = x, -22f, 0.2f).OnUpdate(() => {
            positions[0] = position;
            lineRenderer2.SetPositions(positions);
        });
        
        _buttonMaterial.color = Color.green;
    }
}
