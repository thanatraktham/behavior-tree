using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class BehaviorTreeEditor : EditorWindow
{
    BehaviorTreeView treeView;
    InspectorView InspectorView;

    [MenuItem("BehaviorTreeEditor/Editor ...")]

    public static void OpenWindow()
    {
        BehaviorTreeEditor wnd = GetWindow<BehaviorTreeEditor>();
        wnd.titleContent = new GUIContent("BehaviorTreeEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/BehaviorTreeEditor.uxml");
        visualTree.CloneTree(root);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/BehaviorTreeEditor.uss");
        root.styleSheets.Add(styleSheet);

        treeView = root.Q<BehaviorTreeView>();
        InspectorView = root.Q<InspectorView>();
    }

    private void OnSelectionChange() 
    {
        BehaviorTree tree = Selection.activeObject as BehaviorTree;
        if(tree)
        {
            treeView.PopulateView(tree);
        }
    }
}