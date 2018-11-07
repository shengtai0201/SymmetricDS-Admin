﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin
{
    public interface IInitialization
    {
        // Step 1.對Database進行初始化
        void Database();

        // Step 2.寫入Node Group
        void NodeGroup();

        // Step 3.設定Node Group之間的資料同步方式
        void SynchronizationMethod();

        // Step 4.設定Node
        void Node();

        // Step 5.設定通道
        void Channel();

        // Step 6.定義Trigger
        void Trigger();

        // Step 7.定義Router
        void Router();

        // Step 8.建立Trigger與Router的關連
        void Relationship();
    }
}
