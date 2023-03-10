using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CamObstacle : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(new Vector3(0f, 25f, -12f), 2f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
