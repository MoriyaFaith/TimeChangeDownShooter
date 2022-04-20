using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
  private List<Item> itemList;

  public Inventory()
  {
    itemList = new List<Item>();
    
    AddItem(new Item { itemType = Item.ItemType.Ammo, amount = 1});
    AddItem(new Item { itemType = Item.ItemType.Key, amount = 1});
    AddItem(new Item { itemType = Item.ItemType.Keycard_blue, amount = 1});
    AddItem(new Item { itemType = Item.ItemType.Keycard_green, amount = 1});
    AddItem(new Item { itemType = Item.ItemType.Keycard_orange, amount = 1});
    AddItem(new Item { itemType = Item.ItemType.Keycard_purple, amount = 1});
    AddItem(new Item { itemType = Item.ItemType.Keycard_red, amount = 1});
    AddItem(new Item { itemType = Item.ItemType.Keycard_yellow, amount = 1});
  }

  public void AddItem(Item item)
  {
    itemList.Add(item);
  }

  public List<Item> GetItemList()
  {
    return itemList;
  }
}
