using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

using NodeEditorFramework;
using System.Reflection;
using NodeEditorFramework.Utilities;
using System.Linq;


namespace BtNodeEditor
{
    [Node(false, "BT/Decorator Node", new Type[] { typeof(BtCanvas) })]
    public class DecoratorNode : BtNodeBase
    {

        public override string Title
        {
            get
            {
                return "Decorator Node";
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
                return typeof(DecoratorNode);
            }
        }

        private const string Id = "BtDecoratorNode";
        public override string GetID
        {
            get
            {
                return Id;
            }
        }

        [ConnectionKnob("Input Top", Direction.In, "BtIn", NodeSide.Top, 50)]
        public ConnectionKnob fromPreviousIn;

        [ConnectionKnob("Output Bottom", Direction.Out, "BtOut", NodeSide.Bottom, 50)]
        public ConnectionKnob toNextOUT;

        protected override void OnCreate()
        {
            backgroundColor = Color.yellow;
        }

        //public int slidx = 0;
        public override void NodeGUI()
        {
            EditorGUILayout.LabelField("Decorator");

            Type[] typs = typeof(BT.BTDecorator).Assembly.GetTypes().Where(t =>
            t.BaseType != null && t.BaseType == typeof(BT.BTDecorator)
            ).ToArray();

            string[] typsstrs = new string[typs.Length];
            for ( int i = 0; i < typsstrs.Length; ++i)
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
