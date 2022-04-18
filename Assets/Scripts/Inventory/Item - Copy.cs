using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
   public enum ItemType
   {
      Gun,
      Key,
      Ammo,
      Keycard_green,
      Keycard_blue,
      Keycard_red,
      Keycard_purple,
      Keycard_yellow,
      Keycard_orange,
   }

   public ItemType itemType;
   public int amount;

   public Sprite GetSprite()
   {
      switch (itemType)
      {
         default:
         case ItemType.Ammo: return ItemAssets.Instance.ammoSprite;
         case ItemType.Key: return ItemAssets.Instance.keySprite;
         case ItemType.Keycard_blue: return ItemAssets.Instance.keycardblueSprite;
         case ItemType.Keycard_green: return ItemAssets.Instance.keycardgreenSprite;
         case ItemType.Keycard_orange: return ItemAssets.Instance.keycardorangeSprite;
         case ItemType.Keycard_purple: return ItemAssets.Instance.keycardpurpleSprite;
         case ItemType.Keycard_red: return ItemAssets.Instance.keycardredSprite;
         case ItemType.Keycard_yellow: return ItemAssets.Instance.keycardyellowSprite;
      }
   }

}
