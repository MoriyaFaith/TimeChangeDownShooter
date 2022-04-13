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
   }

   public ItemType itemType;
   public int amount;

}
