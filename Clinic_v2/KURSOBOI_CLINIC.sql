use CLINIC;
--USER хран€тс€ входные данные пользователей.
CREATE TABLE [dbo].[USER] (
    [Id_user]  INT           IDENTITY (1, 1) NOT NULL,
    [Login]    NVARCHAR (20) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Access]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_user] ASC)
);
--TimeUser Ц общую информацию о времени всех возможных приЄмов
CREATE TABLE [dbo].[TimeUser] (-----------------+
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [AllTime] NVARCHAR (20) NULL,
    [Time]    NVARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)--ќ√–јЌ»„≈Ќ»я Ќј —“ќЋЅ÷џ „≈  » “ƒ
);
--Timetable Ц содержит информацию о каждом талоне , который был заказан любым пациентом
CREATE TABLE [dbo].[Timetable] (
    [Id_timetable]   INT IDENTITY (1, 1) NOT NULL,
    [Id_time_doctor] INT NULL,
    [Id_card]        INT NULL,
    PRIMARY KEY CLUSTERED ([Id_timetable] ASC),
    FOREIGN KEY ([Id_time_doctor]) REFERENCES [dbo].[TimeDoctor] ([Id_time_doctor]),
    FOREIGN KEY ([Id_card]) REFERENCES [dbo].[Health_card] ([Id_card])
);
--TimeDoctor Ц таблица котора€ содержит информацию о каждом приЄме доктора на прот€жении недели
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
--Specialty Ц информаци€ о специальност€х докторов
CREATE  TABLE [dbo].[Specialty] (
    [Id_specialty]    INT            IDENTITY (1, 1) NOT NULL,
    [Name_specialty]  NVARCHAR (20)  NULL,
    [About_specialty] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id_specialty] ASC)
);
--Profile хран€тс€ данные о зарегистрированных пользовател€х в программе
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
--Health_card  Ц информаци€ о пациентах истори€ болезней
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
--DOCTOR Ц информаци€ о врачах
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
