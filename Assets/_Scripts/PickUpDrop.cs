using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
/// <summary>
/// 脚本功能：MVC模式 —— Control控制，背包内物品摆放
/// 添加对象：Item 物品格子预设体 
/// 版权声明：Copyright (c) 2015 duzixi.com  All Rights Reserved
/// 创建日期：2015.05.18 duzixi.com
/// 修改记录：2015.07.03 添加射线忽略
/// 知识要点：
/// 1. UGUI、MVC设计模式
/// </summary>
public class PickUpDrop : MonoBehaviour, IDropHandler {
    public int gridID;

    public static ItemModel.Item pickedItem; // 当前拾取的物品
	
	void Start () {
		// 初始化当前拾取物品为空
        pickedItem = new ItemModel.Item("", null); 
	}

    // 背包核心逻辑：交换
    public static void SwapItem(int gridID)
    {
        // 交换背包中的物品和拾取物品
        ItemModel.Item temp = pickedItem;
        pickedItem = ItemModel.items[gridID];
        ItemModel.items[gridID] = temp;

        // 刷新背包显示
        GameObject.Find("Bag").GetComponent<BagView>().ShowItems();
    }

	// 当物品按钮被点下时（点击触发模式）
    public void Drop() {
		SwapItem(gridID);
    }

    // 当物品放在格子中时（拖拽触发模式）
	public void OnDrop (PointerEventData eventData) {
		Info.debugStr = "OnDrop: " +  gridID;
		if (gridID != DragEvent.lastID) {
			SwapItem(gridID);
		}
	}

}