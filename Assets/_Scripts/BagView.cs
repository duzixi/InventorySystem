using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// 脚本功能：MVC模式 —— View视图，控制背包的显示方式
/// 添加对象：Bag 背包 (Canvas下的空对象)
/// 版权声明：Copyright (c) 2015 duzixi.com  All Rights Reserved
/// 创建时间：2015.05.08
/// 修改记录：2015.05.18 添加编号
/// 修改记录：2015.07.03 封装显示物品格子方法
/// 知识要点：
/// 1. MVC
/// 2. UGUI 
/// </summary>
public class BagView : MonoBehaviour {
    // 背包规格
    public static int row = 4;  // 行
    public static int col = 5;  // 列

    // 背包格子
    public GameObject grid;
    float width;  // 格子宽度
    float height; // 格子高度

    // 根据格子预设体获取宽和高
    void Awake() {
        width = grid.GetComponent<RectTransform>().rect.width + 10;
        height = grid.GetComponent<RectTransform>().rect.height + 10;
    }

	// 初始状态：平铺格子，创建背包
	void Start () {
        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                // 计算ID值(物品列表下标)
                int id = j + i * col;

                // 实例化格子预设，按宽高布局
                GameObject itemGrid = Instantiate(grid, transform.position + new Vector3(j * width, -i * height, 0), Quaternion.identity) as GameObject;
                // 将实例化的格子对象设置为背包的子对象
                itemGrid.transform.SetParent(transform);

				// 调用自定义方法：显示某个id的格子内容
				ShowItem(itemGrid.transform, id);

                // 给格子 PickUpDrop 组件编号，拾取放下时用
                itemGrid.GetComponent<PickUpDrop>().gridID = id;
            }
        }
	}

    // 重新刷新背包显示（物品位置发生变化时）
    public void ShowItems() {
        for (int i = 0; i < row * col; i++) {
            Transform itemGrid = transform.GetChild(i);
			ShowItem(itemGrid, i);
        }
    }

    // 显示物品格子
	private void ShowItem(Transform itemGrid, int id) {
        // 显示物品名称
        Text txtUGUI = itemGrid.GetComponentInChildren<Text>();
        txtUGUI.text = ItemModel.items[id].name;

		// 获取物品Icon的Image组件
		Image imageUGUI = itemGrid.GetChild(0).GetComponent<Image>();
		
		// 如果有物品，就显示图片
		if (ItemModel.items[id].img != null) {
			imageUGUI.color = Color.white;
		} else { // 否则不显示
			imageUGUI.color = Color.clear;
		}
        imageUGUI.sprite = ItemModel.items[id].img;
	}
}
