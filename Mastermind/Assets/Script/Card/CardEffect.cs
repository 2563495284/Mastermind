using UnityEngine;

public class CardEffect : MonoBehaviour
{
    // 插入卡牌到目标玩家的手牌
    public void InsertCardToHand(CardData card, Player targetPlayer)
    {
        targetPlayer.AddCardToHand(card);
    }

    // 插入卡牌到目标玩家的抽牌堆
    public void InsertCardToDrawPile(CardData card, Player targetPlayer)
    {
        targetPlayer.deck.drawPile.Add(card);
    }

    // 插入卡牌到目标玩家的弃牌堆
    public void InsertCardToDiscardPile(CardData card, Player targetPlayer)
    {
        targetPlayer.deck.discardPile.Add(card);
    }
} 