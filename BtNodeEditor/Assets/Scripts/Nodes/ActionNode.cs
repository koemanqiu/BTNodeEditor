using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodeEditorFramework;
using System;
using BT;
using System.Reflection;
using System.Linq;
using NodeEditorFramework.Utilities;

namespace BtNodeEditor
{
    [Node(false, "BT/Action Node", new Type[] { typeof(BtCanvas) })]
    public class ActionNode : BtNodeBase
    {

        public override string Title
        {
            get
            {
                return "Action Node";
            }
        }

        public override Type GetOjbectType
        {
            get
            {
                return typeof(ActionNode);
            }
        }

        public override Vector2 DefaultSize
        {
            get
            {
                return new Vector2(100, 100);
            }
        }

        private const string Id = "BtActionNode";
        public override string GetID
        {
            get
            {
                return Id;
            }
        }

        [ConnectionKnob("Input Top", Direction.In, "BtIn", NodeSide.Top, 50)]
        public ConnectionKnob fromPreviousIN;
        //[ConnectionKnob("Output Top", Direction.Out, "BtBack", NodeSide.Top, 50)]
        //public ConnectionKnob toPreviousOUT;

        protected override void OnCreate()
        {
            backgroundColor = Color.green;
        }

        //int slidx = 0;

        public override void NodeGUI()
        {
            EditorGUILayout.LabelField("Action");

            Assembly asmb = typeof(BTAction).Assembly;
            Type[] typs = asmb.GetTypes().Where(t =>
            t.BaseType != null && t.BaseType == typeof(BTAction)
            ).ToArray();

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
                //should return the real class you want to store in the tree
                //just for test;                 
                return GetType().FullName;
            }
        }
    }
}