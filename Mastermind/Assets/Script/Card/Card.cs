using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardData;

    // 初始化卡牌
    public void Init(CardData data)
    {
        cardData = data;
        // 这里可以添加后续的UI展示等逻辑
    }

    // 展示卡牌信息（可扩展为UI显示）
    public void ShowCardInfo()
    {
        Debug.Log($"卡牌名称: {cardData.cardName}, 价格影响: {cardData.priceEffect}, 描述: {cardData.description}");
    }
}
