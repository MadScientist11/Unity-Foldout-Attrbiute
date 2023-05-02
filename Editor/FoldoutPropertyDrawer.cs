using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace QuizAndPuzzle.Foldout
{
    [CustomPropertyDrawer(typeof(FoldoutAttribute))]
    public class FoldoutPropertyDrawer : PropertyDrawer
    {
        private UnityEngine.UIElements.Foldout _foldout;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement container = new VisualElement();
            FoldoutAttribute foldoutAttribute = (FoldoutAttribute)attribute;
            _foldout ??= new UnityEngine.UIElements.Foldout
            {
                text = foldoutAttribute.Name
            };
            
            Type propertyDrawer = EditorHelpers.GetPropertyDrawer(property.objectReferenceValue.GetType());
            if(propertyDrawer != null)
            {
                PropertyDrawer editor = (PropertyDrawer)Activator.CreateInstance(propertyDrawer);
                container.Add(editor.CreatePropertyGUI(property));
            }
            else
            {
                container.Add(new PropertyField(property));
            }

            _foldout.Add(container);
            return _foldout;
        }
    }
}