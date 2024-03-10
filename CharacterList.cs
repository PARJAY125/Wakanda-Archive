using System;
using System.Collections.Generic;

[Serializable]
public class CharacterList {
    public static List<CharacterStats> characters = new() {
        new() { 
            charName = "Hoshino Aoba", 
            Maxhp = 1000, 
            currentHp = 1000, 
            damage = 200, 
            attackRange = 5, 
            isCanTakeCover = true, 
            attackSpeed = 1.2f 
        },

        new() { 
            charName = "Mutsuki Aine", 
            Maxhp = 800, 
            currentHp = 800, 
            damage = 250, 
            attackRange = 3, 
            isCanTakeCover = false, 
            attackSpeed = 1.5f 
        },

        new() { 
            charName = "Azusa Futaba", 
            Maxhp = 900, 
            currentHp = 900, 
            damage = 180, 
            attackRange = 4, 
            isCanTakeCover = true, 
            attackSpeed = 1.0f 
        },

        new() { 
            charName = "Yuuka Tsukumo", 
            Maxhp = 750, 
            currentHp = 750, 
            damage = 220, 
            attackRange = 2, 
            isCanTakeCover = true, 
            attackSpeed = 1.3f 
        },

        new() { 
            charName = "Kokona Harukaze", 
            Maxhp = 850, 
            currentHp = 850, 
            damage = 210, 
            attackRange = 4, 
            isCanTakeCover = false, 
            attackSpeed = 1.1f 
        },

        new() { 
            charName = "Serina Kestrel", 
            Maxhp = 950, 
            currentHp = 950, 
            damage = 190, 
            attackRange = 3, 
            isCanTakeCover = true, 
            attackSpeed = 0.9f 
        },

        new() { 
            charName = "Tsubaki Hiiro", 
            Maxhp = 800, 
            currentHp = 800, 
            damage = 230, 
            attackRange = 2, 
            isCanTakeCover = true, 
            attackSpeed = 1.4f 
        },

        new() { 
            charName = "Akari Yukine", 
            Maxhp = 700, 
            currentHp = 700, 
            damage = 240, 
            attackRange = 5, 
            isCanTakeCover = false, 
            attackSpeed = 1.6f 
        },

        new() { 
            charName = "Hina Nono", 
            Maxhp = 900, 
            currentHp = 900, 
            damage = 170, 
            attackRange = 4, 
            isCanTakeCover = true, 
            attackSpeed = 0.8f 
        },

        new() { 
            charName = "Chihiro Mifune", 
            Maxhp = 850, 
            currentHp = 850, 
            damage = 200, 
            attackRange = 3, 
            isCanTakeCover = true, 
            attackSpeed = 1.7f 
        }
    };
}