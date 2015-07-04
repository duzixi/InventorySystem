using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
/// <summary>
/// 脚本功能：MVC模式 —— Control控制，操作逻辑，拖拽事件处理
/// 添加对象：Bag 背包 (Canvas下的空对象)
/// 版权声明：Copyright (c) 2015 duzixi.com  All Rights Reserved
/// 创建时间：2015.07.03
/// 知识要点：
/// 1. UnityEngine.EventSystem
/// 2. IBeginDragHandlder, IDragHandler, IEndDragHander
/// </summary>
public class DragEvent : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {

	int gridID = 0;  // 格子编号

	string debugStr = "";

	void Start() {
		gridID = GetComponentInParent<PickUpDrop>().gridID; // 获取格子编号
	}

    // 开始拖拽
	public void OnBeginDrag (PointerEventData eventData) {
		Info.debugStr = "OnBeginDrag:" + gridID;
        // 调用交换方法
		PickUpDrop.SwapItem(gridID);
	}

    // 拖拽中
	public void OnDrag (PointerEventData eventData) {
		// 【注意】即使没有任何代码处理也要实现该接口，否则拖拽不成功
		// Info.debugStr = "OnDrag:" + gridID;
	}
    
    // 结束拖拽
	public void OnEndDrag (PointerEventData eventData) {
		Info.debugStr = "OnEndDrag:" + gridID;
        // 调用交换方法
		PickUpDrop.SwapItem(gridID);
	}

}
