using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
    //このコードだけは開発時につまづいてしまったのでネットで調べてから引用しています。
    //もちろんコードの内容を知らないと後に不具合が起きた際に対応できないのでコードリーディングを行ってから使用しています。
{
    [SerializeField]
    private Transform target; // 追従する対象
    [SerializeField]
    private Vector3 offset; // オフセット（World Spaceのオフセット）
    private RectTransform rectTransform;

    public void SetTarget(Transform target, Vector3 offset)
    {
        this.target = target;
        this.offset = offset;
        rectTransform = GetComponent<RectTransform>();
        RefreshPosition();
    }
    public void SetTarget(Transform target)
    {
        SetTarget(target, Vector3.zero);
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        RefreshPosition();
    }

    private void RefreshPosition()
    {
        if (target)
        {
            // World PositionをScreen Positionに変換
            Vector2 screenPos = Camera.main.WorldToScreenPoint(target.position + offset);
            rectTransform.position = screenPos;
        }
    }
}
