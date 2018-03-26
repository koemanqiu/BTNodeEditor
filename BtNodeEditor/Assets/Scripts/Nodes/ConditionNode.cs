using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using System.Reflection;
using System.Linq;
using BT;

namespace BtNodeEditor
{
    [Node(false, "BT/Condition Node", new Type[] { typeof(BtCanvas) })]
    public class ConditionNode : BtNodeBase
    {

        public override string Title
        {
            get
            {
                return "Condition Node";
            }
        }

        public override Vector2 DefaultSize
        {
            get
            {
                return new Vector2(100, 60);
            }
        }

        public override Type GetOjbectType
        {
            get
            {
                return typeof(ConditionNode);
            }
        }

        private const string Id = "BtConditionNode";
        public override string GetID
        {
            get
            {
                return Id;
            }
        }

        [ConnectionKnob("Input Top", Direction.In, "BtIn", NodeSide.Top, 50)]
        public ConnectionKnob fromPreviousIN;

        protected override void OnCreate()
        {
            backgroundColor = Color.white;
        }

        //int selidx = 0;
        public override void NodeGUI()
        {
            EditorGUILayout.LabelField("Condition");

            Type[] typs = typeof(BTDecorator).Assembly.GetTypes().Where(t =>
            t.BaseType != null && t.BaseType == typeof(BTDecorator)).ToArray();

            string[] typsstrs = new string[typs.Length];
            for( int i = 0; i < typsstrs.Length; ++i)
            {
                typsstrs[i] = typs[i].FullName;
            }

            m_SelectIdx = RTEditorGUI.Popup(m_SelectIdx, typsstrs);
        }

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
