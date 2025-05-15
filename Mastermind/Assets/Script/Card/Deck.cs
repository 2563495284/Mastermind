using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [Header("卡牌堆配置")]
    public CardData.CardIdentity deckIdentity = CardData.CardIdentity.Neutral;
    public string deckName = "默认卡牌堆";
    
    [Header("卡牌堆")]
    public List<CardData> drawPile = new List<CardData>();
    public List<CardData> discardPile = new List<CardData>();
    public List<CardData> exhaustedPile = new List<CardData>();
    public List<CardData> handCards = new List<CardData>();

    [Header("设置")]
    public int maxHandSize = 5;

    // 初始化卡牌堆
    public void InitializeDeck(List<CardData> initialCards)
    {
        drawPile.Clear();
        discardPile.Clear();
        exhaustedPile.Clear();
        handCards.Clear();
        
        drawPile.AddRange(initialCards);
        Shuffle(drawPile);
    }

    // 洗牌，将弃牌堆洗入抽牌堆
    public void ShuffleDiscardIntoDraw()
    {
        drawPile.AddRange(discardPile);
        discardPile.Clear();
        Shuffle(drawPile);
    }

    // 抽一张牌到手牌
    public CardData DrawCard()
    {
        if (handCards.Count >= maxHandSize) return null;
        
        if (drawPile.Count == 0)
        {
            ShuffleDiscardIntoDraw();
            if (drawPile.Count == 0) return null; // 没有牌可抽
        }
        
        CardData card = drawPile[0];
        drawPile.RemoveAt(0);
        handCards.Add(card);
        return card;
    }

    // 从手牌打出卡牌
    public CardData PlayCard(int handIndex)
    {
        if (handIndex >= 0 && handIndex < handCards.Count)
        {
            CardData card = handCards[handIndex];
            handCards.RemoveAt(handIndex);
            return card;
        }
        return null;
    }

    // 弃牌
    public void Discard(CardData card)
    {
        if (card != null)
        {
            discardPile.Add(card);
        }
    }

    // 消耗牌（如被移出本局）
    public void Exhaust(CardData card)
    {
        if (card != null)
        {
            exhaustedPile.Add(card);
        }
    }

    // 洗牌算法
    private void Shuffle(List<CardData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            CardData temp = list[i];
            list[i] = list[rand];
            list[rand] = temp;
        }
    }

    // 获取当前卡牌堆状态
    public string GetDeckStatus()
    {
        return $"{deckName} - 抽牌堆: {drawPile.Count}, 弃牌堆: {discardPile.Count}, 消耗牌堆: {exhaustedPile.Count}, 手牌: {handCards.Count}";
    }
} 