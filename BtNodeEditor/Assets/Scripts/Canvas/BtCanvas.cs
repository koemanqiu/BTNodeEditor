using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;

namespace BtNodeEditor
{
    [NodeCanvasType("Bt Canvas")]
    public class BtCanvas : NodeCanvas
    {
        public override string canvasName
        {
            get
            {
                return "Bt";
            }
        }

        //string rootNodeId = "BtRootNode";
        //public BtRootNode m_RootNode;

        //protected override void OnCreate()
        //{
        //    m_RootNode = Node.Create(rootNodeId, Vector2.zero) as BtRootNode;
        //}

        //protected override void ValidateSelf()
        //{
        //    int rootCnt = 0;
        //    foreach( var node in nodes)
        //    {
        //        if ( node is BtRootNode)
        //        {
        //            rootCnt++;
        //            if ( m_RootNode == null)
        //            {
        //                m_RootNode = node as BtRootNode;
        //            }
        //        }

        //        if ( rootCnt >= 2)
        //        {
        //            Debug.LogError("Only One Root Node allowed in BtCanvas");
        //            break;
        //        }
        //    }
        //    if (m_RootNode == null)
        //    {
        //        Debug.LogError("Please Add A Root Node Manually");
        //    }
        //}



    }
    
}
