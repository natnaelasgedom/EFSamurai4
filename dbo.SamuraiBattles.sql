CREATE TABLE [dbo].[SamuraiBattles] (
    [SamuraiID] INT NOT NULL,
    [BattleID]  INT NOT NULL,
    [myTestColumn]  INT NOT NULL,
    CONSTRAINT [PK_SamuraiBattles] PRIMARY KEY CLUSTERED ([BattleID] ASC, [SamuraiID] ASC),
    CONSTRAINT [FK_SamuraiBattles_Battles_BattleID] FOREIGN KEY ([BattleID]) REFERENCES [dbo].[Battles] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SamuraiBattles_Samurais_SamuraiID] FOREIGN KEY ([SamuraiID]) REFERENCES [dbo].[Samurais] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SamuraiBattles_SamuraiID]
    ON [dbo].[SamuraiBattles]([SamuraiID] ASC);

