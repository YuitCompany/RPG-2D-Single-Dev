using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
/// <summary>
/// Class Draw for Sprite
/// </summary>

[CustomPropertyDrawer(typeof(Sprite))]
public class SpriteDrawer : PropertyDrawer
{
    private static GUIStyle s_temp_style = new GUIStyle();

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var iden = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect _sprite_rect;

        // Create Object Field For The Sprite
        _sprite_rect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        property.objectReferenceValue = EditorGUI.ObjectField(_sprite_rect, property.name, property.objectReferenceValue, typeof(Sprite), false);

        // Not A Repain Or The Property Is Null Will Exit
        if (Event.current.type != EventType.Repaint || property.objectReferenceValue == null) return;

        // Draw A Sprite
        Sprite _sprite = property.objectReferenceValue as Sprite;
        _sprite_rect.y += EditorGUIUtility.singleLineHeight + 4;
        _sprite_rect.width = 64;
        _sprite_rect.height = 64;
        s_temp_style.normal.background = _sprite.texture;
        s_temp_style.Draw(_sprite_rect, GUIContent.none, false, false, false, false);

        EditorGUI.indentLevel = iden;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }
}

#endif