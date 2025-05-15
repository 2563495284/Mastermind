using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Card/Create New CardData")]
public class CardData : ScriptableObject
{
    public string cardName;
    public string description;
    public Sprite cardImage;
    
    [Header("卡牌效果")]
    public float priceEffect; // 对价格的影响
    public int cost; // 使用卡牌消耗的资金
    
    [Header("卡牌类型")]
    public CardType cardType;
    public CardIdentity cardIdentity; // 卡牌所属阵营
    
    [Header("特殊效果")]
    public bool canSwitchIdentity; // 是否可以切换身份
    public CardIdentity targetIdentity; // 切换到的身份
    public bool isSpecial; // 是否是特殊卡牌
    public float effectDuration; // 效果持续时间
    
    public enum CardType
    {
        Player, // 玩家卡牌
        NPC,    // NPC卡牌
        Event   // 事件卡牌
    }
    
    public enum CardIdentity
    {
        Neutral, // 中立
        Bull,    // 多方
        Bear     // 空方
    }
} 