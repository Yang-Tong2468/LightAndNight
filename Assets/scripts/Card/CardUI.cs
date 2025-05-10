// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;

// public class CardUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     public Card card; // 卡牌数据
//     public Image cardImage; // 卡牌 UI
//     private Transform originalParent; // 原始父对象
//     private Vector3 originalPosition; // 原始位置

//     public void Initialize(Card cardData)
//     {
//         card = cardData;
//         cardImage.sprite = card.cardSprite;
//     }

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         originalParent = transform.parent;
//         originalPosition = transform.position;
//         transform.SetParent(transform.root); // 拖拽时设置为顶层
//         transform.SetAsLastSibling(); // 确保卡牌在最上层
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         transform.position = eventData.position; // 跟随鼠标移动
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         // 检测是否拖拽到 Boss 身上
//         RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(eventData.position), Vector2.zero);
//         if (hit.collider != null && hit.collider.CompareTag("Boss"))
//         {
//             Boss1 boss = hit.collider.GetComponent<Boss1>();
//             if (boss != null)
//             {
//                 boss.TakeDamage(card.damage);
//                 Debug.Log($"使用了 {card.cardName} 对 {boss.bossName} 造成了 {card.damage} 点伤害。");
//             }
//         }

//         // 重置卡牌位置
//         transform.SetParent(originalParent);
//         transform.position = originalPosition;
//     }
// }


using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Card card; // 卡牌数据
    public Image cardImage; // 卡牌 UI
    private Transform originalParent; // 原始父对象
    private Vector3 originalPosition; // 原始位置

    private Vector3 originalScale; // 原始缩放比例

    public void Initialize(Card cardData)
    {
        card = cardData;
        cardImage.sprite = card.cardSprite.sprite;
        originalScale = transform.localScale; // 记录原始缩放比例
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalPosition = transform.position;
        transform.SetParent(transform.root); // 拖拽时设置为顶层
        transform.SetAsLastSibling(); // 确保卡牌在最上层
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // 跟随鼠标移动
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 检测是否拖拽到 Boss 身上
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(eventData.position), Vector2.zero);
        if (hit.collider != null && hit.collider.CompareTag("Boss"))
        {
            Boss1 boss = hit.collider.GetComponent<Boss1>();
            if (boss != null)
            {
                boss.TakeDamage(card.damage);
                Debug.Log($"使用了 {card.cardName} 对 {boss.bossName} 造成了 {card.damage} 点伤害。");
            }
        }

        // 重置卡牌位置
        transform.SetParent(originalParent);
        transform.position = originalPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 鼠标进入时将卡牌放大为1.5倍
        transform.localScale = originalScale * 1.35f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 鼠标离开时恢复卡牌的原始大小
        transform.localScale = originalScale;
    }
}