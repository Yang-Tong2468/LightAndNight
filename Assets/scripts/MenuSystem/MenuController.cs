/* 
功能:
控制游戏菜单的显示和隐藏。
更新玩家的经验值和等级显示。

挂载对象:
应该挂载在一个管理菜单的对象上，例如 MenuManager。

重要变量:
menuPanel: 菜单面板的游戏对象。
expText, expText1: 显示玩家经验值的文本对象。
nameText, nameText1: 显示玩家名称的文本对象。
levelText, levelText1: 显示玩家等级的文本对象。
inputActions: 用于处理输入的控制对象。
 */

using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;

    private GamePlayControls inputActions;

    public TextMeshProUGUI expText; // 经验值文本

    public TextMeshProUGUI expText1; // 经验值文本

    public TextMeshProUGUI nameText;

    public TextMeshProUGUI nameText1;

    public TextMeshProUGUI levelText;  // 玩家等级显示

    public TextMeshProUGUI levelText1; // 玩家2等级显示

    //private LevelManager levelManager;  // 引用LevelManager实例

    void Awake()
    {
        // 初始化输入系统
        inputActions = new GamePlayControls();

        // 绑定两个动作到对应方法
        inputActions.UI.ToggleMenu.performed += _ => ToggleMenu();

        // 初始化LevelManager实例
        // levelManager = Object.FindFirstObjectByType<LevelManager>();
        // if (levelManager == null)
        // {
        //     Debug.LogError("LevelManager not found in the scene!");
        // }
    }

    void Update()
    {
        // 检查 levelManager 是否为 null
        // if (levelManager == null)
        // {
        //     Debug.LogError("LevelManager is not assigned!");
        //     return; // 如果为 null，提前退出
        // }

        // 检测键盘（Esc）和手柄（Start键，通常是JoystickButton7）
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            ToggleMenu();
        }

        // // 更新经验值和等级
        // int player1Level = levelManager.player1Level;
        // int player2Level = levelManager.player2Level;

        // 更新经验值显示（仅在菜单打开时更新）
        // if (menuPanel.activeSelf)
        // {
        //     expText.text = "Exp: " + MenuManager.instance.playerExperience[0]; // 使用 instance
        //     expText1.text = "Exp: " + MenuManager.instance.playerExperience[1]; // 使用 instance

        //     nameText.text = "Character Name: " + MenuManager.instance.playerName[0]; // 使用 instance
        //     nameText1.text = "Character Name: " + MenuManager.instance.playerName[1]; // 使用 instance

        //     levelText.text = "Level: " + LevelManager.instance.player1Level; // 使用计算出的等级
        //     levelText1.text = "Level: " + LevelManager.instance.player2Level; // 使用计算出的等级

        //     // Debug.Log($"已更新level值: {levelText.text}");
        //     // Debug.Log($"已更新level值: {levelText1.text}");
        //     //数值错误

        //     // Debug.Log($"player1的等级(menu controller):{LevelManager.instance.player1Level}");
        //     // Debug.Log($"player2的等级(menu controller):{LevelManager.instance.player2Level}");
        //     //数值错误
        // }
    }

    //void OnEnable()
    //{
    //    inputActions.UI.Enable(); // 启用UI Action Map
    //}

    //void OnDisable()
    //{
    //    inputActions.UI.Disable(); // 禁用UI Action Map
    //}

    public void ToggleMenu()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        //Debug.Log("menu panel状态: " + menuPanel.activeSelf);
    }
}