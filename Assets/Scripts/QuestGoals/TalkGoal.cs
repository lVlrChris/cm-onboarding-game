﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalkGoal : IQuestGoal {
    [SerializeField] public float hack;
    public bool isCompleted() {

        return false;
    }
}
