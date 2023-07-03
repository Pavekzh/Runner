using System;
using DG.Tweening;
using UnityEngine;

public class MoveAppearance : VisibleManager
{
    [SerializeField] private RectTransform target;
    [SerializeField] private RectTransform endPosition;
    [SerializeField] private AnimationConfig openConfig;
    [SerializeField] private AnimationConfig closeConfig;

    private Vector2 startPosition;

    private void Awake()
    {
        startPosition = target.anchoredPosition;
    }

    protected override void DoClose()
    {
        target.DOAnchorPos(startPosition, closeConfig.Duration).SetEase(closeConfig.EaseFuncition);
    }

    protected override void DoOpen()
    {
        target.DOAnchorPos(endPosition.anchoredPosition, openConfig.Duration).SetEase(openConfig.EaseFuncition);
    }
}

