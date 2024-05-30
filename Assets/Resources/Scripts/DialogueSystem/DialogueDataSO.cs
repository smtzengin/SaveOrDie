
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Create New Dialogue")]
public class DialogueDataSO : ScriptableObject
{
    public Sprite CharacterImage;
    public string Title;
    public string Content;
    public QuestDataSO QuestData;
}
