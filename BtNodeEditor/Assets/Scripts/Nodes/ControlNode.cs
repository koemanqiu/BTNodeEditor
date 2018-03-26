using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodeEditorFramework;
using System;
using System.Linq;
using System.Reflection;
using NodeEditorFramework.Utilities;

namespace BtNodeEditor
{
    [Node(false, "BT/Control Node", new Type[] { typeof(BtCanvas) })]
    public class ControlNode : BtNodeBase
    {
        public override string Title
        {
            get
            {
                return "Control Node";
            }
        }

        public override Type GetOjbectType
        {
            get
            {
                return typeof(ControlNode);
            }
        }

        //public override Vector2 MinSize
        //{
        //    get
        //    {
        //        return new Vector2(50, 50);
        //    }
        //}

        public override Vector2 DefaultSize
        {
            get
            {
                return new Vector2(100, 60);
            }
        }

        private const string Id = "BtControlNode";
        public override string GetID
        {
            get
            {
                return Id;
            }
        }

        [ConnectionKnob("Input Top", Direction.In, "BtIn", NodeSide.Top, 50)]
        public ConnectionKnob fromPreviousIN;
        //[ConnectionKnob("Output Top", Direction.Out, "BtBack", NodeSide.Top,50)]
        //public ConnectionKnob toPreviousOUT;

        [ConnectionKnob("Output Bottom", Direction.Out, "BtOut", NodeSide.Bottom, 50)]
        public ConnectionKnob toNextOUT;
        //[ConnectionKnob("Input Bottom", Direction.In, "BtBack", NodeSide.Bottom, 50)]
        //public ConnectionKnob fromNextIN;

        //private Vector2 scroll;

        protected override void OnCreate()
        {
            //do sth.
            backgroundColor = Color.red;
        }

        //int selectedidx = 0;
        public override void NodeGUI()
        {

            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Control");

            Assembly ta = typeof(BT.BTComposite).Assembly;

            var ts =
            ta.GetTypes().Where(t =>
            t.BaseType != null && t.BaseType == typeof(BT.BTComposite)
            );

            Type[] tst = ts.ToArray();
            string[] tsname = new string[tst.Length];
            for (int i = 0; i < tst.Length; ++i)
            {
                tsname[i] = tst[i].FullName;
            }

            m_SelectIdx = RTEditorGUI.Popup(m_SelectIdx, tsname);

            for ( int i = 0; i < tst[i].GetFields().Count(); ++i)
            {
                if ( tst[i].GetFields()[i].GetType() == typeof(int))
                {
            //        EditorGUILayout.IntField(tst[i].GetFields()[i].Name);
                }
            }
        }

        //protected override void DrawNode()
        //{
        //    Rect nodeRect = rect;
        //    nodeRect.position += NodeEditor.curEditorState.zoomPanAdjust + NodeEditor.curEditorState.panOffset;
        //    GUI.Box(nodeRect, GUIContent.none, GUI.skin.box);
        //}

        public override string GetNodeType
        {
            get
            {
                //return "BtNodeEditor.ConditionNode";
                //just for test;
                return GetType().FullName;
            }
        }
    }
}
