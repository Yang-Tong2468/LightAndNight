using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDataSO" , menuName = "Card/CardDataSO")]
public class CardDataSO : Item
{
    public int cost;
    public CardType cardType;

    //执行的实际效果
    public List<Effect> effects;
    public List<StatusEffect> statusEffects;

    public void Initialize(string name, Sprite image, int cost, CardType type, string description, List<Effect> effects, List<StatusEffect> statusEffects)
    {
        
    }
}
