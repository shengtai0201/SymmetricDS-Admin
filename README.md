# SymmetricDS Admin
client server 架構，每一台想要做資料同步的機器都是 client，此架構的 server 就是 WebApplication 所處的機器。<br/><br/>
1.SymmetricDS.Admin.ConsoleApp<br/>
用於變更該機器之設定值，重啟服務。<br/><br/>
2.SymmetricDS.Admin.WebApplication<br/>
管理介面。<br/><br/>
3.database schema:<br/>
有 SymPostgreSQL.sql 給 PostgreSQL 的資料表，SymSQLServer.sql 給 SQL Server 的資料表，其他由於我們沒用到所以沒做。<br/><br/>
4.參考資料：<br/>
http://kenny-on-rails.blogspot.com/2015/05/symmetricds_28.html
