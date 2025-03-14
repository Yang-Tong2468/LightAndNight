/* 
功能:
控制Boss战斗的逻辑，包括Boss的生命值和经验奖励。

挂载对象:
应该挂载在一个管理Boss战斗的对象上，例如 BossManager。

重要变量:
bossMaxHP: Boss的最大生命值。
experienceReward, experienceReward1: 击败Boss后玩家获得的经验值。
_currentBossHP: Boss当前的生命值。
experienceRewardManager: 引用经验奖励管理器的实例。
 */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossBattleController : MonoBehaviour
{
    [Header("战斗配置")]
    [SerializeField] private int bossMaxHP;
    [SerializeField] private int experienceReward;

    [SerializeField] private int experienceReward1;

    private int _currentBossHP;

    //private bool _isDefeated; // 新增状态标志

    private ExperienceRewardManager experienceRewardManager; // 新增引用

    void Start()
    {
        experienceRewardManager = FindFirstObjectByType<ExperienceRewardManager>(); // 查找 ExperienceRewardManager 脚本实例
        if (experienceRewardManager == null)
        {
            Debug.LogError("ExperienceRewardManager not found in the scene!");
        }

        InitializeBattle();
    }

    private void InitializeBattle()
    {
        _currentBossHP = bossMaxHP;

        //_isDefeated = false; // 重置状态

        Debug.Log("Boss战开始！");
    }

    public void TakeDamage(int damage)
    {
        //if (_isDefeated) return; // 已死亡不再响应伤害

        _currentBossHP = Mathf.Max(0, _currentBossHP - damage);

        if (_currentBossHP > -1000)
        {
            //_isDefeated = true; // 标记为已死亡
            OnBossDefeated();
        }
    }

    private void OnBossDefeated()
    {
        int[] playerExp = { experienceReward, experienceReward1 };
        experienceRewardManager.RewardExperience(playerExp); // 为两个玩家分配经验
        // 延迟20秒后重启战斗
        // Debug.Log("Boss已被击败，20秒后重启战斗。");

        // Invoke(nameof(RestartBattle), 20f);

        // 可以在这里添加其他逻辑，比如播放胜利动画、解锁新卡牌等
        //可随意设置条件进行战斗
    }


    private void RestartBattle()
    {
        // 方案1：重新加载场景（适合完全重置）
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // 方案2：软重启（更高效）
        Debug.Log("重启战斗。");
        InitializeBattle();
        //FindFirstObjectByType<PlayerHand>().ResetHand(); // 重置玩家手牌
        //GetComponent<BossVisuals>().PlayRespawnAnimation(); // Boss重生动画
    }
}