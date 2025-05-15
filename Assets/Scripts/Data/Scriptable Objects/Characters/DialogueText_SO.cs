using UnityEngine;

[CreateAssetMenu(fileName = "DialogueText_SO", menuName = "Scriptable Objects/Characters/Dialogue Text")]
public class DialogueText_SO : ScriptableObject
{
    public ScriptableObject character;

    public DialogueSection[] sections;
}


[System.Serializable]
public struct DialogueSection
{
    [TextArea]
    public string[] dialogue;
    public bool endAfterDialogue;
    public BranchPoint branchPoint;
}

[System.Serializable]
public struct BranchPoint
{
    [TextArea]
    public string question;
    public Answer[] answers;
}

[System.Serializable]
public struct Answer
{
    public string answerLabel;
    public int nextElement;
}