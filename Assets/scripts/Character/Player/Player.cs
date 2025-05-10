using UnityEngine;

public class Player : CharacterBase
{
    public CardLayoutManager layoutManager;//卡牌布局管理器
    public PlayerCardManager cardManager;
    public CardLibrarySO library;//存放初始卡牌库

    private void Awake()
    {
        cardManager = new PlayerCardManager(library);
        SetPlayer("player1",100);
    }

    public void SetPlayer(string playerName, int maxHP)
    {
        this.characterName = playerName;
        this.maxHP = maxHP;
    }
}
