using UnityEngine;
using UnityEditor;
using System.Collections;

public class GroupToolWindow: EditorWindow
{
    public string BaseName = string.Empty;
    public bool StartFromZero = false;
    public ActionType Action = 0;
    public Vector3 AnchorPosition = new Vector3();
    public GridData GridSetting = new GridData();
    //public GridExact GridSettingExact = new GridExact(); 
    public GameObject[] Targets;

    public bool InitializationPassed = false;
    SerializedObject ThisSerializedObject;
    SerializedProperty TargetsProperty;
    SerializedProperty GridProperty;
    //SerializedProperty GridExactProperty;
    SerializedProperty SetPositionsProperty;

    [MenuItem ("Window/Tools/GroupTool")]
	static void Init () {
		GroupToolWindow window = (GroupToolWindow)EditorWindow.GetWindow (typeof (GroupToolWindow));
        window.name = "GroupTool";
		window.Show();
	}

    public void InitData(bool force = false)
    {
        if(InitializationPassed && !force)
            return;
        InitializationPassed = true;
        if(ThisSerializedObject == null)
            ThisSerializedObject = new SerializedObject(this as ScriptableObject);
        if(TargetsProperty == null)
            TargetsProperty = ThisSerializedObject.FindProperty("Targets");
        if(GridProperty == null)
            GridProperty = ThisSerializedObject.FindProperty("GridSetting");
        //if(GridExactProperty == null)
        //    GridExactProperty = ThisSerializedObject.FindProperty("GridSettingExact");
    }

	void OnGUI ()
    {
        InitData(true);
        ThisSerializedObject.Update();
        EditorGUILayout.LabelField("");
        EditorGUILayout.PropertyField(TargetsProperty, true);
        Action = (ActionType) EditorGUILayout.EnumPopup("ActionType", Action);
        if(Action == ActionType.SetGameObjectNames || Action == ActionType.SetTMProText)
        {
            BaseName = EditorGUILayout.TextField("BaseName", BaseName);
            StartFromZero = EditorGUILayout.Toggle("StartFromZero", StartFromZero);
        }
        if(Action == ActionType.SetGridPosition)// || SetPositions == GridType.exact)
            AnchorPosition = EditorGUILayout.Vector3Field("AnchorPosition", AnchorPosition);
        if(Action == ActionType.SetGridPosition)
            EditorGUILayout.PropertyField(GridProperty, true);
        //else if(SetPositions == GridType.exact)
        //    EditorGUILayout.PropertyField(GridExactProperty, true);

        if (GUILayout.Button("Apply"))
        {
            SetText();
        }
        
        ThisSerializedObject.ApplyModifiedProperties();
	}
    
    [ContextMenu ("SetTest")]
    public void SetText()
    {
        int indexDisplacement = StartFromZero ? 0 : 1;
        for (int i = 0; i < Targets.Length; i++)
        {
            if(Action == ActionType.SetGameObjectNames)
                Targets[i].name = BaseName + (i+indexDisplacement);
            else if(Action == ActionType.SetGridPosition)
                Targets[i].transform.localPosition = AnchorPosition + GetDisplacement(i, GridSetting);
            //else if(SetPositions == GridType.exact)
            //    Targets[i].transform.localPosition = AnchorPosition + GetExactPosition(i, GridSettingExact);
            else if(Action == ActionType.SetTMProText)
                SetTMProText(Targets[i], BaseName + (i+indexDisplacement));
        }
    }

    public Vector3 GetDisplacement(int i, GridData data)
    {
        Vector3 value = new Vector3();
        if(data.Orientation == GridOrientation.FallowRows)
        {
            value.x = Mathf.RoundToInt((i/data.Rows) * data.ColumsDisplacment);
            value.y = Mathf.RoundToInt((i%data.Rows) * data.RowsDisplacment);
        }
        else if(data.Orientation == GridOrientation.FallowColums)
        {
            value.x = Mathf.RoundToInt((i%data.Colums) * data.ColumsDisplacment);
            value.y = Mathf.RoundToInt((i/data.Colums) * data.RowsDisplacment);
        }
        
        return value; 
    }

    //public Vector3 GetExactPosition(int i, GridExact data)
    //{
    //    int xIndex = (int)(i/data.Rows.Length);
    //    int yIndex = (int)(i%data.Rows.Length);
    //    return new Vector3(data.Colums[xIndex],data.Rows[xIndex]); 
    //}

    public void SetTMProText(GameObject target, string text)
    {
        //TextMeshPro tmObject = target.GetComponent<TextMeshPro>();
        //if(tmObject == null)
        //    return;
        //tmObject.text = text;
    }

    [System.Serializable]
    public class GridData
    {
        public GridOrientation Orientation;
        public int Rows = 1;
        public int Colums = 1;
        public float RowsDisplacment = 1;
        public float ColumsDisplacment = 1; 
    }

    //[System.Serializable]
    //public class GridExact
    //{
    //    public float[] Rows;
    //    public float[] Colums;
    //}

    public enum ActionType {None, SetGameObjectNames, SetGridPosition, SetTMProText};

    public enum GridOrientation {FallowRows, FallowColums};
}