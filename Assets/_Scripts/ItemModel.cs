using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 脚本功能：MVC模式——Model层，定义物品结构，保存物品数据
/// 添加对象：Bag 背包(Canvas下的空对象)
/// 版权声明：Copyright (c) 2015 duzixi.com  All Rights Reserved
/// 创建日期：2015.5.8
/// 知识要点：
/// 1. MVC
/// 2. 自定义类
/// 3. 类的嵌套
/// </summary>
public class ItemModel : MonoBehaviour {

    // 物品类的定义
    public class Item
    {
        public string name; // 物品名称
        public Sprite img;  // 物品图片

        // 构造器
        public Item(string name, Sprite img) {
            this.name = name;
            this.img = img;
        }
    }

    public static List<Item> items; // 保存物品对象的集合

    // 物品图片数组
    public int size = 16;
    Sprite[] sprites;

    void Awake() // 数据初始化
    {
        items = new List<Item>(); // 初始化List<Item>
        sprites = new Sprite[size];

        // 根据行列值初始化物品列表
        for (int i = 0; i < BagView.row; i++) {
            for (int j = 0; j < BagView.col; j++) {
                items.Add(new Item("", null));
            }
        }

        // 【注意】实际开发中以下部分应由数据库代替
		for (int i = 0; i < size; i++) {
            string name = i < 9 ? "0" + (i + 1) : "" + (i + 1);
            sprites[i] = Resources.Load(name, typeof(Sprite)) as Sprite;
			items[i] = new Item(" ", sprites[i]);
		}	
    }
}
