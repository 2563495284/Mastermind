using UnityEngine;
using System.Collections.Generic;

public class RandomEventManager : MonoBehaviour
{
    [Header("事件配置")]
    public List<CardData> possibleEvents = new List<CardData>();
    public float eventCheckInterval = 10f; // 检查随机事件的间隔
    
    private float eventTimer = 0f;
    private KLineManager kLineManager;
    private List<CardData> activeEvents = new List<CardData>();

    private void Start()
    {
        kLineManager = FindObjectOfType<KLineManager>();
        InitializeEvents();
    }

    private void Update()
    {
        eventTimer += Time.deltaTime;
        if (eventTimer >= eventCheckInterval)
        {
            CheckForRandomEvent();
            eventTimer = 0f;
        }

        // 更新活跃事件
        UpdateActiveEvents();
    }

    private void InitializeEvents()
    {
        // 这里可以通过Unity编辑器配置事件
        // 或者通过Resources.Load加载预设的事件数据
    }

    private void CheckForRandomEvent()
    {
        foreach (var randomEvent in possibleEvents)
        {
            if (Random.value < 0.2f) // 20%的触发概率
            {
                TriggerEvent(randomEvent);
            }
        }
    }

    private void TriggerEvent(CardData randomEvent)
    {
        Debug.Log($"触发随机事件: {randomEvent.cardName} - {randomEvent.description}");
        activeEvents.Add(randomEvent);
        kLineManager.ModifyPrice(randomEvent.priceEffect);
    }

    private void UpdateActiveEvents()
    {
        for (int i = activeEvents.Count - 1; i >= 0; i--)
        {
            activeEvents[i].effectDuration -= Time.deltaTime;
            if (activeEvents[i].effectDuration <= 0)
            {
                activeEvents.RemoveAt(i);
            }
        }
    }
} 