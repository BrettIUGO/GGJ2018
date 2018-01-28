using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public static float maxHealth = 100;
    public static float health = 100;

    public static float maxMana = 100;
    public static float mana = 100;

    public static float manaRegenRate = 20;

    public static int gold = 100;

    public static int metal = 0;

    public static string[] elements = {"metal", "gold"};
    
    private static Dictionary<string, int> _collectableCount;
    private static Dictionary<string, int> collectableCount {
        get {
            if (_collectableCount != null) {
                return _collectableCount;
            } 

            Dictionary<string, int> ret = new  Dictionary<string, int>();
            foreach (var element in elements)
            {
                ret.Add(element, 0);
            }

            print("collectableCount" + ret.ToString());
            _collectableCount = ret;
            return ret;
        }
    }

    public static void increaseCollectable(string type, int increase) {
        if(string.IsNullOrEmpty(type)) {
            print("increaseCollectable type is empty");
        } else { 
            print(collectableCount[type]);
            collectableCount[type] += increase;
            print(collectableCount[type]);
        }
    }

    public static float getCollectableCount(string type) {
        return collectableCount[type];
    }

}
