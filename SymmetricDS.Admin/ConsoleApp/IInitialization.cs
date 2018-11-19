using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.ConsoleApp
{
    public interface IInitialization
    {
        Node GetNode(int nodeId);

        // Step 1.對Database進行初始化
        void CreateTables(string path, IConfiguration configuration);

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
    }
}
