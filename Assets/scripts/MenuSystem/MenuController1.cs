/* 
功能:
控制详细信息面板的显示和隐藏。

挂载对象:
应该挂载在一个管理详细信息面板的对象上，例如 DetailManager。

重要变量:
detailPanel: 详细信息面板的游戏对象。
inputActions: 用于处理输入的控制对象。
_isProcessingInput: 防止输入重复处理的标志。
 */

 using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MenuController1 : MonoBehaviour
{
    public GameObject detailPanel;

    private GamePlayControls inputActions;

    //private bool _isProcessingInput;

    void Awake()
    {
        // 初始化输入系统
        inputActions = new GamePlayControls();

        // 绑定两个动作到对应方法
        inputActions.UI.ToggleDetail.performed += _ => ToggleDetail();
    }

    void Update()
    {
        // 使用新输入系统的 Keyboard 类
        // if (Keyboard.current.tabKey.wasPressedThisFrame || Gamepad.current.buttonSouth.wasPressedThisFrame)
        // {
        //     ToggleDetail();
        // }

        // if (Keyboard.current.tabKey.wasPressedThisFrame && !_isProcessingInput)
        // {
        //     _isProcessingInput = true;
        //     ToggleDetail();
        //     _isProcessingInput = false;
        // }

        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            ToggleDetail();
        }
    }

    //void OnEnable()
    //{
    //    inputActions.UI.Enable(); // 启用UI Action Map
    //}

    //void OnDisable()
    //{
    //    inputActions.UI.Disable(); // 禁用UI Action Map
    //}

    public void ToggleDetail()
    {
        detailPanel.SetActive(true);
        Debug.Log("detail panel状态: " + detailPanel.activeSelf);
    }
}

// using TMPro;
// using UnityEngine;
// using UnityEngine.InputSystem;
// using UnityEngine.EventSystems;

// public class MenuController1 : MonoBehaviour
// {
//     public GameObject detailPanel;

//     private GamePlayControls inputActions;

//     private bool _isProcessingInput;

//     void Awake()
//     {
//         // 初始化输入系统
//         inputActions = new GamePlayControls();

//         // 绑定两个动作到对应方法
//         inputActions.UI.ToggleDetail.performed += _ => ToggleDetail();
//     }

//     void Update()
//     {
//         // 检测键盘（M键）和手柄（X键，通常是JoystickButton2）
//         if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.JoystickButton2))
//         {
//             ToggleDetail();
//         }

//         if (Input.GetKeyDown(KeyCode.Tab) && !_isProcessingInput)
//         {
//             _isProcessingInput = true;
//             ToggleDetail();
//             _isProcessingInput = false;
//         }
//     }

//     void OnEnable()
//     {
//         inputActions.UI.Enable(); // 启用UI Action Map
//     }

//     void OnDisable()
//     {
//         inputActions.UI.Disable(); // 禁用UI Action Map
//     }

//     public void ToggleDetail()
//     {
//         detailPanel.SetActive(!detailPanel.activeSelf);
//     }
// }
