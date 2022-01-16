﻿
    using System.Collections.Generic;
    using UnityEngine;

    public static class ListExtenstion
    {
        public static T RandomItem<T>(this List<T> list)
        {
            var index = Random.Range(0, list.Count);
            return list[index];
        }
    }
