using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(CharacterModel))]
public class CharacterCustomEditor : Editor
{
    SerializedProperty moveSettsProperty;
    bool moveSettsFoldout;
    Editor moveSettsEditor;

    SerializedProperty jumpSettsProperty;
    bool jumpSettsFoldout;
    Editor jumpSettsEditor;

    SerializedProperty rollSettsProperty;
    bool rollSettsFoldout;
    Editor rollSettsEditor;

    SerializedProperty itemsSettsProperty;
    bool itemsSettsFoldout;
    Editor itemsSettsEditor;

    SerializedProperty deathSettsProperty;
    bool deathSettsFoldout;
    Editor deathSettsEditor;

    SerializedProperty invulnerabilitySettsProperty;
    bool invulnerabilitySettsFoldout;
    Editor invulnerabilitySettsEditor;

    SerializedProperty animationSettsProperty;
    bool animationSettsFoldout;
    Editor animationSettsEditor;


    CharacterModel character;

    private void OnEnable()
    {
        character = target as CharacterModel;
        moveSettsProperty = serializedObject.FindProperty("moveSettings");
        jumpSettsProperty = serializedObject.FindProperty("jumpSettings");
        rollSettsProperty = serializedObject.FindProperty("rollSettings");
        itemsSettsProperty = serializedObject.FindProperty("itemsSettings");
        deathSettsProperty = serializedObject.FindProperty("deathSettings");
        invulnerabilitySettsProperty = serializedObject.FindProperty("invulnerabilitySettings");
        animationSettsProperty = serializedObject.FindProperty("animationSettings");

    }

    public override void OnInspectorGUI()
    {

        
        EditorGUILayout.PropertyField(moveSettsProperty);
        DrawSettingsEditor(character.moveSettings, ref moveSettsFoldout, moveSettsEditor);

        EditorGUILayout.PropertyField(jumpSettsProperty);
        DrawSettingsEditor(character.jumpSettings, ref jumpSettsFoldout, jumpSettsEditor);

        EditorGUILayout.PropertyField(rollSettsProperty);
        DrawSettingsEditor(character.rollSettings, ref rollSettsFoldout, rollSettsEditor);

        EditorGUILayout.PropertyField(itemsSettsProperty);
        DrawSettingsEditor(character.itemsSettings, ref itemsSettsFoldout, itemsSettsEditor);

        EditorGUILayout.PropertyField(deathSettsProperty);
        DrawSettingsEditor(character.deathSettings, ref deathSettsFoldout, deathSettsEditor);

        EditorGUILayout.PropertyField(invulnerabilitySettsProperty);
        DrawSettingsEditor(character.invulnerabilitySettings, ref invulnerabilitySettsFoldout, invulnerabilitySettsEditor);

        EditorGUILayout.PropertyField(animationSettsProperty);
        DrawSettingsEditor(character.animationSettings,ref animationSettsFoldout, animationSettsEditor);

        serializedObject.ApplyModifiedProperties();
        
    }

    private void DrawSettingsEditor(Object target,ref bool foldout,Editor editor)
    {
        if (target != null)
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, target);
            if (foldout)
            {
                CreateCachedEditor(target, null, ref editor);
                using (var check = new EditorGUI.ChangeCheckScope())
                {
                    editor.OnInspectorGUI();
                }
            }

        }
    }
}
