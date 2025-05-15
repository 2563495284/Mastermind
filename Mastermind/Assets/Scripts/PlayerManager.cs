using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    [Header("卡牌配置")]
    public List<CardData> initialDeck = new List<CardData>();
    public Deck playerDeck;
    
    [Header("游戏设置")]
    public float initialMoney = 1000f;
    public float currentMoney;
    
    private KLineManager kLineManager;

    private void Start()
    {
        kLineManager = FindObjectOfType<KLineManager>();
        currentMoney = initialMoney;
        InitializeDeck();
    }

    private void InitializeDeck()
    {
        if (playerDeck == null)
        {
            playerDeck = gameObject.AddComponent<Deck>();
            playerDeck.deckName = "玩家卡牌堆";
            playerDeck.deckIdentity = CardData.CardIdentity.Neutral;
        }
        playerDeck.InitializeDeck(initialDeck);
        
        // 抽初始手牌
        for (int i = 0; i < playerDeck.maxHandSize; i++)
        {
            playerDeck.DrawCard();
        }
    }

    public bool PlayCard(int handIndex)
    {
        CardData cardToPlay = playerDeck.PlayCard(handIndex);
        if (cardToPlay != null)
        {
            if (currentMoney >= cardToPlay.cost)
            {
                currentMoney -= cardToPlay.cost;
                kLineManager.ModifyPrice(cardToPlay.priceEffect);
                playerDeck.Discard(cardToPlay);
                playerDeck.DrawCard(); // 抽一张新卡
                return true;
            }
            else
            {
                Debug.Log("资金不足，无法使用该卡牌");
                playerDeck.handCards.Add(cardToPlay); // 将卡牌放回手牌
                return false;
            }
        }
        return false;
    }

    public float CalculateProfit()
    {
        return currentMoney - initialMoney;
    }
} 