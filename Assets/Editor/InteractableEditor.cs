using UnityEditor;

[CustomEditor(typeof(Interactable),true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable intreractable = (Interactable)target;
        if(target.GetType() == typeof(EventOnyInteractable))
        {
            intreractable.promptMessage = EditorGUILayout.TextField("Prompt Message", intreractable.promptMessage);
            EditorGUILayout.HelpBox("EventOnly can Only use unityEvents", MessageType.Info);
            if(intreractable.GetComponent<InteractionEvent>() == null)
            {
                intreractable.gameObject.AddComponent<InteractionEvent>();
            }
        }
        else
        {
            base.OnInspectorGUI();
            if (intreractable.useEvents)
            {
                if (intreractable.GetComponent<InteractionEvent>() == null)
                {
                    intreractable.gameObject.AddComponent<InteractionEvent>();
                }
            }
            else
            {
                if (intreractable.GetComponent<InteractionEvent>() != null)
                {
                    DestroyImmediate(intreractable.GetComponent<InteractionEvent>());
                }
            }
        }
    }
}
