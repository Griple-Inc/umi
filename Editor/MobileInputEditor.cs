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
            root.style.marginTop = 8;

            // Return Key Type Section
            var returnKeySection = new VisualElement();
            returnKeySection.style.marginBottom = 12;

            var returnKeyLabel = new Label("Return Button Type");
            returnKeyLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
            returnKeyLabel.style.marginBottom = 4;
            returnKeySection.Add(returnKeyLabel);

            var returnKeyField = new EnumField("Return Key", ((MobileInputField)target).ReturnKey);
            returnKeyField.RegisterValueChangedCallback(evt => {
                Undo.RecordObject(target, "Change Return Key Type");
                ((MobileInputField)target).ReturnKey = (MobileInputField.ReturnKeyType)evt.newValue;
                EditorUtility.SetDirty(target);
            });
            returnKeySection.Add(returnKeyField);
            root.Add(returnKeySection);

            // Options Section
            var optionsSection = new VisualElement();
            optionsSection.style.marginBottom = 12;

            var optionsLabel = new Label("Options");
            optionsLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
            optionsLabel.style.marginBottom = 4;
            optionsSection.Add(optionsLabel);

            var bgColorField = new ColorField("Background Color") {
                value = ((MobileInputField)target).BackgroundColor
            };
            bgColorField.RegisterValueChangedCallback(evt => {
                Undo.RecordObject(target, "Change Background Color");
                ((MobileInputField)target).BackgroundColor = evt.newValue;
                EditorUtility.SetDirty(target);
            });
            optionsSection.Add(bgColorField);

            var customFontField = new TextField("Custom Font Name") {
                value = ((MobileInputField)target).CustomFont
            };
            customFontField.RegisterValueChangedCallback(evt => {
                Undo.RecordObject(target, "Change Custom Font");
                ((MobileInputField)target).CustomFont = evt.newValue;
                EditorUtility.SetDirty(target);
            });
            optionsSection.Add(customFontField);

            var keyboardLangField = new TextField("Keyboard Language") {
                value = ((MobileInputField)target).KeyboardLanguage
            };
            keyboardLangField.RegisterValueChangedCallback(evt => {
                Undo.RecordObject(target, "Change Keyboard Language");
                ((MobileInputField)target).KeyboardLanguage = evt.newValue;
                EditorUtility.SetDirty(target);
            });
            optionsSection.Add(keyboardLangField);

            var manualHideToggle = new Toggle("Manual Hide Control") {
                value = ((MobileInputField)target).IsManualHideControl
            };
            manualHideToggle.RegisterValueChangedCallback(evt => {
                Undo.RecordObject(target, "Change Manual Hide Control");
                ((MobileInputField)target).IsManualHideControl = evt.newValue;
                EditorUtility.SetDirty(target);
            });
            optionsSection.Add(manualHideToggle);

            root.Add(optionsSection);

            // Platform Options Section
            var platformSection = new VisualElement();
            platformSection.style.marginBottom = 12;

            var platformLabel = new Label("Platform Options");
            platformLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
            platformLabel.style.marginBottom = 4;
            platformSection.Add(platformLabel);

            var doneButtonToggle = new Toggle("Show \"Done\" Button (iOS)") {
                value = ((MobileInputField)target).IsWithDoneButton
            };
            doneButtonToggle.RegisterValueChangedCallback(evt => {
                Undo.RecordObject(target, "Change Done Button");
                ((MobileInputField)target).IsWithDoneButton = evt.newValue;
                EditorUtility.SetDirty(target);
            });
            platformSection.Add(doneButtonToggle);

            var clearButtonToggle = new Toggle("Show \"Clear\" Button") {
                value = ((MobileInputField)target).IsWithClearButton
            };
            clearButtonToggle.RegisterValueChangedCallback(evt => {
                Undo.RecordObject(target, "Change Clear Button");
                ((MobileInputField)target).IsWithClearButton = evt.newValue;
                EditorUtility.SetDirty(target);
            });
            platformSection.Add(clearButtonToggle);

            var hidePlaceholderToggle = new Toggle("Hide Placeholder On Focus") {
                value = ((MobileInputField)target).HidePlaceholderOnFocus,
                tooltip = "When enabled (default), placeholder hides when input is focused. When disabled, placeholder stays visible until user types (Unity-like behavior)."
            };
            hidePlaceholderToggle.RegisterValueChangedCallback(evt => {
                Undo.RecordObject(target, "Change Hide Placeholder On Focus");
                ((MobileInputField)target).HidePlaceholderOnFocus = evt.newValue;
                EditorUtility.SetDirty(target);
            });
            platformSection.Add(hidePlaceholderToggle);

            root.Add(platformSection);

            // Events Section
            var eventsSection = new VisualElement();
            eventsSection.style.marginBottom = 8;

            var eventsLabel = new Label("Events");
            eventsLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
            eventsLabel.style.marginBottom = 4;
            eventsSection.Add(eventsLabel);

            var returnPressedProperty = serializedObject.FindProperty("OnReturnPressedEvent");
            var returnPressedField = new PropertyField(returnPressedProperty);
            returnPressedField.Bind(serializedObject);
            eventsSection.Add(returnPressedField);

            root.Add(eventsSection);

            return root;
        }
    }
}
