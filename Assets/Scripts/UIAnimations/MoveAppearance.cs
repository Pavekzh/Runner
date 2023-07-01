using System;
using DG.Tweening;
using UnityEngine;

public class MoveAppearance : VisibleManager
{
    [SerializeField] private GameObject target;
    [SerializeField] private Transform endPosition;
    [SerializeField] private AnimationConfig openConfig;
    [SerializeField] private AnimationConfig closeConfig;

    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = target.transform.position;
    }

    protected override void DoClose()
    {
        target.transform.DOMove(startPosition, closeConfig.Duration).SetEase(closeConfig.EaseFuncition);
    }

    protected override void DoOpen()
    {
        target.transform.DOMove(endPosition.position, openConfig.Duration).SetEase(openConfig.EaseFuncition);
    }
}

