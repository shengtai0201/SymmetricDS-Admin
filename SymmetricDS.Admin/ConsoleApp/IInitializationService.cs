﻿namespace SymmetricDS.Admin.ConsoleApp
{
    public interface IInitializationService
    {
        Node GetNode(int nodeId);

        // Step 1.對Database進行初始化
        void CreateTables(string path, IConfiguration configuration);

        bool CheckTables();

        // Step 2.寫入Node Group
        bool NodeGroups(INode node);

        // Step 3.設定Node Group之間的資料同步方式
        bool SynchronizationMethod(INode node);

        // Step 4.設定Node
        bool Node(INode node);

        // Step 5.設定通道
        bool Channel();

        // Step 6.定義Trigger
        bool Triggers();

        // Step 7.定義Router
        bool Router();

        // Step 8.建立Trigger與Router的關連
        bool Relationship();

        // Step 2.啟動服務
        void InstallService(string path);

        void UninstallService(string path);

        void StopService(string path);

        void StartService(string path);

        void RunOnlyOnce(string path, string syncUrlPort);
    }
}