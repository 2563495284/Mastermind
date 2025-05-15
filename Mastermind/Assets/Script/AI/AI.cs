using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Deck deck;
    public List<CardData> hand = new List<CardData>();
    public int health = 100;
    public float drawInterval = 5f; // 每隔n秒抽一张牌
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= drawInterval)
        {
            DrawAndPlayCard();
            timer = 0f;
        }
    }

    // 抽一张牌并打出
    private void DrawAndPlayCard()
    {
        CardData card = deck.DrawCard();
        if (card != null)
        {
            hand.Add(card);
            // 这里可以添加AI出牌的逻辑，例如直接弃牌或消耗
            deck.Discard(card);
        }
    }
} 