using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace UMI {

    /// <summary>
    /// Custom editor for MobileInput using UI Toolkit
    /// </summary>
    [CustomEditor(typeof(MobileInputField))]
    public class MobileInputEditor : Editor {

        public override VisualElement CreateInspectorGUI() {
            var root = new VisualElement();

            // Return Key Type Section
            CreateSectionHeader(root, "Return Button Type");
            root.Add(CreatePropertyField("ReturnKey", "Return Key"));

            // Options Section
            CreateSectionHeader(root, "Options");
            root.Add(CreatePropertyField("BackgroundColor", "Background Color"));
            root.Add(CreatePropertyField("CustomFont", "Custom Font Name"));
            root.Add(CreatePropertyField("KeyboardLanguage", "Keyboard Language"));
            root.Add(CreatePropertyField("IsManualHideControl", "Manual Hide Control"));

            // Platform Options Section
            CreateSectionHeader(root, "Platform Options");
            root.Add(CreatePropertyField("IsWithDoneButton", "Show \"Done\" Button (iOS)"));
            root.Add(CreatePropertyField("IsWithClearButton", "Show \"Clear\" Button"));

            var hidePlaceholderField = CreatePropertyField("HidePlaceholderOnFocus", "Hide Placeholder On Focus");
            hidePlaceholderField.tooltip = "When enabled (default), placeholder hides when input is focused. When disabled, placeholder stays visible until user types (Unity-like behavior).";
            root.Add(hidePlaceholderField);

            // Events Section
            CreateSectionHeader(root, "Events");
            root.Add(CreatePropertyField("OnReturnPressedEvent"));

            return root;
        }

        VisualElement CreateSectionHeader(VisualElement parent, string title) {
            var header = new Label(title);
            header.style.unityFontStyleAndWeight = FontStyle.Bold;
            header.style.marginTop = 10;
            header.style.marginBottom = 2;
            parent.Add(header);
            return header;
        }

        PropertyField CreatePropertyField(string propertyName, string label = null) {
            var property = serializedObject.FindProperty(propertyName);
            var field = label != null ? new PropertyField(property, label) : new PropertyField(property);
            field.Bind(serializedObject);
            return field;
        }
    }
}
