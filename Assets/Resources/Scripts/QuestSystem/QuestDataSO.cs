using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Create New Quest")]
public class QuestDataSO : ScriptableObject
{
    public string title;
    public Sprite targetObject;
    public string targetTag;
    public int currentCount;
    public int totalCount;

}
