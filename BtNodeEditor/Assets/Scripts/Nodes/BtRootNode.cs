using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodeEditorFramework;
using System;
using System.Reflection;

namespace BtNodeEditor
{
    [Node(false, "BT/Root Node", new Type[] { typeof(BtCanvas)})]
    public class BtRootNode : BtNodeBase
    {
        public override string Title
        {
            get
            {
                return "Root Node";
            }
        }

        public override Vector2 DefaultSize
        {
            get
            {
                return new Vector2(100, 80);
            }
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

        public override Type GetOjbectType
        {
            get
            {
                return typeof(BtRootNode);
            }
        }

        private const string Id = "BtRootNode";
        public override string GetID
        {
            get
            {
                return Id;
            }
        }
        
        [ConnectionKnob("Output Bottom", Direction.Out, "BtOut", ConnectionCount.Single, NodeSide.Bottom, 50)]
        public ConnectionKnob toNextOUT;

        protected override void OnCreate()
        {
            backgroundColor = Color.magenta;
        }

        string m_TreeName = "Tree Name";

        public override void NodeGUI()
        {
            EditorGUILayout.LabelField("Root");

            m_TreeName = GUILayout.TextField(m_TreeName);
            if (GUILayout.Button("Print Tree"))
            {
                PrintTree();
            }
        }

        void PrintTree()
        {
            PrintChildren(this);
        }


        void PrintChildren(BtNodeBase node)
        {
            Debug.Log("current is " + node);
            PrintNode();
            
            if (node is BtRootNode)
            {
                if ((node as BtRootNode).toNextOUT != null && (node as BtRootNode).toNextOUT.connections != null)
                {
                    List<ConnectionKnob> sortedlst = new List<ConnectionKnob>((node as BtRootNode).toNextOUT.connections.ToArray());
                    sortedlst.Sort((x, y) =>
                    {
                        return x.body.position.x.CompareTo(y.body.position.x);
                    }
                    );

                    for (int i = 0; i < sortedlst.Count; ++i)
                    {
                        PrintChildren(sortedlst[i].body as BtNodeBase);
                    }
                    //foreach (ConnectionKnob ck in (node as BtRootNode).toNextOUT.connections)
                    //{
                    //    PrintChildren(ck.body as BtNodeBase);
                    //}
                }
            }

            if (node is ControlNode)
            {
                if ((node as ControlNode).toNextOUT.connections != null)
                {
                    List<ConnectionKnob> sortedlst = new List<ConnectionKnob>((node as ControlNode).toNextOUT.connections.ToArray());

                    sortedlst.Sort((x, y) =>
                    {
                        return x.body.position.x.CompareTo(y.body.position.x);
                    }
                    );
                    for (int i = 0; i < sortedlst.Count; ++i)
                    {
                        PrintChildren(sortedlst[i].body as BtNodeBase);
                    }

                    //foreach (ConnectionKnob ck in (node as ControlNode).toNextOUT.connections)
                    //{
                    //    PrintChildren(ck.body as BtNodeBase);
                    //}
                }
            }

            if (node is DecoratorNode)
            {
                if ((node as DecoratorNode).toNextOUT.connections != null)
                {

                    List<ConnectionKnob> sortedlst = new List<ConnectionKnob>((node as DecoratorNode).toNextOUT.connections.ToArray());
                    sortedlst.Sort((x, y) => {
                        return x.body.position.x.CompareTo(y.body.position.y);
                    });

                    for (int i = 0; i < sortedlst.Count; ++i)
                    {
                        PrintChildren(sortedlst[i].body as BtNodeBase);
                    }
                    //foreach (ConnectionKnob ck in (node as DecoratorNode).toNextOUT.connections)
                    //{
                    //    PrintChildren(ck.body as BtNodeBase);
                    //}
                }
            }
        }
    }
}
