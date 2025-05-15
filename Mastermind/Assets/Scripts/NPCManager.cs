using UnityEngine;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour
{
    [Header("身份设置")]
    public CardData.CardIdentity currentIdentity = CardData.CardIdentity.Bull;
    public float actionInterval = 5f; // NPC行动间隔
    public int cardsPerAction = 1; // 每次行动抽牌数量
    
    [Header("卡牌配置")]
    public List<CardData> initialBullDeck = new List<CardData>();
    public List<CardData> initialBearDeck = new List<CardData>();
    
    private Deck bullDeck;
    private Deck bearDeck;
    private float actionTimer = 0f;
    private KLineManager kLineManager;

    private void Start()
    {
        kLineManager = FindFirstObjectByType<KLineManager>();
        InitializeDecks();
    }

    private void Update()
    {
        actionTimer += Time.deltaTime;
        if (actionTimer >= actionInterval)
        {
            PerformAction();
            actionTimer = 0f;
        }
    }

    private void InitializeDecks()
    {
        // 初始化多方卡牌堆
        bullDeck = gameObject.AddComponent<Deck>();
        bullDeck.deckName = "NPC多方卡牌堆";
        bullDeck.deckIdentity = CardData.CardIdentity.Bull;
        bullDeck.InitializeDeck(initialBullDeck);

        // 初始化空方卡牌堆
        bearDeck = gameObject.AddComponent<Deck>();
        bearDeck.deckName = "NPC空方卡牌堆";
        bearDeck.deckIdentity = CardData.CardIdentity.Bear;
        bearDeck.InitializeDeck(initialBearDeck);
    }

    private void PerformAction()
    {
        Deck currentDeck = currentIdentity == CardData.CardIdentity.Bull ? bullDeck : bearDeck;
        
        for (int i = 0; i < cardsPerAction; i++)
        {
            CardData selectedCard = currentDeck.DrawCard();
            if (selectedCard != null)
            {
                // 应用卡牌效果
                if (selectedCard.canSwitchIdentity)
                {
                    currentIdentity = selectedCard.targetIdentity;
                    Debug.Log($"NPC切换身份为: {currentIdentity}");
                }
                else
                {
                    kLineManager.ModifyPrice(selectedCard.priceEffect);
                    Debug.Log($"NPC打出卡牌: {selectedCard.cardName}, 价格影响: {selectedCard.priceEffect}");
                }
                currentDeck.Discard(selectedCard);
            }
        }
    }

    // 获取当前卡牌堆状态
    public string GetDeckStatus()
    {
        return $"当前身份: {currentIdentity}\n" +
               $"多方卡牌堆: {bullDeck.GetDeckStatus()}\n" +
               $"空方卡牌堆: {bearDeck.GetDeckStatus()}";
    }
} 