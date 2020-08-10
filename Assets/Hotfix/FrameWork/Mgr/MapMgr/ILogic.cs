using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHotfix
{
    public interface ILogic
    {
        bool IsLocked{ get; set; }
        int ConfigId { get; }
        
        /// <summary>
        /// 这里设计退出时 数据自动往前推进
        /// </summary>
        void Complete();
    }
}


