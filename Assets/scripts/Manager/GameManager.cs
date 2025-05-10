using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Card[] cards; // 卡牌数组
    public CardUI[] cardUIs; // 卡牌 UI 数组
    public Boss1[] bosses; // Boss 数组
    public bool isAutoMode = false; // 是否为自动模式

    public static GameManager instance; // 单例模式实例



    [SerializeField]
    private int _experience; // 序列化字段用于编辑器调试

    public int CurrentExperience => _experience;

    [SerializeField] public Button startButton; // 自动攻击按钮

    public CardData[] cards1;


    [Header("角色管理")]
    public List<CharacterBase> allCharacters; //所有角色
    public List<CharacterBase> playerCharacters; //所有玩家角色
    public List<CharacterBase> enemyCharacters; //所有敌人角色
    public List<CharacterBase> randomCharacters;//随机角色

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1; // 确保时间缩放比例为 1
        //InitializeCards(); // 初始化卡牌
    }

    public void StartAutoAttack()
    {
        //Debug.Log("[调试] 按钮点击事件触发"); // 检查是否收到点击
        isAutoMode = true;

        // 禁用按钮并修改文本
        if (startButton != null)
        {
            startButton.interactable = false; // 禁用按钮交互
            startButton.GetComponentInChildren<TextMeshProUGUI>().text = "battle now..."; // 修改按钮文本
        }

        StartCoroutine(AutoAttack()); // 启动自动攻击协程
    }

    private void InitializeCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cardUIs[i].Initialize(cards[i]); // 初始化每张卡牌的UI
        }
    }



    public void ResetProgress()
    {
        _experience = 0; // 重置经验值
    }

    private IEnumerator AutoAttack()
    {
        //Debug.Log("[调试] 自动攻击协程启动"); // 检查协程何时启动
        while (isAutoMode) // 用标志控制循环
        {
            yield return new WaitForSeconds(0.5f); // 每 0.5 秒执行一次

            // 检查Boss数组有效性
            if (bosses == null || bosses.Length == 0)
            {
                Debug.LogWarning("No bosses available"); // 警告没有可用的Boss
                break; // 退出循环
            }

            // 过滤已死亡的Boss
            var aliveBosses = bosses.Where(b => b != null && !b.isDead).ToArray();
            if (aliveBosses.Length == 0)
            {
                Debug.Log("All bosses dead"); // 所有Boss已死亡
                break; // 退出循环
            }

            // 随机选择存活的Boss
            Boss1 selectedBoss = aliveBosses[Random.Range(0, aliveBosses.Length)];

            // 选择卡牌逻辑（示例随机选择）
            CardUI selectedCard = cardUIs[Random.Range(0, cardUIs.Length)];

            // 执行攻击
            selectedBoss.TakeDamage(selectedCard.card.damage);
            Debug.Log($"Auto attack: {selectedCard.card.cardName} -> {selectedBoss.bossName}"); // 输出攻击日志
        }

        // 攻击结束后恢复按钮状态
        isAutoMode = false;
        if (startButton != null)
        {
            startButton.interactable = true; // 恢复按钮交互
            startButton.GetComponentInChildren<TextMeshProUGUI>().text = "auto attack"; // 恢复按钮文本
        }

        Debug.Log("[调试] 自动攻击结束，按钮已恢复");
    }
}