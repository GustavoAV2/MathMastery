CREATE TABLE [dbo].[Friends] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [RequesterId]      NVARCHAR (MAX) NOT NULL,
    [ReceiverId]       NVARCHAR (MAX) NOT NULL,
    [RequestDate]      DATETIME2 (7)  NOT NULL,
    [ConfirmationDate] DATETIME2 (7)  NOT NULL,
    [Status]           NVARCHAR (1)   NOT NULL,
    CONSTRAINT [PK_Friends] PRIMARY KEY CLUSTERED ([ID] ASC)
);
