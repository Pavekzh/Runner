using System;
using UnityEngine;
using DG.Tweening;

public class ExpandAppearance : VisibleManager
{
    [SerializeField] private GameObject target;
    [SerializeField] private float deltaScale = 0.7f;
    [SerializeField] private AnimationConfig openConfig;
    [SerializeField] private AnimationConfig closeConfig;

    protected override void DoClose()
    {
        target.transform.DOScale(deltaScale, closeConfig.Duration).SetEase(closeConfig.EaseFuncition).OnComplete(() => target.SetActive(false));
    }

    protected override void DoOpen()
    {
        target.SetActive(true);
        target.transform.localScale *= deltaScale;
        target.transform.DOScale(1, openConfig.Duration).SetEase(openConfig.EaseFuncition);
    }
}
