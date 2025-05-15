using UnityEngine;
using System.Collections.Generic;

public class KLineManager : MonoBehaviour
{
    [System.Serializable]
    public class KLinePoint
    {
        public float time;
        public float price;
        public float volume;
    }

    public List<KLinePoint> kLineData = new List<KLinePoint>();
    public float currentPrice = 100f; // 初始价格
    public float gameTime = 0f;
    
    // 价格影响因子
    private float priceMultiplier = 1f;
    
    private void Update()
    {
        gameTime += Time.deltaTime;
        UpdateKLine();
    }

    public void UpdateKLine()
    {
        KLinePoint newPoint = new KLinePoint
        {
            time = gameTime,
            price = currentPrice,
            volume = 0f // 可以根据交易量更新
        };
        
        kLineData.Add(newPoint);
    }

    public void ModifyPrice(float amount)
    {
        currentPrice += amount * priceMultiplier;
        // 确保价格不会低于0
        currentPrice = Mathf.Max(0, currentPrice);
    }

    public void SetPriceMultiplier(float multiplier)
    {
        priceMultiplier = multiplier;
    }
} 