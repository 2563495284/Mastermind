using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Deck deck;
    public List<CardData> hand = new List<CardData>();
    public int health = 100;

    // 添加卡牌到手牌
    public void AddCardToHand(CardData card)
    {
        hand.Add(card);
    }
} 