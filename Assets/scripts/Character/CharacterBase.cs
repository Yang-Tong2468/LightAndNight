using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseNew : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public int maxMP;
    public int currentMP;

    public string characterName;

    public List<CardDataSO> cardDatas;
    public List<Card> handCards;
 


    private void Awake()
    {
        //cardManager = new PlayerCardManager();
    }

    public void TakeDamage(int damage)
    {
        if(currentHP < damage)
        {
            currentHP = 0;
            Died();
        }
        currentHP -= damage;
    }

    public virtual void Died()
    {
        Debug.Log(this.characterName + "Died");
    }
}
