use CLINIC;
--USER �������� ������� ������ �������������.
CREATE TABLE [dbo].[USER] (
    [Id_user]  INT           IDENTITY (1, 1) NOT NULL,
    [Login]    NVARCHAR (20) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Access]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_user] ASC)
);
--TimeUser � ����� ���������� � ������� ���� ��������� ������
CREATE TABLE [dbo].[TimeUser] (-----------------+
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [AllTime] NVARCHAR (20) NULL,
    [Time]    NVARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)--����������� �� ������� ��� � ��
);
--Timetable � �������� ���������� � ������ ������ , ������� ��� ������� ����� ���������
CREATE TABLE [dbo].[Timetable] (
    [Id_timetable]   INT IDENTITY (1, 1) NOT NULL,
    [Id_time_doctor] INT NULL,
    [Id_card]        INT NULL,
    PRIMARY KEY CLUSTERED ([Id_timetable] ASC),
    FOREIGN KEY ([Id_time_doctor]) REFERENCES [dbo].[TimeDoctor] ([Id_time_doctor]),
    FOREIGN KEY ([Id_card]) REFERENCES [dbo].[Health_card] ([Id_card])
);
--TimeDoctor � ������� ������� �������� ���������� � ������ ����� ������� �� ���������� ������
CREATE TABLE [dbo].[TimeDoctor] (
    [Id_time_doctor] INT IDENTITY (1, 1) NOT NULL,
    [Id_time]        INT NULL,
    [Day]            INT NULL,
    [Id_doctor]      INT NULL,
	[IsBusy]         bit not null,
    PRIMARY KEY CLUSTERED ([Id_time_doctor] ASC),
    FOREIGN KEY ([Id_doctor]) REFERENCES [dbo].[DOCTOR] ([Id_doctor]),
    FOREIGN KEY ([Id_time]) REFERENCES [dbo].[TimeUser] ([Id])
);
--Specialty � ���������� � �������������� ��������
CREATE  TABLE [dbo].[Specialty] (
    [Id_specialty]    INT            IDENTITY (1, 1) NOT NULL,
    [Name_specialty]  NVARCHAR (20)  NULL,
    [About_specialty] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id_specialty] ASC)
);
--Profile �������� ������ � ������������������ ������������� � ���������
CREATE TABLE [dbo].[Profile] (
    [Id_profile]   INT    IDENTITY (1, 1) NOT NULL        ,
    [Name]         NVARCHAR (20)   NULL,
    [Surname]      NVARCHAR (40) NULL,
    [Age]          DATE          NULL ,
    [Phone_number] NVARCHAR (50)  NULL,
    [Address]      NVARCHAR (50)  NULL,
    [Id_user]      INT           NULL ,
    [Image]        nvarchar(max) ,
    [Init]         NVARCHAR (40)  NULL ,
    PRIMARY KEY CLUSTERED ([Id_profile] ASC),
    FOREIGN KEY ([Id_user]) REFERENCES [dbo].[USER] ([Id_user])
);
--Health_card  � ���������� � ��������� ������� ��������
CREATE Alter TABLE [dbo].[Health_card] (
    [Id_card]         INT            IDENTITY (1, 1) NOT NULL,
    [Id_user]         INT            NULL,
    [Height]          INT            NULL,
    [Weight]          INT            NULL,
    [Chronic_disease] NVARCHAR (MAX) NULL,
    [Test_results]    NVARCHAR (MAX) NULL,
    [Diagnosis]       NVARCHAR (MAX) NULL,
    [Treatment]       NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id_card] ASC),
    FOREIGN KEY ([Id_user]) REFERENCES [dbo].[USER] ([Id_user])
);
--DOCTOR � ���������� � ������
CREATE TABLE [dbo].[DOCTOR] (-----------------+
    [Id_doctor]    INT            IDENTITY (1, 1) NOT NULL,
    [About_doctor] NVARCHAR (MAX) NULL,
    [Id_specialty] INT            NULL,
    [Id_user]      INT            NULL,
    [Initial_doc]  NCHAR (30)     NULL,
    PRIMARY KEY CLUSTERED ([Id_doctor] ASC),
    FOREIGN KEY ([Id_user]) REFERENCES [dbo].[USER] ([Id_user]),
    FOREIGN KEY ([Id_specialty]) REFERENCES [dbo].[Specialty] ([Id_specialty])
);


Alter table Specialty Alter column About_specialty NVARCHAR(180) NULL;
CREATE  TABLE [dbo].[Spec] (
    [Id_specialty]    INT            IDENTITY (1, 1) NOT NULL,
    [Name_specialty]  NVARCHAR (60)  NULL,
    [About_specialty] NVARCHAR (60) NULL,
	PRIMARY KEY CLUSTERED ([Id_specialty] ASC)
);
