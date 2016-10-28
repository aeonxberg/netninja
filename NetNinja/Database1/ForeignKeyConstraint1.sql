ALTER TABLE [dbo].[NinjaEquipment]
	ADD CONSTRAINT [ForeignKeyConstraint1]
	FOREIGN KEY (NinjaName)
	REFERENCES [Ninja] (Name)
