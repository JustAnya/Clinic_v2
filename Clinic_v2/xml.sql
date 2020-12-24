use CLINIC;
go
CREATE PROCEDURE Export
AS
	SELECT [LOGIN], [PASSWORD], [ACCESS]
	FROM [dbo].[USER]
	FOR XML PATH('user'), ROOT('Users');
	Export;



Alter PROCEDURE Import
	@xml XML = NULL
AS
Select  @xml  = 
CONVERT(XML,bulkcolumn,2) FROM OPENROWSET(BULK 'D:\KP\CLINIC\CLINIC\1.xml',SINGLE_BLOB) AS X
SET ARITHABORT ON
Insert into [dbo].[USER]
        (
          [LOGIN],[PASSWORD],[ACCESS]
        )
    Select 
        P.value('LOGIN[1]', 'varchar(20)') AS [LOGIN],
        P.value('PASSWORD[1]', 'varchar(50)') AS [PASSWORD],
        P.value('ACCESS[1]', 'int') AS ACCESS 
       
    From @xml.nodes('/Users/user') PropertyFeed(P)
GO

Import;
select * from [dbo].[USER];