﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerAsset : MonoBehaviour
{
    private static PlayerAsset _instance;
    public static PlayerAsset Instance
    {
        get
        {
            return _instance;
        }
    }
    public int Hp;
    public int Resource;
    public int Electric;
    public int FirstAid;
    public int Chip;
    public int ElectricMoveCost = 1;//移动电力消耗
    public int ResourceMoveCost = 1;//移动物资消耗
    public int HPMoveCost = 5;//移动物资消耗
    public int IncidentNeed = 0;
    public int Incident = 0;
    public int FirstAidRecover = 10;

    public void increaseHp(int x)
    {
        Hp += x;
        if (Hp > 100)
            Hp = 100;
    }

    public void useFirstAid()
    {
        Hp += FirstAidRecover;
        if (Hp > 100)
            Hp = 100;
    }

    public void increaseResource(int x)
    {
        Resource += x;
    }

    public void increaseElectric(int x)
    {
        Electric += x;
    }

    public void increaseFirstAid(int x)
    {
        FirstAid += x;
    }

    public void increaseChip(int x)
    {
        Chip += x;
    }

    public void increaseIncident(int x)
    {
        Incident += x;
    }

    public void decreaseHp(int x)
    {
        if ((Hp -= x) < 0) Hp = 0;
    }

    public void decreaseResource(int x)
    {
        if ((Resource -= x) < 0) Resource = 0;
    }
    
    public void decreaseFirstAid(int x)
    {
        FirstAid -= x;
    }

    public void decreaseChip(int x)
    {
        Chip -= x;
    }

    public int movecost()
    {
        int flag = 0;
        if (Resource < ResourceMoveCost)
        {
            if ((Hp -= HPMoveCost) < 0) Hp = 0;
            flag = 1;
        }
        else {
            if ((Resource -= ResourceMoveCost) < 0) Resource = 0;
        }
        if (Electric < ElectricMoveCost)
        {
            if (flag == 1)
            {
                flag = 3;
            }
            else
            {
                flag = 2;
            }
        }
        else
        {
            if ((Electric -= ElectricMoveCost) < 0) Electric = 0;
        }
        return flag;
    }


}
