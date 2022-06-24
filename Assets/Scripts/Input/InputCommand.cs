using UnityEditor;
using UnityEngine;

public enum CommandType
{
    Mouse, Keyboard
}

[CreateAssetMenu(fileName = "InputCommand", menuName = "ScriptableObjects/InputCommand", order = 1)]
public class InputCommand : ScriptableObject
{
    public CommandType type;

    public int mouseButton;

    public KeyCode key;
}

[CanEditMultipleObjects]
[CustomEditor(typeof(InputCommand))]
public class InputCommandEditor : Editor
{
    public override void OnInspectorGUI()
    {
        InputCommand myTarget = (InputCommand)target;

        myTarget.type = (CommandType)EditorGUILayout.EnumPopup("Command Type", myTarget.type);

        if (myTarget.type == CommandType.Mouse)
        {
            myTarget.mouseButton = EditorGUILayout.IntField("Mouse Button", myTarget.mouseButton);
        }

        if (myTarget.type == CommandType.Keyboard)
        {
            myTarget.key = (KeyCode)EditorGUILayout.EnumPopup("Key", myTarget.key);
        }
    }
}