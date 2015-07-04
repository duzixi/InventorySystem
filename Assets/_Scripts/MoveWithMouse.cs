using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// 脚本功能：让拾取的背包物品随鼠标移动
/// 添加对象：PickedItem 拾取的物品
/// 版权声明：Copyright (c) 2015 duzixi.com  All Rights Reserved
/// 创建日期：2015.05.18
/// 修改记录：2015.07.03 添加射线忽略
/// 知识要点：
/// 1. UGUI RectTransform、锚点、中心点
/// 2. 忽略射线接口 ICanvasRaycastFilter
/// </summary>

public class MoveWithMouse : MonoBehaviour, ICanvasRaycastFilter {
    RectTransform rect; // 获取UGUI定位组件

	Image icon;  // 显示当前拾取物品的图标

    void Awake() {
        rect = GetComponent<RectTransform>();
        // 【注意】图标对象是第0个子对象
		icon = transform.GetChild(0).GetComponent<Image>(); 
    }

	void Update () {
        // 用鼠标位置给图标图片定位
        rect.anchoredPosition3D = Input.mousePosition;
        // 根据是否有图片确定透明度
		if (PickUpDrop.pickedItem != null) { 
			if (PickUpDrop.pickedItem.img != null) {
				icon.color = Color.white;
				icon.sprite = PickUpDrop.pickedItem.img;
			} else {
				icon.color = Color.clear;
			}
		}
	}

    // 忽略鼠标图标上的射线
	public bool IsRaycastLocationValid (Vector2 sp, Camera eventCamera) {
		return false;
	}
}
