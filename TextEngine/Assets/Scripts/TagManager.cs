using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TagManager : MonoBehaviour
{
    public static TagManager instance;

    public enum Tag
    {
        DEFAULT,
        GOTORB
    }

    public IDictionary<Tag, bool> TagDict = new Dictionary<Tag, bool>();

    void Awake()
    {
        instance = this;
        foreach (var tag in Enum.GetValues(typeof(Tag)))
        {          
            TagDict.Add((Tag)tag, false);
        }
    }
    
    public void SetTag(Tag tagToSet)
    {
        TagDict[tagToSet] = true;
    }
}

//this is a helper class that other classes can use in lists to compare to TagDict
[System.Serializable]
public class Condition
{
    public TagManager.Tag tag;
    public bool isSet;
}


